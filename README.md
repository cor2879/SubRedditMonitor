# SubRedditMonitor
Monitors a specified Subreddit to report the Posts with the most up votes and the users with the most posts

To execute, build and run the 'SubRedditMonitor.Application' project.  All Reddit API configurable values are stored
in ./SubRedditMonitor.Application/appsettings.json.

As currently configured, The application will send a request to the the SubReddit api to retrieve the top ten posts
with the most upvotes, as well as the top 10 users with the most posts in that SubReddit (with a count of the number
of posts).  The Console application displays the details as they are retrieved.

There is also a Unit Test project which tests some of the functionality of the RedditClient implementation.
