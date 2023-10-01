namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class LinkFlairRichtext : IDebuggerDisplay
    {
        [JsonPropertyName("e")]
        public string? E { get; set; }

        [JsonPropertyName("t")]
        public string? T { get; set; }

        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
