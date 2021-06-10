using EdgePortalApps.Data.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Component;
using Skclusive.Material.Core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace edge_portal_apps.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<IAnnouncementsService, AnnouncementsService>();
            builder.Services.AddSingleton<INewsService, NewsService>();

            builder.Services.TryAddMaterialServices
                (
                    new MaterialConfigBuilder()
                    .WithIsServer(false)
                    .WithIsPreRendering(false)
                    .WithTheme(Theme.Light)
                    .WithDisableBinding(false)
                    .WithDisableConfigurer(false)
                    .Build()
                );

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
