using System;
using System.Linq;
using System.Net.Http;
using TechnologyCharacterGenerator.Child.Common.BusinessLogic;
using TechnologyCharacterGenerator.Child.Common.Diagnostics;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter;

namespace TechnologyCharacterGenerator.Child.Common
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);

                builder.Services.TryAddEnumerable(ServiceDescriptor
                    .Singleton<ILoggerProvider, BrowserConsoleLoggerProvider>());
            });

            services.AddScoped<ITechnologyCharacterCreator, TechnologyCharacterCreator>();

            services.AddTechnologyCharacterPropertyGenerators();

            services.AddScoped<IUserViewModelUpdateReceiver, UserViewModelUpdateReceiver>();

            services.AddScoped<IApplicationNameProvider, ApplicationNameProvider>();
            services.AddScoped<IStatusReportSender, StatusReportSender>();

            // Server Side Blazor doesn't register HttpClient by default
            if (!services.Any(x => x.ServiceType == typeof(HttpClient)))
            {
                // Setup HttpClient for server side in a client side compatible fashion
                services.AddScoped<HttpClient>(s =>
                {
                    // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.
                    var uriHelper = s.GetRequiredService<IUriHelper>();
                    return new HttpClient
                    {
                        BaseAddress = new Uri(uriHelper.GetBaseUri())
                    };
                });
            }
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
