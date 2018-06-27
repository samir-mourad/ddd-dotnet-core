using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SAM.DDD.Application.ViewModels
{
    public class ColaboradorViewModel
    {
        [Required]
        [DisplayName("Número Funcional")]
        public int NumeroFuncional { get; set; }

        [Required]
        [DisplayName("Id SGI")]
        public int IdUsuario { get; set; }

        [Required, StringLength(100)]
        [DisplayName("Nome")]
        public string NomeCompleto { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
