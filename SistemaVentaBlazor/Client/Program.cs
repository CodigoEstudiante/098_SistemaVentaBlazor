global using SistemaVentaBlazor.Client.Servicios.Contrato;
global using SistemaVentaBlazor.Shared;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SistemaVentaBlazor.Client;
using SistemaVentaBlazor.Client.Servicios.Implementacion;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<IProductoService,ProductoService>();
builder.Services.AddScoped<IRolService,RolService>();
builder.Services.AddScoped<IUsuarioService,UsuarioService>();
builder.Services.AddScoped<IVentaService,VentaService>();
builder.Services.AddScoped<IDashBoardService,DashBoardService>();

builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
