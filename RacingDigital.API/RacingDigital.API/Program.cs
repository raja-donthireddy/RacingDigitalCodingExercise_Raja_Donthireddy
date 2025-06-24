using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RacingDigital.API.Data;
using RacingDigital.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaceDB")));

builder.Services.AddScoped<RaceService>();

builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Race Results API V1", Version = "v1" });
});

var app = builder.Build();

//Use Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Race Results API V1");
        c.RoutePrefix = "swagger"; // Swagger UI at app root (http://localhost:5000/swagger/)
    });
}

// Seed data setup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
