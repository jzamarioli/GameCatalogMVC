using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace GameCatalogMVC.Models
{
    public class Email
    {        
        [Required(ErrorMessage = "Favor preencher seu Nome!", AllowEmptyStrings=false)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O nome deve conter entre 5 e 50 caracteres")]
        public string NomeRemetente { get; set; }

        [Required(ErrorMessage = "Favor preencher seu e-mail!", AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 7, ErrorMessage="O e-mail deve conter entre 7 e 50 caracteres")]
        [Email(ErrorMessage = "Favor preencher um e-mail válido!")]
        public string EmailRemetente { get; set; }
        
        [Required(ErrorMessage = "Favor preencher a mensagem!", AllowEmptyStrings = false)]
        [StringLength(4000, MinimumLength = 10, ErrorMessage = "A mensagem deve conter entre 10 e 4000 caracteres")]
        public string Mensagem { get; set; }  
    }
}