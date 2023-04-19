using Drafter.Data;
using Drafter.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

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
        seeder.Seed();
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