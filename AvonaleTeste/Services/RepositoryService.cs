using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using AvonaleTeste.Models;
using Newtonsoft.Json;
using TesteAvonale.Utils;

namespace TesteAvonale.Service
{
    public class RepositoryService
    {

        /// <summary>
        /// Obtem a lista contendo os meus repositorios pessoais (igorb22)
        /// </summary>
        /// <returns></returns>
        public List<RepositoryViewModel> GetMyRepositories()
        {
            var repositories = new List<RepositoryViewModel>();

            try
            {
                var request = WebRequest.CreateHttp(Constants.URL_MY_REPOS);
                request.Method = Constants.METHOD_GET;
                request.UserAgent = Constants.MY_USER;
                using (var resposta = request.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    repositories = JsonConvert.DeserializeObject<List<RepositoryViewModel>>(objResponse.ToString());
                    streamDados.Close();
                    resposta.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return repositories;
        }

        /// <summary>
        /// Obtem a lista de repositorios resultantes da pesquisada feita pelo usuario
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public SearchRepositories GetRepositories(string search)
        {
            var repositories = new SearchRepositories();

            try
            {
                var request = WebRequest.CreateHttp(Constants.URL_SEARCH_REPOS.Replace("{SEARCH}", search));
                request.Method = Constants.METHOD_GET;
                request.UserAgent = Constants.MY_USER;
                using (var resposta = request.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    repositories = JsonConvert.DeserializeObject<SearchRepositories>(objResponse.ToString());
                    streamDados.Close();
                    resposta.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return repositories;
        }

        /// <summary>
        /// Obtema a lsiat de contribuidores de um repositorio
        /// </summary>
        /// <param name="user"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public List<OwnerViewModel> GetContribuitors(string user, string repository)
        {
            var contribuitors = new List<OwnerViewModel>();

            try
            {
                var request = WebRequest.CreateHttp(Constants.URL_CONTRIBUITORS.Replace("{USER}", user).Replace("{REPOSITORY}", repository));
                request.Method = Constants.METHOD_GET;
                request.UserAgent = Constants.MY_USER;
                using (var resposta = request.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    contribuitors = JsonConvert.DeserializeObject<List<OwnerViewModel>>(objResponse.ToString());
                    streamDados.Close();
                    resposta.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return contribuitors;
        }

        /// <summary>
        /// Obtem um repositorio pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RepositoryViewModel GetById(int id)
        {
            var repository = new RepositoryViewModel();

            try
            {
                var request = WebRequest.CreateHttp(Constants.URL_REPOSITORY_BY_ID.Replace("{ID}",id.ToString()));
                request.Method = Constants.METHOD_GET;
                request.UserAgent = Constants.MY_USER;
                using (var resposta = request.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    repository = JsonConvert.DeserializeObject<RepositoryViewModel>(objResponse.ToString());
                    streamDados.Close();
                    resposta.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return repository;
        }

        /// <summary>
        /// Adiciona um novo repositorio favorito
        /// </summary>
        /// <param name="repositoryFavorite"></param>
        /// <returns></returns>
        public bool CreateFavorite(RepositoryViewModel repositoryFavorite)
        {
            var json = new JavaScriptSerializer().Serialize(repositoryFavorite) + ",";
            bool resultado = true;
            try
            {
                string path = Path.GetTempPath();

                path = Path.Combine(path, "Favorites.txt");
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(json);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(json);
                    }
                }
            }
            catch (Exception e)
            {
                resultado = false;
                Console.WriteLine(e.Message);
            }

            return resultado;
        }

        /// <summary>
        /// Obtem a lsita com todos os repositorios favoritos
        /// </summary>
        /// <returns></returns>
        public List<RepositoryViewModel> GetAllRepositoriesFavorites()
        {
            var repositories = new List<RepositoryViewModel>();
            try
            {
                string path = Path.GetTempPath();

                path = Path.Combine(path, "Favorites.txt");
                string text = "[" + File.ReadAllText(path) + "]";

                repositories = JsonConvert.DeserializeObject<List<RepositoryViewModel>>(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return repositories;
        }
    }
}
