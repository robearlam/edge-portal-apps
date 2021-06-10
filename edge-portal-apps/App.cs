using edge_portal_apps;
using EdgePortalApps.Data.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.MobileBlazorBindings;
using Skclusive.Core.Component;
using Skclusive.Material.Component;
using Skclusive.Material.Core;
using Xamarin.Forms;

namespace EdgePortalApps
{
    public class App : Application
    {
        public App(IFileProvider fileProvider = null)
        {
            var hostBuilder = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Adds web-specific services such as NavigationManager
                    services.AddBlazorHybrid();

                    services.AddSingleton<IAnnouncementsService, AnnouncementsService>();
                    services.AddSingleton<INewsService, NewsService>();

                    services.TryAddMaterialServices
                        (
                            new MaterialConfigBuilder()
                            .WithIsServer(false)
                            .WithIsPreRendering(false)
                            .WithTheme(Theme.Light)
                            .WithDisableBinding(false)
                            .WithDisableConfigurer(false)
                            .Build()
                        );
                })
                .UseWebRoot("wwwroot");

            if (fileProvider != null)
            {
                hostBuilder.UseStaticFiles(fileProvider);
            }
            else
            {
                hostBuilder.UseStaticFiles();
            }
            var host = hostBuilder.Build();

            MainPage = new ContentPage { Title = "Edge Portal App" };
            host.AddComponent<Main>(parent: MainPage);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
