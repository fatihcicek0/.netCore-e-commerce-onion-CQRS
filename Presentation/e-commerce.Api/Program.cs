using E_commerce_.netcore.Application;
using E_commerce_.netcore.Application.Exceptions;
using E_commerce_.netcore.Persistence;
using E_commerce_.netcore.Mapper;
using E_commerce_.netcore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var env = builder.Environment;
builder.Configuration
     .SetBasePath(env.ContentRootPath)
     .AddJsonFile("appsettings.json", optional: false)
     .AddJsonFile($"appsettings{env.EnvironmentName}.json",optional:true);


builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
