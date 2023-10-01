namespace SubRedditMonitor.Application
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using SubRedditMonitor.Models;
    using SubRedditMonitor.Service.Implementation;
    using SubRedditMonitor.Service.Interfaces;

    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddOptions();
            services.AddSingleton(this.Configuration);
            services.AddScoped<IRedditClient, RedditClient>();
            services.Configure<RedditClientConfiguration>(Configuration.GetSection(nameof(RedditClientConfiguration)));
        }
    }
}