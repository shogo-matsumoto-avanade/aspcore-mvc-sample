using Microsoft.EntityFrameworkCore;
using Matsu.CoreSample.Web.Settings;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.Extensions.Logging.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection
var injectionType = builder.Configuration.GetValue<string>("DependencyInjection");
var diType = DIHelper.GetServiceInjectionType(injectionType);
builder.Services.InjectServiceRepositoryDependency(diType);
builder.Services.InjectDatabaseDependency(
        diType, 
        builder.Configuration.GetConnectionString("MyDatabaseContext") ?? throw new InvalidOperationException("Connection string 'MyDatabaseContext' not found."));
//Configure logger
var loggerEnvironment = builder.Configuration.GetValue<string>("LoggerInjection");
var env = DIHelper.GetLoggerInjectionType(loggerEnvironment);
builder.Services.InjectLoggerDependency(env);

var app = builder.Build();
// Configure Context
app.Services.ConfigureCustomContext(diType);

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
