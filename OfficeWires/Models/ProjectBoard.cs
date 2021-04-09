using System.Text.Json.Serialization;

namespace OfficeWires.Models
{
    public class ProjectBoard
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("html_url")]
        public string GitHubUrl { get; set; }

        public string URL { get; set; }
        public string ImageTitle { get; set; }

        // [JsonPropertyName("homepage")]
        // [JsonPropertyName("language")]
        // [JsonPropertyName("has_wiki")]
        // [JsonPropertyName("has_pages")]
        // .. Jira ..
        // .. Confluence ..
        // [JsonPropertyName("owner.id")]
        // [JsonPropertyName("owner.login")]
        // [JsonPropertyName("owner.name")]
        // [JsonPropertyName("owner.email")]
        // [JsonPropertyName("owner.bio")]

    }
}
