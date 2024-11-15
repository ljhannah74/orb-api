using Microsoft.EntityFrameworkCore;
using orb_api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => 
{
    options.AddPolicy("MyCors", builder => 
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Replace with your MySQL connection string
var connectionString = "Server=localhost;Port=3306;Database=orb_db;User=lewisjhannah;Password=precious5;";

// Register MySQL database
builder.Services.AddDbContext<OrbDbContext>(options =>
     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orb API V1");
        c.RoutePrefix = string.Empty; // Set to access Swagger UI at the root (e.g., http://localhost:5000/)
    });
}

app.Run();
