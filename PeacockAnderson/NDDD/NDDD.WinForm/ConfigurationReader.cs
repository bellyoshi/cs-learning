using Microsoft.Extensions.Configuration;
using NDDD.Domain;

namespace NDDD.WinForm
{
    internal class ConfigurationReader
    {
        public static void  Initialize()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            AppSettings.Default = configuration.Get<AppSettings>();
        }
            
    }
}
