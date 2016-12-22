using System;
using System.Collections.Generic;
using GameCatalogMVC.Models;
using System.Linq;

namespace GameCatalogMVC.DAL
{
    public class ProdutoRepository : IProdutoRepository, IDisposable
    {
        private GamecatalogmvcContext context;
        private bool disposed = false;

        public ProdutoRepository(GamecatalogmvcContext context)
        {
            this.context = context;
        }

        public IEnumerable<Produto> GetLancamentos()
        {
            IEnumerable<Produto> lstProdutos = context.Produto.Include("Console").Where(p => p.Exibir_na_pag_principal == 1 && p.Ativo == 1).OrderByDescending(p => p.Data_cadastro).Take(32);
            return lstProdutos;
        }


        public IEnumerable<Produto> GetbyTipoConsole(byte tipo, byte console)
        {
            // usado no menu XBOX...(game,console,acessórios)                
            var lstProdutos = context.Produto.Include("Console").Where(p => p.Tipo.IdTipo == tipo && p.Console.IdConsole == console && p.Ativo == 1).OrderByDescending(p => p.Data_cadastro);
            return lstProdutos;
        }

        public IEnumerable<string> RetornaNomeProdutos()
        {
            // usado na busca por descricao            
            List<string> lstDescricoes = new List<string>();
            var lstDesc = from c in context.Produto where c.Ativo==1 orderby c.Descricao select new { Descricao = c.Descricao };
            foreach (var j in lstDesc)
            {
                lstDescricoes.Add(j.Descricao );
            }
            return lstDescricoes;
        }

        public IEnumerable<Produto> GetbyDescricao(string descricao)
        {            
            // usado na busca por descricao            
            var lstProdutos = context.Produto.Include("Console").Where(p => p.Descricao .Contains(descricao) && p.Ativo == 1).OrderByDescending(p => p.Data_cadastro);
            return lstProdutos;
        }


        public IEnumerable<Produto> GetbyTipoConsoleDescricaoCategoriaOrdem(byte tipo, byte console, string descricao, byte categoria, int ordem)
        {            
            var lstProdutos = context.Produto.Include("Console").Where(p => p.Ativo == 1);

            if (tipo != 0)
            {
                lstProdutos = lstProdutos.Where(p => p.Tipo.IdTipo == tipo);
            }
            if (console != 0)
            {
                lstProdutos = lstProdutos.Where(p => p.Console.IdConsole == console);
            }
            if (descricao != "0")
            {
                lstProdutos = lstProdutos.Where(p => p.Descricao .Contains(descricao));
            }
            if (categoria != 0)
            {
                lstProdutos = lstProdutos.Where(p => p.Categoria.IdCategoria == categoria);
            }
            switch (ordem)
            {
                case 0:         //"NameASC"
                    lstProdutos = lstProdutos.OrderBy(p => p.Descricao );
                    break;
                case 1:         //"NameDESC"
                    lstProdutos = lstProdutos.OrderByDescending(p => p.Descricao );
                    break;
                case 2:         //"DataLancamentoDESC"
                    lstProdutos = lstProdutos.OrderByDescending(p => p.Data_cadastro);
                    break;
            }
            return lstProdutos;
        }

        public Produto GetbyID(int IDproduto)
        {            
            var prod = (context.Produto.Include("Console").Where(p => p.IdProduto == IDproduto && p.Ativo == 1)).FirstOrDefault();
            return prod;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
