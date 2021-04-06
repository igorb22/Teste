using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvonaleTeste.Models
{
    public class RepositoryViewModel
    {
        public RepositoryViewModel()
        {
            Contribuitores = new List<OwnerViewModel>();
        }

        [Display(Name = "Código")]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("node_id")]
        public string NodeId { get; set; }
        [Display(Name = "Nome")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [Display(Name = "Nome Completo")]
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [Display(Name = "Privado")]
        [JsonProperty("private")]
        public bool Private { get; set; }
        [Display(Name = "Proprietário")]
        [JsonProperty("owner")]
        public OwnerViewModel Owner { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [Display(Name = "Descrição")]
        [JsonProperty("description")]
        public object Description { get; set; }
        [JsonProperty("forks_url")]
        public string ForksUrl { get; set; }
        [JsonProperty("collaborators_url")]
        public string CollaboratorsUrl { get; set; }
        [JsonProperty("branches_url")]
        public string BranchesUrl { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Atualizado em")]
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("pushed_at")]
        public DateTime PushedAt { get; set; }
        [JsonProperty("clone_url")]
        public string CloneUrl { get; set; }
        [JsonProperty("homepage")]
        public object Homepage { get; set; }
        [JsonProperty("forks_count")]
        public int ForksCount { get; set; }
        [JsonProperty("open_issues_count")]
        public int OpenIssuesCount { get; set; }
        [JsonProperty("forks")]
        public int Forks { get; set; }
        [JsonProperty("open_issues")]
        public int OpenIssues { get; set; }
        [JsonProperty("default_branch")]
        public string DefaultBranch { get; set; }
        [Display(Name = "Linguagem")]
        [JsonProperty("language")]
        public string Languagem { get; set; }

        [Display(Name = "Contribuidores")]
        public List<OwnerViewModel> Contribuitores { get; set; }

        [Display(Name = "Linguagem")]
        public bool Favorite { get; set; }
    }
}
