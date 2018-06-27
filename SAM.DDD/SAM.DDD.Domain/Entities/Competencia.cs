using System;

namespace SAM.DDD.Domain.Entities
{
    public class Competencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Detalhe { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataExclusao { get; set; }
        public int? IdUsuarioExclusao { get; set; }
    }
}
