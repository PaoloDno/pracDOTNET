using api.Data;
using api.Models;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DB context
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseHttpsRedirection();



// Just a simple root endpoint
app.MapGet("/", () => "Hello from ASP.NET Core Web API!");

// Optional: keep or remove weatherforecast example
// app.MapGet("/weatherforecast", () => { ... });

app.Run();
