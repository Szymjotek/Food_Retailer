using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SaleKiosk.BlazorClient;
using SaleKiosk.BlazorClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// rejestracja ProductService w kontenerze zale�no�ci
builder.Services.AddScoped<IProductService, ProductService>();

// rejestracja CartService w kontenerze zale�no�ci
builder.Services.AddScoped<ICartService, CartService>();

// rejestracja OrderService w kontenerze zale�no�ci
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddRadzenComponents();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// modyfikacja klienta http aby pobiera� dane z pliku konfiguracyjnego 
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetValue<string>("SaleKioskAPIUrl"))
});


builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
