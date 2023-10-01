namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class Image : IDebuggerDisplay
    {
        [JsonPropertyName("source")]
        public Source Source { get; set; } = new Source();

        [JsonPropertyName("resolutions")]
        public ICollection<Resolution> Resolutions { get; set; } = new List<Resolution>();

        [JsonPropertyName("variants")]
        public object? Variants { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
