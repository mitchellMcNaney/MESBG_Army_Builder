using Microsoft.EntityFrameworkCore;
using Mesbg.Api.Data;
using Mesbg.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MesbgDbContext>(options => 
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("MesbgDatabase")
    ));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<UnitService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularDev", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseCors("AngularDev");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
