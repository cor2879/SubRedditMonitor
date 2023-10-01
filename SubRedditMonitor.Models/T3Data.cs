namespace SubRedditMonitor.Models
{
    using System.Diagnostics;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using SubRedditMonitor.Models.Interfaces;

    [DebuggerDisplay("{DebuggerDisplay()}")]
    public class T3Data : IDebuggerDisplay
    {
        [JsonPropertyName("approved_at_utc")]
        public decimal? ApprovedAtUtc { get; set; }

        [JsonPropertyName("subreddit")]
        public string? Subreddit { get; set; }

        [JsonPropertyName("selftext")]
        public string? SelfText { get; set; }

        [JsonPropertyName("author_fullname")]
        public string? AuthorFullname { get; set; }

        [JsonPropertyName("saved")]
        public bool Saved { get; set; }

        [JsonPropertyName("mod_reason_title")]
        public string? ModReasonTitle { get; set; }

        [JsonPropertyName("gilded")]
        public int Gilded { get; set; }

        [JsonPropertyName("clicked")]
        public bool Clicked { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("link_flair_richtext")]
        public List<LinkFlairRichtext> LinkFlairRichtext { get; set; } = new List<LinkFlairRichtext>();

        [JsonPropertyName("subreddit_name_prefixed")]
        public string? SubredditNamePrefixed { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [JsonPropertyName("pwls")]
        public int Pwls { get; set; }

        [JsonPropertyName("link_flair_css_class")]
        public string? LinkFlairCssClass { get; set; }

        [JsonPropertyName("downs")]
        public int Downs { get; set; }

        [JsonPropertyName("thumbnail_height")]
        public int? ThumbnailHeight { get; set; }

        [JsonPropertyName("top_awarded_type")]
        public string? TopAwardedType { get; set; }

        [JsonPropertyName("hide_score")]
        public bool HideScore { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("quarantine")]
        public bool Quarantine { get; set; }

        [JsonPropertyName("link_flair_text_color")]
        public string? LinkFlairTextColor { get; set; }

        [JsonPropertyName("upvote_ratio")]
        public decimal UpvoteRatio { get; set; }

        [JsonPropertyName("author_flair_background_color")]
        public string? AuthorFlairBackgroundColor { get; set; }

        [JsonPropertyName("ups")]
        public int Ups { get; set; }

        [JsonPropertyName("total_awards_received")]
        public int TotalAwardsReceived { get; set; }

        [JsonPropertyName("media_embed")]
        public object? MediaEmbed { get; set; }

        [JsonPropertyName("thumbnail_width")]
        public int? ThumbnailWidth { get; set; }

        [JsonPropertyName("author_flair_template_id")]
        public string? AuthorFlairTemplateId { get; set; }

        [JsonPropertyName("is_original_content")]
        public bool IsOriginalContent { get; set; }

        [JsonPropertyName("user_reports")]
        public ICollection<object> UserReports { get; set; } = new List<object>();

        [JsonPropertyName("secure_media")]
        public SecureMedia? SecureMedia { get; set; }

        [JsonPropertyName("is_reddit_media_domain")]
        public bool IsRedditMediaDomain { get; set; }

        [JsonPropertyName("is_meta")]
        public bool IsMeta { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("secure_media_embed")]
        public object? SecureMediaEmbed { get; set; }

        [JsonPropertyName("link_flair_text")]
        public string? LinkFlairText { get; set; }

        [JsonPropertyName("can_mod_post")]
        public bool CanModPost { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("approved_by")]
        public string? ApprovedBy { get; set; }

        [JsonPropertyName("is_created_from_ads_ui")]
        public bool IsCreatedFromAdsUi { get; set; }

        [JsonPropertyName("author_premium")]
        public bool AuthorPremium { get; set; }

        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }

        [JsonPropertyName("author_flair_css_class")]
        public string? AuthorFlairCssClass { get; set; }

        [JsonPropertyName("author_flair_richtext")]
        public ICollection<object> AuthorFlairRichtext { get; set; } = new List<object>();

        [JsonPropertyName("gildings")]
        public Dictionary<string, int> Gildings { get; set; } = new Dictionary<string, int>();

        [JsonPropertyName("post_hint")]
        public string? PostHint { get; set; }

        [JsonPropertyName("content_categories")]
        public ICollection<string> ContentCategories { get; set; } = new List<string>();

        [JsonPropertyName("is_self")]
        public bool IsSelf { get; set; }

        [JsonPropertyName("subreddit_type")]
        public string? SubRedditType { get; set; }

        [JsonPropertyName("created")]
        public decimal? Created { get; set; }

        [JsonPropertyName("link_flair_type")]
        public string? LinkFlairType { get; set; }

        [JsonPropertyName("wls")]
        public int Wls { get; set; }

        [JsonPropertyName("removed_by_category")]
        public string? RemovedByCategory { get; set; }

        [JsonPropertyName("banned_by")]
        public string? BannedBy { get; set; }

        [JsonPropertyName("author_flair_type")]
        public string? AuthorFlairType { get; set; }

        [JsonPropertyName("domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("allow_live_comments")]
        public bool? AllowLiveComments { get; set; }

        [JsonPropertyName("selftext_html")]
        public string? SelftextHtml { get; set; }

        [JsonPropertyName("likes")]
        public int? Likes { get; set; }

        [JsonPropertyName("suggested_sort")]
        public string? SuggestedSort { get; set; }

        [JsonPropertyName("banned_at_utc")]
        public decimal? BannedAtUtc { get; set; }

        [JsonPropertyName("url_overridden_by_dest")]
        public string? UrlOverriddenByDest { get; set; }

        [JsonPropertyName("view_count")]
        public int? ViewCount { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("no_follow")]
        public bool NoFollow { get; set; }

        [JsonPropertyName("is_crosspostable")]
        public bool IsCrosspostable { get; set; }

        [JsonPropertyName("pinned")]
        public bool Pinned { get; set; }

        [JsonPropertyName("over_18")]
        public bool Over18 { get; set; }

        [JsonPropertyName("preview")]
        public Preview Preview { get; set; } = new Preview();

        [JsonPropertyName("all_awardings")]
        public ICollection<object> AllAwardings { get; set; } = new List<object>();

        [JsonPropertyName("awarders")]
        public ICollection<object> Awarders { get; set; } = new List<object>();

        [JsonPropertyName("media_only")]
        public bool MediaOnly { get; set; }

        [JsonPropertyName("link_flair_template_id")]
        public string? LinkFlairTemplateId { get; set; }

        [JsonPropertyName("can_gild")]
        public bool CanGild { get; set; }

        [JsonPropertyName("spoiler")]
        public bool Spoiler { get; set; }

        [JsonPropertyName("locked")]
        public bool Locked { get; set; }

        [JsonPropertyName("author_flair_text")]
        public string? AuthorFlairText { get; set; }

        [JsonPropertyName("treatment_tags")]
        public ICollection<object> TreatmentTags { get; set; } = new List<object>();

        [JsonPropertyName("visited")]
        public bool Visited { get; set; }

        [JsonPropertyName("removed_by")]
        public string? RemovedBy { get; set; }

        [JsonPropertyName("mod_note")]
        public string? ModNote { get; set; }

        [JsonPropertyName("distinguished")]
        public string? Distinguished { get; set; }

        [JsonPropertyName("subreddit_id")]
        public string? SubredditId { get; set; }

        [JsonPropertyName("author_is_blocked")]
        public bool AuthorIsBlocked { get; set; }

        [JsonPropertyName("mod_reason_by")]
        public string? ModReasonBy { get; set; }

        [JsonPropertyName("num_reports")]
        public string? NumReports { get; set; }

        [JsonPropertyName("removal_reason")]
        public string? RemovalReason { get; set; }

        [JsonPropertyName("link_flair_background_color")]
        public string? LinkFlairBackgroundColor { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("is_robot_indexable")]
        public bool IsRobotIndexable { get; set; }

        [JsonPropertyName("report_reasons")]
        public string? ReportReasons { get; set; }

        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [JsonPropertyName("discussion_type")]
        public string? DiscussionType { get; set; }

        [JsonPropertyName("num_comments")]
        public int NumComments { get; set; }

        [JsonPropertyName("send_replies")]
        public bool SendReplies { get; set; }

        [JsonPropertyName("whitelist_status")]
        public string? WhitelistStatus { get; set; }

        [JsonPropertyName("contest_mode")]
        public bool ContestMode { get; set; }

        [JsonPropertyName("mod_reports")]
        public ICollection<object> ModReports { get; set; } = new List<object>();

        [JsonPropertyName("author_patreon_flair")]
        public bool AuthorPatreonFlair { get; set; }

        [JsonPropertyName("author_flair_text_color")]
        public string? AuthorFlairTextColor { get; set; }

        [JsonPropertyName("permalink")]
        public string? Permalink { get; set; }

        [JsonPropertyName("parent_whitelist_status")]
        public string? ParentWhitelistStatus { get; set; }

        [JsonPropertyName("stickied")]
        public bool Stickied { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("subreddit_subscribers")]
        public int SubredditSubscribers { get; set; }

        [JsonPropertyName("created_utc")]
        public decimal? CreatedUtc { get; set; }

        [JsonPropertyName("num_crossposts")]
        public int NumCrossposts { get; set; }

        [JsonPropertyName("media")]
        public object? Media { get; set; }

        [JsonPropertyName("is_video")]
        public bool IsVideo { get; set; }
        public string DebuggerDisplay()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}