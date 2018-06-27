using System.ComponentModel.DataAnnotations;

namespace SAM.DDD.Application.ViewModels
{
    public class PdiViewModel
    {
        [MaxLength(100)]
        [Required]
        public string Expectativa { get; set; }
    }
}