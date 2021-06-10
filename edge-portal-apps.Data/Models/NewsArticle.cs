using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EdgePortalApps.Data.Models
{
    public class NewsArticle
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Abstract")]
        public string Abstract { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        //[JsonProperty("PublishDate")]
        //public DateTime PublishDate { get; set; }
    }

    public class NewsArticleResponse
    {
        [JsonProperty("Blogposts")]
        public NewsArticleList NewsArticles { get; set; }
    }

    public class NewsArticleList
    {
        [JsonProperty("results")]
        public List<NewsArticle> Results { get; set; }
    }
}
