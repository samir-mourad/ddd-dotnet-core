using SAM.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Application.ViewModels
{
    public class CompetenciaColaboradorViewModel
    {
        public int Id { get; set; }
        public int AnoReferencia { get; set; }
        public string ExpectativaColaborador { get; set; }
        public int? NotaAvaliacaoColaborador { get; set; }
        public int? NotaAvaliacaoGestor { get; set; }
        public int? NotaPrioridadeColaborador { get; set; }
        public int? NotaPrioridadeGestor { get; set; }
        public bool Ativo { get; set; }
        public int NumeroVersao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int FuncionalColaborador { get; set; }
        public ColaboradorViewModel Colaborador { get; set; }
        public int IdCompetencia { get; set; }
        public CompetenciaViewModel Competencia { get; set; }
    }
}
