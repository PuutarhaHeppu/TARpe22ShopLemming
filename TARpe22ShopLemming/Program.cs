using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using TARpe22ShopLemming.ApplicationServices.Services;
using TARpe22ShopLemming.Core.ServiceInterface;
using TARpe22ShopLemming.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TARpe22ShopLemmingContext>(OptionsBuilderConfigurationExtensions => OptionsBuilderConfigurationExtensions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
builder.Services.AddScoped<IFilesServices, FilesServices>();
builder.Services.AddScoped<IRealEstatesServices, RealEstatesServices>();
builder.Services.AddScoped<IWeatherForecastsServices, WeatherForecastsServices>();
builder.Services.AddScoped<IEmailService, EmailServices>();
builder.Services.AddScoped<ICarsServices, CarsServices>();

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