using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Qz.Application.Contracts.Base;
using Qz.Application.Contracts.Repositorys;
using Qz.AppService.Queries;
using Qz.Persistence;
using Qz.Persistence.Repositorys;
using Qz.WebApi.Services;
using WebApi.YZGJ.Filters;
using Qz.Persistence;

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

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<TodoItemHandler>());

builder.Services.AddTransient<CustomExceptionFilterAttribute>();

// 后台任务
builder.Services.AddHostedService<MyBackgroundService>();

// 分布式缓存，先用内存缓存代替
builder.Services.AddDistributedMemoryCache();

// 注册容器
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ITeamRepository, TeamRepository>();
builder.Services.AddSingleton<ITodoItemRepository, TodoItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
