// made with ‘dotnet new webapi -n API’
// run using ‘cd API’ and ‘dotnet run’ or ‘dotnet watch’ for active reloading

// Directives to include the necessary namespaces for Entity Framework Core,
// your data context, and your services.
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Extensions;

// Start building the application configuration and services.
var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers to the services collection.
builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration); // Bringing in services from ApplicationServiceExtensions.cs
builder.Services.AddIdentityServices(builder.Configuration); // Bringing in services from IdentityServiceExtensions.cs


// Finish the building process and prepare to start the application.
var app = builder.Build();

// Enforce HTTPS for increased security.
app.UseHttpsRedirection();

// Configure CORS to allow any header and any method from the specified origin.
// This is where you're allowing your front-end application to communicate with your API.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

// these things below must be in this exact spot in this Program.cs class
app.UseAuthentication(); // Does the user have a valid token?
app.UseAuthorization(); // Ok, they have a valid token, what is the user allowed to do with it?

// Map the controllers within the application so that the framework can route incoming
// HTTP requests to the appropriate controller actions.
app.MapControllers();

// Run the application, listening for incoming HTTP requests.
app.Run();


