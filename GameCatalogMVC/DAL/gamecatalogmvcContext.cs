using System.Data.Entity;
using GameCatalogMVC.Models;

namespace GameCatalogMVC.DAL
{
    public class GamecatalogmvcContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Console> Console { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Produto> Produto { get; set; }

    }
}
    
