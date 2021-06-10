using EdgePortalApps.Data.Models;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdgePortalApps.Data.Services
{
    public class NewsService : INewsService
    {
        public async Task<List<NewsArticle>> GetTopNewsArticles(int count = 4)
        {
            var graphQLClient = new GraphQLHttpClient("<<EXPERIENCE_EDGE_URL>>", new NewtonsoftJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("X-GQL-Token", "<<EXPERIENCE_EDGE_API_KEY>>");

            var newsArticlesRequest = new GraphQLRequest
            {
                Query = @"
                   {
                    Blogposts: allM_Content_Blog {
                      results {
                        Title: blog_Title
                        Abstract: blog_Abstract
                        Body: blog_Body
                        Id: id
                        PublishDate: content_PublishedOn
                      }
                    }
                  }"
            };

            var response = await graphQLClient.SendQueryAsync<NewsArticleResponse>(newsArticlesRequest);
            return response.Data.NewsArticles.Results;
        }
    }
}