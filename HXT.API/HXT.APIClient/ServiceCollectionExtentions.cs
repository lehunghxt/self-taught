using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace HXT.APIClient
{
    public static class ServiceCollectionExtentions
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            using var scoped = services.BuildServiceProvider().CreateScope();
            var globalAppSetting = scoped.ServiceProvider.GetService<IOptions<GlobalAppSetting>>().Value;
            if (globalAppSetting == null)
            {
                throw new InvalidOperationException($"{nameof(GlobalAppSetting)} not found");
            }
            var httpClients = globalAppSetting.HttpClientSetting;

            PropertyInfo[] properties = typeof(HttpClientSetting).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var clientName = property.Name;
                var clientHost = httpClients.GetType().GetProperty(property.Name).GetValue(httpClients, null)?.ToString();
                if (Uri.IsWellFormedUriString(clientHost, UriKind.Absolute))
                {
                    services.AddHttpClient(clientName, client =>
                    {
                        client.BaseAddress = new Uri(clientHost);
                    });
                }
            }
        }
    }
}
