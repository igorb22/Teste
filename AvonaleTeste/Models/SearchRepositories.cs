using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvonaleTeste.Models
{
    public class SearchRepositories
    {
        public SearchRepositories() 
        {
            Repositories = new List<RepositoryViewModel>();
        }

        [Display(Name = "Total")]
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
        [Display(Name = "Repositórios")]
        [JsonProperty("items")]
        public List<RepositoryViewModel> Repositories { get; set; }
    }
}