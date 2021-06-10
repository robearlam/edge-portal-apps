using Newtonsoft.Json;
using System.Collections.Generic;

namespace EdgePortalApps.Data.Models
{
    public class Announcement
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("URL")]
        public string LinkURL { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("HasUrl")]
        public bool HasUrl { get; set; }
    }

    public class AnnouncementsRepsonse
    {
        [JsonProperty("AnnouncementResults")]
        public AnnouncementList AnnouncementsContent { get; set; }
    }

    public class AnnouncementList
    {
        [JsonProperty("results")]
        public List<Announcement> Results { get; set; }
    }
}