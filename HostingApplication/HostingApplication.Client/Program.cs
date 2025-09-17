using HostingApplication.Client.Admin.Products.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://your-api-url.com/") });

builder.Services.AddScoped<AdminCategoryService>();
builder.Services.AddScoped<AdminBrandService>();

await builder.Build().RunAsync();
