using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NaniWeb.Data
{
    public class NaniDbFactory : IDesignTimeDbContextFactory<NaniDb>
    {
        public NaniDb CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile($"{Utilities.CurrentDirectory}{Path.DirectorySeparatorChar}Settings.json").Build();
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"Host={configuration.GetValue<string>("Database:Host")};");
            stringBuilder.Append($"Database={configuration.GetValue<string>("Database:DBName")};");
            stringBuilder.Append($"Username={configuration.GetValue<string>("Database:Username")};");
            stringBuilder.Append($"Password={configuration.GetValue<string>("Database:Password")}");

            return new NaniDb(new DbContextOptionsBuilder().UseNpgsql(stringBuilder.ToString()).Options);
        }
    }
}