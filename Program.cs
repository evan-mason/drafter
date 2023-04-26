using Drafter.Data;
using Drafter.Data.Entities;
using Drafter.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot _config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .Build();

builder.Services.AddIdentity<DrafterUser, IdentityRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
    //cfg.Password.  for password rules
})
    .AddEntityFrameworkStores<DrafterContext>();

builder.Services.AddAuthentication()
    .AddCookie()
    .AddJwtBearer(cfg =>
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = _config["Token:Issuer"],
        ValidAudience = _config["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]))
    });

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IMailService, NullMailService>();
builder.Services.AddDbContext<DrafterContext>();
builder.Services.AddTransient<DrafterSeeder>();
builder.Services.AddScoped<IDrafterRepository, DrafterRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
}
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(cfg =>
{
    cfg.MapRazorPages();

    cfg.MapControllerRoute("Default",
        "/{controller}/{action}/{id?}",
        new { controller = "App", action = "Index" });
});

if (args.Length == 1){
    if (args[0].ToLower() == "/seed")
    {
        RunSeeding(app);
    }
    else if (args[0].ToLower() == "/destroy")
    {
        RunDestroy(app);
    }
}

else
{
    app.Run();
}

static void RunSeeding(WebApplication app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<DrafterSeeder>();
        seeder.Seed().Wait();
    }
}

static void RunDestroy(WebApplication app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<DrafterSeeder>();
        seeder.Destroy();
    }
}