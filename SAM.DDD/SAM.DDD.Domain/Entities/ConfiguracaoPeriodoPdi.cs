using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Domain.Entities
{
    public class ConfiguracaoPeriodoPdi
    {
        public int Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int NumeroEtapa { get; set; }
    }
}
