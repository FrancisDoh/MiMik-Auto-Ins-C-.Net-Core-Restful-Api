using MiMik_Auto_Ins_RestfulApi.Profiles;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// START
builder.Services.AddScoped<IDbConnection>(db => new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))); // Connection to the MySQL DB
builder.Services.AddScoped<IPolicyRepository, PolicyRepository>(); // Give class when I call Interface
builder.Services.AddAutoMapper(typeof(ModelMapperProfile)); // AutoMapper injection in the program

// End

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
