using System;
using System.Collections.Generic;

namespace SAM.DDD.Domain.Entities
{
    public class OpcaoAcaoDesenvolvimento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Detalhe { get; set; }
        public bool PossuiObservacao { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataExclusao { get; set; }
        public int? IdUsuarioExclusao { get; set; }

        public IEnumerable<PdiOpcaoAcaoDesenvolvimento> PdisOpcoesAcoesDesenvolvimento { get; set; }
    }
}
