using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using MyTicketMaster.Web.Clients;
using MyTicketMaster.Web.Components;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var httpClientBuilder = builder.Services.AddHttpClient<EventsClientFactory>(async (sp, httpClient) =>
{
    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
    var token = await httpContextAccessor.HttpContext!.GetTokenAsync("access_token");
    
    httpClient.BaseAddress = new Uri("https://localhost:7243");
    httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", token);
});
builder.Services.AddTransient(sp => sp.GetRequiredService<EventsClientFactory>().GetClient());

var authServerUrl = "http://localhost:8080/";
var realm = "MyTicketMaster";
var openIdConnectUrl = $"{authServerUrl}realms/{realm}/";
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme =
        CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =
        OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.SignInScheme = "Cookies";
    options.Authority = openIdConnectUrl;
    options.ClientId = "ticketing-pvt-client";
    options.ClientSecret = "oH5Xsgyz6RNwjXuUOtTeWCM46mcGNl4f";
    options.ResponseType = "code";
    options.UsePkce = true;
    options.SaveTokens = true;
    options.CallbackPath = "/signin-oidc";
    options.SignedOutCallbackPath = "/signout-callback-oidc";
    options.RequireHttpsMetadata = false;
    options.GetClaimsFromUserInfoEndpoint = true;
});

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub().RequireAuthorization();

app.Run();
