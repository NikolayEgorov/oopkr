using Interfaces;
using Repositories;
using Pomelo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("cookie")
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
builder.Services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("MariaDbConnectionString");

// builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connection));
builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseMySql(connection, new MySqlServerVersion(new Version(10, 11, 3))));

builder.Services.AddTransient<ILog, LogRepository>();
builder.Services.AddTransient<IUsers, UserRepository>();
builder.Services.AddTransient<IBollers, BollerRepository>();
builder.Services.AddTransient<IPlants, PlantRepository>();
builder.Services.AddTransient<IPlantsBollers, PlantBollerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UsePathBase(app.Environment.ContentRootPath);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();