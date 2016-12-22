using System;
using System.Collections.Generic;
using GameCatalogMVC.Models;
using System.Linq;

namespace GameCatalogMVC.DAL
{
    public class CategoriaRepository : ICategoriaRepository, IDisposable
    {
        private GamecatalogmvcContext context;
        private bool disposed = false;

        public CategoriaRepository(GamecatalogmvcContext context)
        {
            this.context = context;
        }

        public IEnumerable<Categoria> GetCategorias()
        {            
            var lstCategorias = context.Categoria.Where(c=>c.IdCategoria != 0).OrderBy(c=>c.Descricao );
            return lstCategorias;
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
