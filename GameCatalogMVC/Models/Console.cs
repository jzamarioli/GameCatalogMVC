using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameCatalogMVC.Models
{
    [Table("Console")]
    public class Console
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte IdConsole { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Descricao { get; set; }

        public virtual IQueryable<Produto> Produtos { get; set; }

    }
}