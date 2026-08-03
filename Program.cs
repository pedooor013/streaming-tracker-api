using StreamingSubscriptionTrackerAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using StreamingSubscriptionTrackerAPI.Services;
using StreamingSubscriptionTrackerAPI.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MSSQLContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISubscriptionService, SubscriptionServiceImpl>();
builder.Services.AddScoped<ISubscriptionCategoryService, SubscriptionCategoryServiceImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();