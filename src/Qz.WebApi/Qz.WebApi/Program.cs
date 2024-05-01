using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using Qz.Application.Base;
using Qz.Application.Orgs.AddOrg;
using Qz.Application.Todos.GetTodoItems;
using Qz.Domain.Issues;
using Qz.Domain.Orgs;
using Qz.Domain.TodoItems;
using Qz.Domain.Users;
using Qz.Persistence.Extensions;
using Qz.Persistence.Issues;
using Qz.Persistence.Maper;
using Qz.Persistence.Repositorys;
using Qz.WebApi.Filters;
using Qz.WebApi.Json;
using Qz.WebApi.Services;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(delegate (ApiBehaviorOptions options)
{
    options.InvalidModelStateResponseFactory = delegate (ActionContext context)
    {
        string arg = string.Join('\n', context.ModelState.Select<KeyValuePair<string, ModelStateEntry>, string>((KeyValuePair<string, ModelStateEntry> x) => x.Value.Errors.FirstOrDefault()?.ErrorMessage));
        return new JsonResult(new QzResponse<object>
        {
            Success = false,
            Message = arg,
            TraceId = context.HttpContext.TraceIdentifier
        });
    };
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonLongConverter());
    options.JsonSerializerOptions.NumberHandling
        = (JsonNumberHandling.AllowReadingFromString);
});

builder.Services.AddAutoMapper(typeof(EntityProfile));

builder.Services.AddTransient<AddTeamCommandHandler>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", null, delegate (JwtBearerOptions options)
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(Convert.ToInt32(builder.Configuration.GetSection("JWT")["ClockSkew"])),
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration.GetSection("JWT")["ValidAudience"],
        ValidIssuer = builder.Configuration.GetSection("JWT")["ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(builder.Configuration.GetSection("JWT")["SigningKey"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = async delegate (MessageReceivedContext message)
        {
            // 商户后台的token
            if (message.Request.Cookies.TryGetValue("Authorization", out string token))
            {
                message.Token = token.Replace("Bearer ", "");
            }

            if (message.Request.Headers.TryGetValue("JWT-Token", out var value2))
            {
                message.Token = value2[0]?.ToString().Replace("Bearer ", "");
            }
        },
        OnChallenge = async delegate (JwtBearerChallengeContext context)
        {
            context.HandleResponse();
            context.Response.ContentType = "application/json;charset=utf-8";
            var msg = context.Error ?? "未登录";
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new QzResponse<object>
            {
                Success = false,
                TraceId = context.HttpContext.TraceIdentifier,
                Message = msg
            }));
        },
    };
});

builder.Services.AddOpenApiDocument(options =>
{
    options.PostProcess = document =>
    {
        document.Info = new OpenApiInfo
        {
            Version = "v1",
            Title = "轻舟 RestAPI",
            Description = "An ASP.NET Core Web API for managing ToDo items",
            TermsOfService = "https://example.com/terms",
            Contact = new OpenApiContact
            {
                Name = "Example Contact",
                Url = "https://example.com/contact"
            },
            License = new OpenApiLicense
            {
                Name = "Example License",
                Url = "https://example.com/license"
            }
        };
    };
});

builder.Services.AddDapperDBContext<QingZhouDbContext>(options =>
{
    var constr = builder.Configuration.GetConnectionString("Core");
    if (string.IsNullOrEmpty(constr))
    {
        throw new Exception("数据库连接字符串未配置");
    }

    options.Configuration = constr;
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetTodoItemsQueryHandler>());

builder.Services.AddTransient<CustomExceptionFilterAttribute>();

// 后台任务
//builder.Services.AddHostedService<MyBackgroundService>();

// 分布式缓存，先用内存缓存代替
builder.Services.AddDistributedMemoryCache();

// 注册容器
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOrgRepository, OrgRepository>();
builder.Services.AddTransient<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddTransient<IIssueRepository, IssueRepository>();

builder.Services.AddCors((options) =>
{
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())

    app.UseReDoc(options =>
    {
        options.Path = "/redoc";
    });
}

app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
