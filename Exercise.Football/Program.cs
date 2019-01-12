using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Exercise.Football.Services;
using Exercise.Football.Services.Interface;
using Serilog;

namespace Exercise.Football
{
    //code review, testing
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Create service collection
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            // Create service provider
            ServiceProvider provider = services.BuildServiceProvider();

            // entry to run app
            provider.GetService<App>().Run(args.First());
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IValidator, Validator>();
            serviceCollection.AddTransient<IMapper, ModelMapper>();
            serviceCollection.AddTransient<App>();
            serviceCollection.AddSingleton(BuildLogger());
        }

        private static ILogger BuildLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
                