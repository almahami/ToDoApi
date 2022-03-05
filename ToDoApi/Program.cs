using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Controllers;
using ToDoApi.Data;
using ToDoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoItemContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("ToDoItemsDBConnection")));
//builder.Services.AddDbContext<TodoItemContext>(opt => opt.UseInMemoryDatabase("TodoList"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IToDoData, SqlToDOItemData>();
//builder.Services.AddIMapper<IMapper, Mapper>();
builder.Services.AddMediatR(typeof(Program));
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