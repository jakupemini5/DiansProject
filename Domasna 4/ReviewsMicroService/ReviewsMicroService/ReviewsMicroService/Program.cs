using Microsoft.EntityFrameworkCore;
using ReviewsMicroService.BLL.Services.Implementations;
using ReviewsMicroService.BLL.Services.Interfaces;
using ReviewsMicroService.DAL.Data;
using ReviewsMicroService.DAL.Repositories.Implementations;
using ReviewsMicroService.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true,
                    true)
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionStrings"]));

//repositories
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
//services
builder.Services.AddTransient<IReviewService, ReviewService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
