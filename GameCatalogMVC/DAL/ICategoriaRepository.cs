using System;
using System.Collections.Generic;
using GameCatalogMVC.Models;

namespace GameCatalogMVC.DAL
{
    public interface ICategoriaRepository : IDisposable
    {
        IEnumerable<Categoria> GetCategorias();
    }
        
}
    
