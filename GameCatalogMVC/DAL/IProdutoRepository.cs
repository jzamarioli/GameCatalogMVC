using System;
using System.Collections.Generic;
using GameCatalogMVC.Models;

namespace GameCatalogMVC.DAL
{
    public interface IProdutoRepository : IDisposable
    {
        IEnumerable<Produto> GetLancamentos();
        IEnumerable<Produto> GetbyTipoConsole(byte tipo, byte console);
        IEnumerable<string> RetornaNomeProdutos();
        IEnumerable<Produto> GetbyDescricao(string descricao);
        IEnumerable<Produto> GetbyTipoConsoleDescricaoCategoriaOrdem(byte tipo, byte console, string descricao, byte categoria, int ordem);
        Produto GetbyID(int IDproduto);
    }
        
}
    
