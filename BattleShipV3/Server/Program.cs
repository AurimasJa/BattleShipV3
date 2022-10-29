using Microsoft.AspNetCore.ResponseCompression;
using BattleShipV3.Server.Hubs;
using BattleShipV3.Server.Repositories;
using BattleShipV3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BattleshipDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IListingsRepository, ListingsRepository>();
builder.Services.AddTransient<IMissilesRepository, MissilesRepository>();
builder.Services.AddTransient<IShipsRepository, ShipsRepository>();
//builder.Services.AddTransient<IShipPlacementsRepository, ShipPlacementsRepository>();
builder.Services.AddTransient<IGameMatchesRepository, GameMatchesRepository>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:44342"); // add the allowed origins
                      });
});

var app = builder.Build();
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseCors(MyAllowSpecificOrigins);


app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();

app.MapHub<ChatHub>("/chathub");
app.MapHub<LobbyHub>("/lobbyhub");
app.MapFallbackToFile("index.html");

app.Run();