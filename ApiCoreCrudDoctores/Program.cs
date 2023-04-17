using ApiCoreCrudDoctores.Data;
using ApiCoreCrudDoctores.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryDoctores>();
builder.Services.AddDbContext<DoctoresContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Api BBDD",
            Description = "Estamos realizando una Api con BBDD en Azure",
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "Sandra Sevilleja González",
                Email = "sandra.sevilleja@tajamar365.com"
            }
        });
    });

var app = builder.Build();

app.UseSwagger();
//DEBEMOS INDICAR QUE LA PÁGINA DE INICIO DE LA APLICACION SEA SWAGGER
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json", name: "Api v1");
    options.RoutePrefix = "";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
