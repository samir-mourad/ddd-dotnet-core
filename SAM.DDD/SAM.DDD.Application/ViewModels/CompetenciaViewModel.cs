using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SAM.DDD.Application.ViewModels
{
    public class CompetenciaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Detalhe { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataExclusao { get; set; }
        public int? IdUsuarioExclusao { get; set; }
    }
}
