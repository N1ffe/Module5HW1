using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module5HW1.Config;
using Module5HW1.Services;
using Module5HW1.Services.Abstractions;

namespace Module5HW1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(Path.Combine(configPath, "config.json")).Build();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOptions<ApiOption>().Bind(configuration.GetSection("Api"));
            serviceCollection
                .AddLogging(configure => configure.AddConsole())
                .AddHttpClient()
                .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IEmployeeService, EmployeeService>()
                .AddTransient<App>();
            var provider = serviceCollection.BuildServiceProvider();
            var app = provider.GetService<App>();
            await app!.Start();
        }
    }
}