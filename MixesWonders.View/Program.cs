using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Commands;
using MixeWonders.Values.Context;
using MixeWonders.Values.Queries;
using MixeWonders.Values.Services;
using MudBlazor;
using MudBlazor.Services;
using static MixeWonders.Values.Services.ScopeService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<BrugsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect"),
    b => b.MigrationsAssembly("MixeWonders.Value")));

// Register other services
var services = builder.Services;
services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

services.AddHttpClient();
services.AddTransient<IProvideDbContext>(x => x.GetRequiredService<BrugsDbContext>());
services.AddTransient<ScopeService>();
services.AddScoped<UserServiceCommands>();
services.AddScoped<UserServiceQueries>();
services.AddTransient<UserService>();

var app = builder.Build();

// Logging the database connection
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BrugsDbContext>();
    var databaseName = context.Database.GetDbConnection().Database;
    Console.WriteLine($"Connected to database: {databaseName}");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
