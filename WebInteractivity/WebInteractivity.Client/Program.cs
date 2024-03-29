using BlazorApp;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebInteractivity.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// TODO added CookieHandler 
builder.Services.AddTransient<CookieHandler>();

// TODO added CookieHandler to HttpMessageHandler
builder.Services.AddHttpClient("WebAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<CookieHandler>();

// TODO added IHttpClientFactory as Scoped and created WebAPI HttpClient
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient("WebAPI"));

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

await builder.Build().RunAsync();
