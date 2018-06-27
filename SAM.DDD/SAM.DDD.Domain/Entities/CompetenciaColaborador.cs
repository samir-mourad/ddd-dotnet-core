using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Domain.Entities
{
    public class CompetenciaColaborador
    {
        public int Id { get; set; }
        public Int16 AnoReferencia { get; set; }
        public string ExpectativaColaborador { get; set; }
        public int? NotaAvaliacaoColaborador { get; set; }
        public int? NotaAvaliacaoGestor { get; set; }
        public int? NotaPrioridadeColaborador { get; set; }
        public int? NotaPrioridadeGestor { get; set; }
        public bool Ativo { get; set; }
        public Byte NumeroVersao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int FuncionalColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        public int IdCompetencia { get; set; }
        public Competencia Competencia { get; set; }
    }
}
