using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace NaniWeb
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder().ConfigureWebHostDefaults(builder =>
            {
                builder.ConfigureAppConfiguration(configurationBuilder => configurationBuilder.AddJsonFile($"{Utilities.CurrentDirectory}{Path.DirectorySeparatorChar}Settings.json"));

                builder.ConfigureKestrel((context, options) => options.Listen(IPAddress.Parse(context.Configuration.GetValue<string>("Application:IP")),
                    context.Configuration.GetValue<int>("Application:Port"), listenOptions => listenOptions.Protocols = HttpProtocols.Http1));

                builder.UseContentRoot(Utilities.CurrentDirectory.ToString());
                builder.UseWebRoot($"{Utilities.CurrentDirectory}{Path.DirectorySeparatorChar}Content");
                builder.UseStartup<Startup>();
            }).Build().Run();
        }
    }
}