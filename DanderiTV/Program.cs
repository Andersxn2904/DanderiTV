using FluentMigrator.Runner;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DanderiTV.Layer.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IServiceProvider, ServiceProvider>();
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer2012()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("ConnetionMaster"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
var app = builder.Build();

var serviceProvider = app.Services;



using (var scope = serviceProvider.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;

    try
    {
       
    }
    catch (Exception ex)
    {

    }
}

//public static IServiceProvider CreateServices()
//{
//    return app.Services
//        .AddFluentMigratorCore()
//        .ConfigureRunner(rb => rb
//            .AddDapper()
//            .WithGlobalConnectionString("tu_cadena_de_conexion")
//            .ScanIn(typeof(Program).Assembly).For.Migrations())
//        .AddLogging(lb => lb.AddFluentMigratorConsole())
//        .BuildServiceProvider(false);
//}


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
