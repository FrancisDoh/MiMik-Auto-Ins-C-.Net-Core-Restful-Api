using Microsoft.EntityFrameworkCore;
using MiMik_Auto_Ins_RestfulApi.Data;
using MiMik_Auto_Ins_RestfulApi.Repositories;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// START
// SQL Server connection params dependencies injection in the app.
builder.Services.AddDbContext<MimikDbContext>(options =>
{
    //For SQL Server
    //options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalks"));
    // For MySql server
    options.UseMySql(ServerVersion.AutoDetect("MySqlConnection"));
    //options.UseMySql(Configuration.GetConnectionString("MySqlConnection"));
});

// Whenever I ask for interface, give me the implemented class Methods.
builder.Services.AddScoped<IPolicy, Policy>();

// AutoMapper service declaration injection into the program.
builder.Services.AddAutoMapper(typeof(Program).Assembly);


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
