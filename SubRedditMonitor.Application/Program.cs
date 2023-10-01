#pragma warning disable CS8618
namespace SubRedditMonitor.Application
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using SubRedditMonitor.Models;
    using SubRedditMonitor.Service.Interfaces;

    using color = System.ConsoleColor;
    using ConsoleX = ConsoleExtension;

    public class Program
    {
        private static int Interval;
        private static IRedditClient? RedditClient;
        private static IConfigurationSection Configuration;

        public async static Task Main(string[] args)
        {
            var applicationBuilder = Host.CreateApplicationBuilder(args);
            var startup = new Startup();

            startup.ConfigureServices(applicationBuilder.Services);
            var host = applicationBuilder.Build();
            Configuration = startup.Configuration.GetSection(nameof(RedditClientConfiguration));

            Interval = int.Parse(Configuration["Interval"] ?? "5000");


            using (var scope = host.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                Program.RedditClient = provider.GetRequiredService<IRedditClient>();
            }

            while (true)
            {
                try
                {
                    var details = await Program.RedditClient.GetSubRedditDetails();

                    if (details is { })
                    {
                        WriteTopTenSubRedditDetails(details);
                    }

                    var authors = await Program.RedditClient.GetTopTenSubRedditAuthorsAsync();

                    if (authors is { })
                    {
                        WriteTopTenSubRedditAuthors(authors);
                    }

                    Thread.Sleep(Interval);
                }
                catch (Exception ex)
                {
                    ConsoleX.WriteLine(color.Red, $"An unexpected error was encountered: {ex}");
                    ConsoleX.Pause();
                }
            }
        }

        public static void WriteTopTenSubRedditDetails(SubRedditDetails details)
        {
            if (details is { })
            {
                var data = details.Data.Children.First().Data;

                if (data is { })
                {
                    ConsoleX.WriteLine(color.White, $"*** Top Ten Upvoted Posts in Subreddit {Configuration["Subreddit"]} ***");
                    WriteSubRedditDetails(data);
                }

                foreach (var detail in details.Data.Children.Skip(1))
                {
                    if (detail.Data is { })
                    {
                        Console.WriteLine();
                        WriteSubRedditDetails(detail.Data);
                    }
                }
            }
        }

        public static void WriteTopTenSubRedditAuthors(IEnumerable<AuthorDetails> authors)
        {
            if (authors is { })
            {
                ConsoleX.WriteLine(color.White, $"*** Top Ten SubReddit Authors in Subreddit {Configuration["Subreddit"]} ***");

                foreach (var author in authors)
                {
                    ConsoleX.WriteLine(color.Yellow, $"Name: {author.Name} | Post Count: {author.PostCount}");
                }
            }
        }

        public static void WriteSubRedditDetails(T3Data data)
        {
            ConsoleX.WriteLine(color.Red, $"SubReddit Title: {data.Title}");
            ConsoleX.WriteLine(color.Blue, $"SubReddit Author: {data.Author}");
            ConsoleX.WriteLine(color.Green, $"SubReddit UpVotes: {data.Ups}");
        }
    }
}
