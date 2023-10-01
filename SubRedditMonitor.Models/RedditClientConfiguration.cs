namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class RedditClientConfiguration : IDebuggerDisplay
    {
        public const int MaxRequestsPerMinute = 100;

        public string? Secret { get; set; }

        public string? ClientId { get; set; }

        public string? UserAgent { get; set; }

        public string? Subreddit { get; set; }

        public int RequestsPerMinute { get; set; }

        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
