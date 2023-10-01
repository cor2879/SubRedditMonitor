namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class SubRedditDetails: IDebuggerDisplay
    {
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("data")]
        public SubRedditData Data { get; set; } = new SubRedditData();

        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
