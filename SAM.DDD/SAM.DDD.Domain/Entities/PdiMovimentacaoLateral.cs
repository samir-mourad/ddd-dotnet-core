namespace SAM.DDD.Domain.Entities
{
    public class PdiMovimentacaoLateral
    {
        public int IdPdi { get; set; }
        public Pdi Pdi { get; set; }

        public int IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }
    }
}
