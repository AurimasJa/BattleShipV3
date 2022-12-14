using BattleShipV3.Client;
using BattleShipV3.Client.DesignPatterns.Singleton;
using BattleShipV3.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ToastService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ListingService>();
builder.Services.AddScoped<GameMatchService>();
builder.Services.AddScoped<ShipService>();
builder.Services.AddScoped<ShipPlacementService>();
builder.Services.AddScoped<MissileService>();
builder.Services.AddScoped<UserShipsService>();
builder.Services.AddMudServices();

OnlinePlayersSingleton.getInstance();

await builder.Build().RunAsync();
