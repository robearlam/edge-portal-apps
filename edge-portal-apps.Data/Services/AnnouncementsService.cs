using EdgePortalApps.Data.Models;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdgePortalApps.Data.Services
{
    public class AnnouncementsService : IAnnouncementsService
    {
        public async Task<List<Announcement>> GetTopAnnouncements(int count=3)
        {
            var graphQLClient = new GraphQLHttpClient(Constants.ExperienceEdgeConnection.Url, new NewtonsoftJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("X-GQL-Token", Constants.ExperienceEdgeConnection.ApiKey);

            var announcemenetsRequest = new GraphQLRequest
            {
                Query = @"
               {
                AnnouncementResults: allM_Content_d6261 {
                  results {
                    Title: d6261_Title
                    Description: d6261_Description
                    Url: announcementURL
                    HasUrl: hasURL
                    Id: id
                  }
                }
              }"
            };

            var response = await graphQLClient.SendQueryAsync<AnnouncementsRepsonse>(announcemenetsRequest);
            return response.Data.AnnouncementsContent.Results;
        }
    }
}