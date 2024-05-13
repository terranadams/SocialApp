// made with ‘dotnet new webapi -n API’
// run using ‘cd API’ and ‘dotnet run’ or ‘dotnet watch’ for active reloading

// Directives to include the necessary namespaces for Entity Framework Core,
// your data context, and your services.
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Interfaces;
using API.Services;

// Start building the application configuration and services.
var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers to the services collection.
builder.Services.AddControllers();

// Add the data context for Entity Framework Core, configuring it to use SQLite
// with a connection string from the app settings.
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add Cross-Origin Resource Sharing (CORS) services to the service collection.
// This allows your API to be called from different domains, which is particularly
// useful during development.
builder.Services.AddCors();

// Register the token service with dependency injection making it available
// for controller constructors and other services.
builder.Services.AddScoped<ITokenService, TokenService>();

// Finish the building process and prepare to start the application.
var app = builder.Build();

// Enforce HTTPS for increased security.
app.UseHttpsRedirection();

// Add authorization middleware to the pipeline to enable authorization checks.
app.UseAuthorization();

// Configure CORS to allow any header and any method from the specified origin.
// This is where you're allowing your front-end application to communicate with your API.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

// Map the controllers within the application so that the framework can route incoming
// HTTP requests to the appropriate controller actions.
app.MapControllers();

// Run the application, listening for incoming HTTP requests.
app.Run();


