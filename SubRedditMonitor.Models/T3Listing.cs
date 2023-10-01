namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class T3Listing : IDebuggerDisplay
    {
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("data")]
        public T3Data? Data { get; set; }

        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
