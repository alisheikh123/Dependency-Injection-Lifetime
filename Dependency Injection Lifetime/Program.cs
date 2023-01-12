using Dependency_Injection_Lifetime.Controllers.Service;
using Dependency_Injection_Lifetime.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITransientInterface,OperationService>(); // Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services.
builder.Services.AddScoped<IScopeInterface,OperationService>(); // Scoped lifetime services are created once per request.
builder.Services.AddSingleton<ISingletonInterface,OperationService>(); // Singleton lifetime services are created the first time they are requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the same instance.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
