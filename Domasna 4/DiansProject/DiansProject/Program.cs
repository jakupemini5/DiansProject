using DiansProject.BLL.Services.Implementations;
using DiansProject.BLL.Services.Interfaces;
using DiansProject.DAL.Data;
using DiansProject.DAL.Repositories.Implementations;
using DiansProject.DAL.Repositories.Interfaces;
using DiansProject.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

var adsff = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true,
                    true)
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionStrings"]));
builder.Services.AddControllersWithViews();

//repositories
builder.Services.AddTransient<IFeatureRepository, FeatureRepository>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();


//services
builder.Services.AddTransient<IFeatureService, FeatureService>();
builder.Services.AddTransient<IReviewService, ReviewService>();

var cosmosConfig = new ReviewsMicroServiceConfiguration();
Configuration.Bind("ReviewsMicroServiceConfiguration", cosmosConfig);
builder.Services.AddSingleton(cosmosConfig);



var app = builder.Build();

DatabaseSeeder.Seed(app.Services);
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
    pattern: "{controller=Features}/{action=Index}/{id?}");

app.Run();
