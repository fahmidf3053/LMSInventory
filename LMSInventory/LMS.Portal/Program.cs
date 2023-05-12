using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using LMS.Portal;
using LMS.Portal.Helper;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

Constants.BASE_URL = builder.Configuration["API_BASE_ADDRESS"];
builder.Configuration.Bind("UserInfo", Constants.user);


builder.Services.AddScoped<HttpClientHelper>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
