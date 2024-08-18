using System.Configuration;
using matikApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
.SetBasePath(builder.Environment.ContentRootPath)
.AddJsonFile("appsettings.json")
.Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<matikdbContext>();
var connectionString = configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));


builder.Services.AddDbContext<matikdbContext>(options =>
options.UseMySql(connectionString, serverVersion,
mysqlOptions => mysqlOptions.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorNumbersToAdd: null)));


//Add cross origin
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin(); // Allow requests from any origin
    });
});


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
app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PartialHome}/{action=HomeIndex}/{id?}");

//app.Run("https://192.168.103.150:7272");
app.Run();