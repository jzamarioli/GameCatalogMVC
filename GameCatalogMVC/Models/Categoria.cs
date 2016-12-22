using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameCatalogMVC.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte IdCategoria { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Descricao { get; set; }
        public virtual IQueryable<Produto> Produtos { get; set; }

    }
}