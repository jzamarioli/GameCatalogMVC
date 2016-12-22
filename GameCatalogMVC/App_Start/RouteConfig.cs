using System.Web.Mvc;
using System.Web.Routing;

namespace GameCatalogMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "ListaCategorias",
               url: "Categoria/ListaCategorias/{tipo}/{console}/{ordem}",
               defaults: new { controller = "Categoria", action = "ListaCategorias", tipo = UrlParameter.Optional, console = UrlParameter.Optional, ordem = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ProdutoDetail",
               url: "Produto/Details/{idproduto}",
               defaults: new { controller = "Produto", action = "Details", idproduto = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "BuscabyDescricao",
               url: "Produto/BuscabyDescricao/{descricao}",
               defaults: new { controller = "Produto", action = "BuscabyDescricao", descricao = UrlParameter.Optional }
            );            

            routes.MapRoute(
               name: "BuscabyTipoConsole",
               url: "Produto/BuscabyTipoConsole/{tipo}/{console}/{mensagem}",
               defaults: new { controller = "Produto", action = "BuscabyTipoConsole", tipo = UrlParameter.Optional, console = UrlParameter.Optional, mensagem = UrlParameter.Optional }
            );
            
            routes.MapRoute(
            name: "BuscabyTipoConsoleDescricaoCategoriaOrdem",
            url: "Produto/BuscabyTipoConsoleDescricaoCategoriaOrdem/{tipo}/{console}/{descricao}/{categoria}/{ordem}",
            defaults: new { controller = "Produto", action = "BuscabyTipoConsoleDescricaoCategoriaOrdem", tipo = UrlParameter.Optional, console = UrlParameter.Optional, descricao = UrlParameter.Optional, categoria = UrlParameter.Optional, ordem = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}