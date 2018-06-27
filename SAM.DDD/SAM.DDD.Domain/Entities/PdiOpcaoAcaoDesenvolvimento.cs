using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Domain.Entities
{
    public class PdiOpcaoAcaoDesenvolvimento
    {
        public int IdPdi { get; set; }
        public Pdi Pdi { get; set; }
        public int IdOpcaoAcaoDesenvolvimento { get; set; }
        public OpcaoAcaoDesenvolvimento OpcaoAcaoDesenvolvimento { get; set; }
        public string Observacao { get; set; }
    }
}
