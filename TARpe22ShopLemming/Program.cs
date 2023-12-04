using Microsoft.EntityFrameworkCore;
using TARpe22ShopLemming.ApplicationServices.Services;
using TARpe22ShopLemming.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TARpe22ShopLemmingContext>(OptionsBuilderConfigurationExtensions => OptionsBuilderConfigurationExtensions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
<<<<<<< Updated upstream
builder.Services.AddScoped<ISpaceshipservices, SpaceshipsServices>();
=======
builder.Services.AddScoped<ISpaceshipsServices, SpaceshipsServices>();
builder.Services.AddScoped<IFilesServices, FilesServices>();
builder.Services.AddScoped<IRealEstatesServices, RealEstatesServices>();
builder.Services.AddScoped<IWeatherForecastsServices, WeatherForecastServices>();
builder.Services.AddScoped<ICarsServices, CarsServices>();
//builder.Services.AddScoped<IEmailService, EmailService>();

>>>>>>> Stashed changes
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

app.MapRazorPages();

app.Run();
