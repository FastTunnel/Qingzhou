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
        throw new Exception("���ݿ������ַ���δ����");
    }

    options.Configuration = constr;
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<TodoItemHandler>());

builder.Services.AddTransient<CustomExceptionFilterAttribute>();

// ��̨����
builder.Services.AddHostedService<MyBackgroundService>();

// �ֲ�ʽ���棬�����ڴ滺�����
builder.Services.AddDistributedMemoryCache();

// ע������
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
