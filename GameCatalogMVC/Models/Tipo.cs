using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameCatalogMVC.Models
{
    [Table("Tipo")]
    public class Tipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte IdTipo { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo 50 caracteres")]
        public string Descricao { get; set; }
        public virtual IQueryable<Produto> Produtos { get; set; }

    }
}