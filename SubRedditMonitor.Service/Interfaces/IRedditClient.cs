namespace SubRedditMonitor.Service.Interfaces
{
    using System.Threading.Tasks;

    using SubRedditMonitor.Models;

    public interface IRedditClient
    {
        Task<SubRedditDetails?> GetSubRedditDetails(string? subReddit = null);

        Task<IEnumerable<AuthorDetails>> GetTopTenSubRedditAuthorsAsync(string? subReddit = null);
    }
}
