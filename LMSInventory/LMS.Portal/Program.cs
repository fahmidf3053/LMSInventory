using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using LMS.Portal;
using LMS.Portal.Helper;
using LMS.API.DTOs.RequestDTOs;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

Constants.BASE_URL = builder.Configuration["API_BASE_ADDRESS"];
builder.Configuration.Bind("UserInfo", Constants.user);


builder.Services.AddScoped<HttpClientHelper>();

await builder.Build().RunAsync();
