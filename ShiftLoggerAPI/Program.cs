using Microsoft.EntityFrameworkCore;
using ShiftLoggerAPI.Data;
using ShiftLoggerAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ShiftLoggerContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();  

app.UseAuthorization();

app.MapControllers();

app.Run();
