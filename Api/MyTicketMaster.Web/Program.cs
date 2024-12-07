using Microsoft.Kiota.Http.HttpClientLibrary;
using MyTicketMaster.Web.Clients;
using MyTicketMaster.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//var kiotaHandlers = KiotaClientFactory.GetDefaultHandlerTypes();
//// And register them in the DI container
//foreach (var handler in kiotaHandlers)
//{
//    builder.Services.AddTransient(handler);
//}

var httpClientBuilder = builder.Services.AddHttpClient<EventsClientFactory>((sp, httpClient) =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7243/api/v1/");
});
//var kiotaHandlers2 = KiotaClientFactory.GetDefaultHandlerTypes();
//// And attach them to the http client builder
//foreach (var handler in kiotaHandlers2)
//{
//    httpClientBuilder.AddHttpMessageHandler((sp) => (DelegatingHandler)sp.GetRequiredService(handler));
//}

//builder.Services.AddTransient(sp => sp.GetRequiredService<EventsClientFactory>().GetClient());

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

app.Run();
