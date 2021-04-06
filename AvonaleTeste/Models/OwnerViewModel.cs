using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AvonaleTeste.Models
{
    public class OwnerViewModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [Display(Name = "Código")]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("node_id")]
        public string NodeId { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty("repos_url")]
        public string ReposUrl { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("site_admin")]
        public bool SiteAdmin { get; set; }

    }
}
