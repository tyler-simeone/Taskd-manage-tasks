using System.Text.Json;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false);
var connectionString = builder.Configuration.GetConnectionString("ProjectBLocalConnection");


// Add services to the container.
builder.Services.AddControllers();;
builder.Services.AddSingleton<IRequestValidator, RequestValidator>();
builder.Services.AddSingleton<ITasksRepository, TasksRepository>();
builder.Services.AddSingleton<ITasksDataservice, TasksDataservice>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo 
        { 
            Title = "manage-tasks", 
            Version = "v1", 
            Description = "An ASP.NET Core Web API for managing Tasks",
            Contact = new OpenApiContact
                    {
                        Name = "Tyler Simeone",
                        Url = new Uri("https://github.com/tyler-simeone")
                    },
        });
    });

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "manage-tasks v1");
    });
    // app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();