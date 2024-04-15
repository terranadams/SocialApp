// made with ‘dotnet new webapi -n API’
// run using ‘cd API’ and ‘dotnet run’ or ‘dotnet watch’ for active reloading

using Microsoft.EntityFrameworkCore;
using API.Data; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the http request pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


