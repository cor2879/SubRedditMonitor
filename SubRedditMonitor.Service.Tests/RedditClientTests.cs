#pragma warning disable CS8618
namespace SubRedditMonitor.Tests
{
    using System.Net;
    using System.Text;
    using System.Text.Json;

    using Microsoft.Extensions.Options;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;

    using SubRedditMonitor.Models;
    using SubRedditMonitor.Service.Implementation;

    [TestClass]
    public class RedditClientTests
    {
        private Mock<IHttpClientFactory> httpClientFactoryMock;
        private RedditClient redditClient;

        [TestInitialize]
        public void Initialize()
        {
            this.httpClientFactoryMock = new Mock<IHttpClientFactory>();
            this.redditClient = new RedditClient(this.httpClientFactoryMock.Object, Options.Create(new RedditClientConfiguration
            {
                UserAgent = "TestUserAgent",
                Subreddit = "testsubreddit"
            }));
        }

        [TestMethod]
        public async Task GetSubRedditDetails_Success()
        {
            var expectedSubRedditDetails = new SubRedditDetails { Kind = "TestKind" };
            var httpClient = CreateHttpClient(HttpStatusCode.OK, JsonSerializer.Serialize(expectedSubRedditDetails));
            this.httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var result = await redditClient.GetSubRedditDetails();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedSubRedditDetails.Kind, result.Kind);
        }

        [TestMethod]
        public async Task GetSubRedditDetails_Error()
        {
            var httpClient = CreateHttpClient(HttpStatusCode.InternalServerError, "Internal Server Error");
            this.httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(httpClient);

            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => redditClient.GetSubRedditDetails());
        }

        [TestMethod]
        public async Task GetTopTenSubRedditAuthorsAsync_Success()
        {
            var expectedSubRedditDetails = new SubRedditDetails 
            { 
                Kind = "TestKind",  
                Data = new SubRedditData
                {
                    Children = new List<T3Listing>
                    {
                        new T3Listing
                        {
                            Data = new T3Data
                            {
                                Author = "Ned"
                            }
                        },
                        new T3Listing
                        {
                            Data = new T3Data
                            {
                                Author = "Ned"
                            }
                        },
                        new T3Listing
                        {
                            Data = new T3Data
                            {
                                Author = "Fred"
                            }
                        },
                        new T3Listing
                        {
                            Data = new T3Data
                            {
                                Author = "Ned"
                            }
                        }
                    }
                }
            };

            var httpClient = CreateHttpClient(HttpStatusCode.OK, JsonSerializer.Serialize(expectedSubRedditDetails));
            this.httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var result = await this.redditClient.GetTopTenSubRedditAuthorsAsync();

            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public async Task GetTopTenSubRedditAuthorsAsync_Error()
        {
            var httpClient = CreateHttpClient(HttpStatusCode.InternalServerError, "Internal Server Error");
            httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(httpClient);

            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => redditClient.GetTopTenSubRedditAuthorsAsync());
        }

        private HttpClient CreateHttpClient(HttpStatusCode statusCode, string content)
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });

            return new HttpClient(handlerMock.Object);
        }
    }
}
