using System;
using System.Linq;
using System.Web.Mvc;
using GameCatalogMVC.DAL;

namespace GameCatalogMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepository produtoRepository;

        public ProdutoController()
        {
            this.produtoRepository = new ProdutoRepository(new GamecatalogmvcContext());
        }

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public PartialViewResult DataList()
        {            
            var model = produtoRepository.GetLancamentos();
            return PartialView("DataList", model);
        }
        
        public ActionResult BuscabyTipoConsole(byte tipo, byte console, string mensagem)
        {
            // busca por tipo (1-console, 2-game, 3-acessório) 
            // busca por console (1-Playstation 3, 2-Playstation 2, 3-PSP, 4-xbox 360, 5-PC, 6-DS, 7-Wii)
            // Exibe somente os produtos com o campo exibir=1
            // ordena por data de cadastro desc                                    
            var modelBusca = produtoRepository.GetbyTipoConsole(tipo, console);

            ViewBag.NProdutos = modelBusca.Count();
            ViewBag.Tipo = tipo;
            ViewBag.Console = console;
            ViewBag.Descricao = "0";
            ViewBag.Categoria = 0;
            ViewBag.Ordem = 2;              //DataLancamentoDESC            
            ViewBag.Mensagem = mensagem;    //  mensagem na hora da busca dizendo se é jogo, acessório ou console
            
            return View("ResultBusca", modelBusca);
        }

        // armazena em cache a descrição de todos os jogos
        // a duração do cache é em segundos
        // portanto para deixar 1 dia em cache: 60 seconds * 60 minutes * 24 hours = 86400
        [OutputCache(Duration = 86400, VaryByParam = "none")]
        public JsonResult RetornaNomeProdutos()
        {            
            var modelBusca = produtoRepository.RetornaNomeProdutos();

            return Json(modelBusca);
        }
        
        public ActionResult BuscabyDescricao(string descricao)
        {
            if (String.IsNullOrWhiteSpace(descricao))
                return View("ResultBusca_Error");

            // busca por descrição do produto
            // ordena por data de cadastro desc            
            var modelBusca = produtoRepository.GetbyDescricao(descricao);

            ViewBag.NProdutos = modelBusca.Count();
            ViewBag.Tipo = 0;
            ViewBag.Console = 0;
            ViewBag.Descricao = descricao;
            ViewBag.Categoria = 0;
            ViewBag.Ordem = 2;        //DataLancamentoDESC  
            ViewBag.EhPesquisa = true;
            return View("ResultBusca", modelBusca);
        }

        public PartialViewResult BuscabyTipoConsoleDescricaoCategoriaOrdem(byte tipo, byte console, string descricao, byte categoria, int ordem)
        {
            // Exibe somente os produtos com o campo exibir=1
            // ordena por data de cadastro desc                        
            var modelBuscaOrd = produtoRepository.GetbyTipoConsoleDescricaoCategoriaOrdem(tipo, console, descricao, categoria, ordem );

            ViewBag.NProdutos = modelBuscaOrd.Count();
            ViewBag.Tipo = tipo;
            ViewBag.Console = console;            
            ViewBag.Descricao = descricao;
            ViewBag.Categoria = categoria;
            ViewBag.Ordem = ordem;
            
            return PartialView("ResultBusca_Detalhes", modelBuscaOrd);
        }


        public ActionResult Details(int idproduto)
        {
            var model = produtoRepository.GetbyID(idproduto);
            return View(model);
        }


    }
}
