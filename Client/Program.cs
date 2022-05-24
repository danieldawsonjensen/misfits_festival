using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using misfits_festival.Shared.Models;
using Dapper;
using misfits_festival.Client;
using misfits_festival.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IKoordinatorService, KoordinatorService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddHttpClient<IFrivilligService, FrivilligService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});


await builder.Build().RunAsync();
