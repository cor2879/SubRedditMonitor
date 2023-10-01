namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class SecureMedia : IDebuggerDisplay
    {
        [JsonPropertyName("reddit_video")]
        public RedditVideo? RedditVideo { get; set; }

        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
