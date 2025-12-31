using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;

using CoCanvas.Application.Services;
using CoCanvas.Application.Interfaces.Repositories;
using CoCanvas.Application.Interfaces;
using CoCanvas.Infrastructure.Persistance;
using CoCanvas.Infrastructure.Repositories;
using CoCanvas.Infrastructure.Services;
using CoCanvas.Domain.Entities;
using CoCanvas.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CCDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5000") // Vue frontend URL
                  .AllowAnyMethod()
                  .AllowAnyHeader();
                  //.AllowCredentials();    // For Cookie authentication
        });
});

builder.Services.AddAuthorization();

// TODO: Use JWT in the future?
builder.Services.AddAuthentication(IdentityConstants.BearerScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<CCDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContext<CCDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories from infrastructure
builder.Services.AddScoped<IPostsRepository, PostsRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository >();

// Application services

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<PostsService>();

var app = builder.Build();

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(); // Enables serving from wwwroot by default

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();
