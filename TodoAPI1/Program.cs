using Microsoft.EntityFrameworkCore;
using TodoAPI1;
using TodoAPI1.Repository;
using TodoAPI1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<TodoDb>();
builder.Services.AddScoped<TodoService>();
builder.Services.AddScoped<TodoRepository>();
var app = builder.Build();

app.MapControllers();
app.Run();

