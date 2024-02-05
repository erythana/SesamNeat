using RTLSDRWaterfall.Blazor;
using CC1101.NET;
using CC1101.NET.Interfaces;
using SesamNeat.Blazor.Components;
using SesamNeat.Blazor.Helper;

namespace SesamNeat.Blazor;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionConfiguration = new CC1101Controller(new ConnectionConfiguration());

        // Add services to the container.
        builder.Services
            // .AddSingleton<ICC1101>(_ => connectionConfiguration.Initialize(Application.InitialDeviceAddress))
            .AddScoped(typeof(ShutdownHelper))
            .AddScoped(typeof(WaterfallInterop))
            .AddRazorComponents()
            .AddInteractiveServerComponents();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}