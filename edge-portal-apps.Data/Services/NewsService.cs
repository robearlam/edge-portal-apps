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
            var graphQLClient = new GraphQLHttpClient(Constants.ExperienceEdgeConnection.Url, new NewtonsoftJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("X-GQL-Token", Constants.ExperienceEdgeConnection.ApiKey);

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