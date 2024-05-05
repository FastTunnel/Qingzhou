using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using Qz.Application;
using Qz.Application.Base;
using Qz.Application.Orgs.CreateOrganization;
using Qz.Application.Todos.GetTodoItems;
using Qz.Domain.Organization;
using Qz.Domain.Projects;
using Qz.Domain.TodoItems;
using Qz.Domain.Users;
using Qz.Domain.Workitems;
using Qz.Persistence.Extensions;
using Qz.Persistence.Issues;
using Qz.Persistence.Maper;
using Qz.Persistence.Repositorys;
using Qz.WebApi.Filters;
using Qz.WebApi.Json;

using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(delegate (ApiBehaviorOptions options)
{
    options.InvalidModelStateResponseFactory = delegate (ActionContext context)
    {
        var errors = context.ModelState.Select((x) => new KeyValuePair<string, string[]>(x.Key, x.Value.Errors.ToArray().Select(x => x.ErrorMessage).ToArray()));
        var res = new JsonResult(new ErrorInfo("参数校验失败", errors.ToDictionary(), context.HttpContext.TraceIdentifier));
        res.StatusCode = StatusCodes.Status200OK;
        return res;
    };
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonLongConverter());
    options.JsonSerializerOptions.NumberHandling
        = (JsonNumberHandling.AllowReadingFromString);
});

builder.Services.AddAutoMapper(typeof(EntityProfile));

builder.Services.AddTransient<CreateOrganizationHandler>();

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
        OnChallenge = async delegate (JwtBearerChallengeContext context)
        {
            context.HandleResponse();

            context.Response.ContentType = "application/json;charset=utf-8";
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorInfo(context.Error ?? "未登录", null, context.HttpContext.TraceIdentifier), new JsonSerializerOptions(JsonSerializerDefaults.Web)));
        },
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.ParameterFilter<MyParameterFilter>();
    options.SchemaFilter<MySchemaFilter>();
    options.CustomOperationIds(apiDesc =>
    {
        return (apiDesc.ActionDescriptor as ControllerActionDescriptor)!.ActionName; // apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name.Replace("Async", string.Empty) : null;
    });
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
builder.Services.AddTransient<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddTransient<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddTransient<IWorkitemRepository, IssueRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

builder.Services.AddCors((options) =>
{
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5173")
            .WithOrigins("127.0.0.1:5173")
            .AllowAnyMethod()
            .AllowAnyHeader().AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
