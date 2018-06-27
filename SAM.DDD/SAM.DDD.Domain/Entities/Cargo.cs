using System;
using System.Collections.Generic;
using System.Text;

namespace SAM.DDD.Domain.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DescricaoNivel { get; set; }
    }
}
