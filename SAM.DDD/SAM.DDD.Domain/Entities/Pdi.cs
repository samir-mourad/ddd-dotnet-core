using System;
using System.Collections.Generic;

namespace SAM.DDD.Domain.Entities
{
    public class Pdi
    {
        public int Id { get; set; }
        public int AnoReferencia { get; set; }
        public string DescricaoPontoForte { get; set; }
        public string DescricaoPontoDesenvolver { get; set; }
        public string Expectativa { get; set; }
        public bool MovimentacaoLateral { get; set; }
        public string DescricaoMovimentacaoLateralOutros { get; set; }
        public bool MovimentacaoNacional { get; set; }
        public bool Ativo { get; set; }
        public int NumeroVersao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int IdUsuarioCriacao { get; set; }

        public int FuncionalColaborador { get; set; }
        public Colaborador Colaborador { get; set; }

        public int IdStatus { get; set; }
        public PdiStatus Status { get; set; }

        public IEnumerable<PdiOpcaoAcaoDesenvolvimento> PdisOpcoesAcoesDesenvolvimento { get; set; }
        public IEnumerable<PdiMovimentacaoLateral> PdisMovimentacoesLateral { get; set; }
    }
}
