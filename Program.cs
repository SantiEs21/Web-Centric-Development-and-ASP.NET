using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("LibraryDB")
));

builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    db.Database.EnsureCreated();
    DBInitializer.Initialize(db);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
