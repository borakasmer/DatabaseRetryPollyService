using LinqToDBBlog.Entities.DbContexts;
using LinqToDBBlog.Models;
using LinqToDBBlog.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DashboardContext>(options => options.UseSqlServer(builder.Configuration["DefaultConnection"]));

builder.Services.Configure<DatabaseReconnectSettings>(builder.Configuration.GetSection("DatabaseReconnectSettings"));
builder.Services.AddSingleton<IDatabaseRetryService, DatabaseRetryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
