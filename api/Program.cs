using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// DB context
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



app.UseHttpsRedirection();



// Just a simple root endpoint
app.MapGet("/", () => "Hello from ASP.NET Core Web API!");

// Optional: keep or remove weatherforecast example
// app.MapGet("/weatherforecast", () => { ... });

app.Run();
