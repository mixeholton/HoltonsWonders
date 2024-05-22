using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MixeWonders.Client;
using MixeWonders.Values.Commands;
using MixeWonders.Values.Services;
using MixeWonders.Values.Queries;
using MudBlazor;
using MudBlazor.Services;
using MixeWonders.Values.Context;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<BrugsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));

var services = builder.Services;
services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
services.AddTransient<ScopeService>();
services.AddScoped<UserServiceCommands>();
services.AddScoped<UserServiceQueries>();
services.AddTransient<BrugsUserService>();


await builder.Build().RunAsync();
