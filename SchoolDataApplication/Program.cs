using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SchoolDataApplication.Data;
using Services.Validators;
using Services.Interfaces;
using Services.Implementations;
using FluentValidation;
using Services.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add configurations
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;

    config.SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //load base settings
            .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true) //load local settings
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true) //load environment settings
            .AddEnvironmentVariables();
});

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<UserValidator>();
    options.DisableDataAnnotationsValidation = true;
});

//DI for for DbContext
builder.Services.AddDbContext<SchoolDataApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")).EnableSensitiveDataLogging());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
