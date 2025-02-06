using FirstAspApp.Data;
using FirstAspApp.Interfaces;
using FirstAspApp.Repositories;
using FirstAspApp.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VideoGameDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVideoGameRepository, VideoGameRepository>();

builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();

builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
