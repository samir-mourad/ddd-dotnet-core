using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Domain.Entities
{
    public class Eixo
    {
        public int Id { get; set; }
        public short AnoReferencia { get; set; }
        public decimal? NotaEixoX { get; set; }
        public decimal? NotaEixoY { get; set; }

        public int FuncionalColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
