using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using Qz.Application.Base;
using Qz.Application.Contracts.Maper;
using Qz.Application.Teams.AddTeam;
using Qz.Application.Todos.GetTodoItems;
using Qz.Domain.Teams;
using Qz.Domain.TodoItems;
using Qz.Domain.Users;
using Qz.Persistence.Extensions;
using Qz.Persistence.Maper;
using Qz.Persistence.Repositorys;
using Qz.WebApi.Filters;
using Qz.WebApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(delegate (ApiBehaviorOptions options)
{
    options.InvalidModelStateResponseFactory = delegate (ActionContext context)
    {
        string arg = string.Join('\n', context.ModelState.Select<KeyValuePair<string, ModelStateEntry>, string>((KeyValuePair<string, ModelStateEntry> x) => x.Value.Errors.FirstOrDefault()?.ErrorMessage));
        return new JsonResult(new QzResponse
        {
            Success = false,
            Message = arg,
            TraceId = context.HttpContext.TraceIdentifier
        });
    };
});

builder.Services.AddAutoMapper(typeof(EntityProfile), typeof(ApplicationProfile));

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
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new QzResponse
            {
                Success = false,
                TraceId = context.HttpContext.TraceIdentifier,
                Message = msg
            }));
        },
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddHostedService<MyBackgroundService>();

// 分布式缓存，先用内存缓存代替
builder.Services.AddDistributedMemoryCache();

// 注册容器
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<ITodoItemRepository, TodoItemRepository>();
builder.Services.AddCors((options) =>
{
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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
