using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameCatalogMVC.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }
        [MaxLength(60, ErrorMessage = "Máximo 60 caracteres")]
        public string Descricao { get; set; }
        public byte? IdCategoria { get; set; }
        public byte? IdConsole { get; set; }
        public byte? IdTipo { get; set; }
        [MaxLength(40)]
        public string Texto1 { get; set; }
        [MaxLength(40)]
        public string Texto2 { get; set; }
        [MaxLength(40)]
        public string Texto3 { get; set; }
        [MaxLength(60)]
        public string Foto { get; set; }
        [MaxLength(80)]
        public string Site { get; set; }
        public byte? Exibir_na_pag_principal { get; set; }
        public byte? Ativo { get; set; }
        public DateTime Data_cadastro { get; set; }

        [ForeignKey("IdTipo")]
        public virtual Tipo Tipo { get; set; }
        [ForeignKey("IdConsole")]
        public virtual Console Console { get; set; }
        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }
    }
}