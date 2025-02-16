using Microsoft.EntityFrameworkCore;
using AztroWebApplication.Data;
using AztroWebApplication.Repositories;
using AztroWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

//Guardar la cadena de conexión en una variable
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Validar que la cadena de conexión no sea nula o vacía
if(string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string is empty or null");
}

builder.Services.AddDbContext<AztroWebApplication.Data.ApplicationDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
