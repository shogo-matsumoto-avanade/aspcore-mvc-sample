using Microsoft.EntityFrameworkCore;
using Matsu.CoreSample.Web.Settings;
using Matsu.CoreSamples.SqlDatabaseInfrastructure.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabaseContext") ?? throw new InvalidOperationException("Connection string 'MyDatabaseContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.InjectCustomDependency(builder.Configuration.GetValue<string>("DependencyInjection"));

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
