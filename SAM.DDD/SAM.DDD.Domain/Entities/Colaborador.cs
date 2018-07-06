using System.Collections.Generic;

namespace SAM.DDD.Domain.Entities
{
    public class Colaborador
    {
        public int NumeroFuncional { get; set; }
        public string Email { get; set; }
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public bool Ativo { get; set; }

        public bool TemSubordinados { get; set; }

        public IEnumerable<Eixo> Eixos { get; set; }
        public IEnumerable<Pdi> Pdis { get; set; }
        public IEnumerable<CompetenciaColaborador> Competencias { get; set; }
        public IEnumerable<Departamento> ResponsavelDepartamentos { get; set; }
        public IEnumerable<HierarquiaColaborador> Hierarquia { get; set; }

    }
}
