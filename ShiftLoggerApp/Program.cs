using System.Net.Http.Headers;
using System.Net.Http.Json;
using ShiftLoggerApp.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ShiftLoggerApp.Views;
using ShiftLoggerApp.Clients;
using System.ComponentModel.DataAnnotations;

// Create and host the container.
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

// Tell the container what classes you want to use in DI.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<Menu>();
builder.Services.AddSingleton<Validate>();
builder.Services.AddSingleton<UserInput>();
builder.Services.AddSingleton<ShiftLoggerClient>();

// Tell the container to figure out the web of dependencies for classes
var host = builder.Build();

// Use the host(container) to give an instance of the menu class so we can call its methods
var menu = host.Services.GetRequiredService<Menu>();

// Application root; the call has everything it needs from the DI container
await menu.ShowMenu();




