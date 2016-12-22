using System.Web.Mvc;
using GameCatalogMVC.DAL;

namespace GameCatalogMVC.Controllers
{
    public class CategoriaController : Controller
    {
        private ICategoriaRepository categoriaRepository;

        public CategoriaController()
        {
            this.categoriaRepository = new CategoriaRepository(new GamecatalogmvcContext());
        }

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }
        public PartialViewResult ListaCategorias(int tipo, int console,  int ordem)
        {            
            var model = categoriaRepository.GetCategorias();
            ViewBag.Tipo = tipo;
            ViewBag.Console = console;                        
            ViewBag.Ordem = ordem;            
            return PartialView(model);
        }

    }
}
