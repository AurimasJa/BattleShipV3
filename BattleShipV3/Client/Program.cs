using BattleShipV3.Client;
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
builder.Services.AddScoped<UserShipsService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
