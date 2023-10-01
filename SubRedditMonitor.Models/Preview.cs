namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class Preview : IDebuggerDisplay
    {
        [JsonPropertyName("images")]
        public ICollection<Image> Images { get; set; } = new List<Image>();

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
