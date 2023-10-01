namespace SubRedditMonitor.Service.Implementation
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Options;

    using SubRedditMonitor.Models;
    using SubRedditMonitor.Service.Interfaces;

    public class RedditClient : IRedditClient
    {
        public RedditClient(
            IHttpClientFactory httpClientFactory,
            IOptions<RedditClientConfiguration> configuration)
        {
            this.HttpClientFactory = httpClientFactory;
            this.Configuration = configuration.Value;
        }

        private IHttpClientFactory HttpClientFactory { get; set; }

        public RedditClientConfiguration Configuration { get; private set; }

        public async Task<SubRedditDetails?> GetSubRedditDetails(string? subReddit = null)
        {
            using (var httpClient = this.HttpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", this.Configuration.UserAgent);

                var apiUrl = $"https://www.reddit.com/r/{subReddit ?? Configuration.Subreddit}/top.json?limit=10";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<SubRedditDetails>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new HttpRequestException(response.ToString());
                }

                return null;
            }
        }

        public async Task<IEnumerable<AuthorDetails>> GetTopTenSubRedditAuthorsAsync(string? subReddit = null)
        {
            using (var httpClient = this.HttpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", this.Configuration.UserAgent);

                var apiUrl = $"https://www.reddit.com/r/{subReddit ?? Configuration.Subreddit}/new.json?limit=100";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var details = JsonSerializer.Deserialize<SubRedditDetails>(await response.Content.ReadAsStringAsync());

                    if (details is { })
                    {
                        return CountSubRedditAuthors(details);
                    }
                }
                else
                {
                    throw new HttpRequestException(response.ToString());
                }

                return new List<AuthorDetails>();
            }
        }

        private static IEnumerable<AuthorDetails> CountSubRedditAuthors(SubRedditDetails details)
        {
            var dictionary = new Dictionary<string, AuthorDetails>();

            foreach (var listing in details.Data.Children)
            {
                if (listing.Data?.Author != null)
                {
                    if (dictionary.ContainsKey(listing.Data.Author))
                    {
                        dictionary[listing.Data.Author].PostCount++;
                    }
                    else
                    {
                        dictionary.Add(
                            listing.Data.Author,
                            new AuthorDetails
                            {
                                Name = listing.Data?.Author ?? string.Empty,
                                PostCount = 1
                            });
                    }
                }
            }

            return dictionary.Values.OrderByDescending(a => a.PostCount).ToList().Take(10);
        }
    }
}