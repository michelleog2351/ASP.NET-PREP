using BlazorApp2.Components;

// Calling the CreateBuilder() to create a web application
// We are going to use the builder to create a Blazor app
var builder = WebApplication.CreateBuilder(args);

// Add services to the container (available through dependecy injection throughout the app)
// NB!! Dependency injection is a technique whereby an object receives other objects it depends on, called dependencies, rather than creating them itself
// These services are needed by Blazor to be able to render Blazor components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Building the app instance...
var app = builder.Build();

// setup the middleware required...
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Calling MapRazorComponents<App>()
// The configuration of Blozor so that the routable Blazor components are setup as endpoints in the Blazor app
// Here we are specifying the root component for our app component (defined in the app)
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Run the application
app.Run();
