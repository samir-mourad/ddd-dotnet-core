using System;

namespace SAM.DDD.Domain.Entities
{
    public class HierarquiaColaborador
    {
        public int Id { get; set; }
        public Int16 AnoReferencia { get; set; }

        public int FuncionalColaborador { get; set; }
        public Colaborador Colaborador { get; set; }

        public int? FuncionalSuperior { get; set; }
        public Colaborador Superior { get; set; }

        public int IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }

        public int IdCargo { get; set; }
        public Cargo Cargo { get; set; }
    }
}
