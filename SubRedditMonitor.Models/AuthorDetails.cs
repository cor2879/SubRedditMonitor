namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class AuthorDetails : IDebuggerDisplay
    {
        public string Name { get; set; } = string.Empty;

        public int PostCount { get; set; }

        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
