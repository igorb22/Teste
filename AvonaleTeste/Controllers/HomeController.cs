using AvonaleTeste.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using TesteAvonale.Service;

namespace AvonaleTeste.Controllers
{
    public class HomeController : Controller
    {
        readonly RepositoryService _service = new RepositoryService();

        public ActionResult Index()
        {
            return View(_service.GetMyRepositories());
        }

        public ActionResult Search(string pesquisa)
        {
            SearchRepositories repositories = new SearchRepositories();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                repositories = _service.GetRepositories(pesquisa);
            }

            return View(repositories);
        }


        public ActionResult Favorites()
        {
            List<RepositoryViewModel> repositories = _service.GetAllRepositoriesFavorites();

            return View(repositories);
        }

        public ActionResult FavoriteRepository(int id)
        {

            var repository = _service.GetById(id);
            if (_service.CreateFavorite(repository))
                return RedirectToAction("Favorites");
            else
            {
                TempData["mensagemErro"] = "Não foi possível favoritar o repositório.";
                return RedirectToRoute(new { controller = "Home", action = "Details", id });
            }
        }

        public ActionResult Details(int? id)
        {
            var repository = _service.GetById(id.Value);

            var repos = _service.GetAllRepositoriesFavorites();

            foreach (var item in repos)
            {
                if (item.Id == repository.Id)
                    repository.Favorite = true;
            }

            repository.Contribuitores.AddRange(_service.GetContribuitors(repository.Owner.Login, repository.Name));

            return View(repository);
        }

    }
}