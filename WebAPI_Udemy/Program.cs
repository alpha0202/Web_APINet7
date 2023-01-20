

using WebAPI_Udemy;
using WebAPI_Udemy.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration;
var cadenaConexionSql = new ConexionBaseDatos(config.GetConnectionString("SQL"));
builder.Services.AddSingleton(cadenaConexionSql);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IServicioEmpleado, ServicioEmpleado>();
builder.Services.AddSingleton<IServicioEmpleadoSQL, ServicioEmpleadoSQL>();


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
