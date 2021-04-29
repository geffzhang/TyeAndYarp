using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReverseProxy
{
    public static class YarpBuilderExtensions
    {
        public static IConfigurationBuilder AddDaprConfig(this IConfigurationBuilder configurationBuilder)
        {
            var httpEndpoint = DaprDefaults.GetDefaultHttpEndpoint(); //参考Dapr.Client，获取到dapr-sidecar的url
            return configurationBuilder.AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("Yarp:Clusters:dapr-sidecar:Destinations:d1:Address", httpEndpoint),
            });
        }
    }
}
