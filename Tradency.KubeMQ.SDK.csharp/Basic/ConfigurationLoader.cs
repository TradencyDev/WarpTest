using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;

namespace Tradency.KubeMQ.SDK.csharp.Basic
{
    internal class ConfigurationLoader
    {
        private static string _path = null;

        internal static string GetServerAddress()
        {
            if (!string.IsNullOrWhiteSpace(_path)) return _path;

            _path = GetFromEnvironmentVariable();

            if (!string.IsNullOrWhiteSpace(_path)) return _path;

            _path = GetFromJson();

            if (!string.IsNullOrWhiteSpace(_path)) return _path;

            _path = GetFromAppConfig();

            return _path;
        }

        private static string GetFromEnvironmentVariable()
        {
            string serverAddress = Environment.GetEnvironmentVariable("KubeMQServerAddress");// returns null if not found.

            return serverAddress;
        }

        private static string GetFromJson()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", true);
            var configuration = builder.Build();


            string serverAddress = configuration["KubeMQ:serverAddress"];// returns null if not found.

            return serverAddress;
        }

        private static string GetFromAppConfig()
        {
            string serverAddress = null;

            var KubeMQSettings = ConfigurationManager.GetSection("KubeMQ") as NameValueCollection;
            if (KubeMQSettings?.Count > 0)
            {
                serverAddress = KubeMQSettings["serverAddress"];
            }

            return serverAddress;
        }
    }
}
