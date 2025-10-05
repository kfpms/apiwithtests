using HundredX.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HundredxContext>(options =>
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("HundredxDb"))
        .UseSnakeCaseNamingConvention()   // 👈 maps CryptocurrencyId → cryptocurrency_id, etc.
);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HundredX.API v1");
    c.RoutePrefix = string.Empty; // serve Swagger UI at "/"
});

// Redirect root ("/") to Swagger
//app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapControllers();

app.Run();

public partial class Program { }
