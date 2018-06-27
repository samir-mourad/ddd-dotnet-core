using SAM.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SAM.DDD.Application.ViewModels
{
    public class HierarquiaColaboradorViewModel
    {
        public int Id { get; set; }
        public Int16 AnoReferencia { get; set; }

        public int FuncionalColaborador { get; set; }
        public ColaboradorViewModel Colaborador { get; set; }

        public int? FuncionalSuperior { get; set; }
        public ColaboradorViewModel Superior { get; set; }

        public int IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }

        public int IdCargo { get; set; }
        public Cargo Cargo { get; set; }
    }
}
