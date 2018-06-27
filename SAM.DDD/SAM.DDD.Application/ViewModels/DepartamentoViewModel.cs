using SAM.DDD.Domain.Entities;

namespace SAM.DDD.Application.ViewModels
{
    public class DepartamentoViewModel
    {
        public int Id { get; set; }
        public int AnoReferencia { get; set; }
        public string CodigoInternoArea { get; set; }
        public string Descricao { get; set; }
        public string DescricaoAbreviada { get; set; }

        public int? IdDepartamentoSuperior { get; set; }
        public Departamento DepartamentoSuperior { get; set; }

        public int FuncionalColaboradorResponsavel { get; set; }
        public Colaborador ColaboradorResponsavel { get; set; }

        //public IEnumerable<Departamento> Departamentos { get; set; }
        //public IEnumerable<HierarquiaColaborador> HierarquiaColaborador { get; set; }
        //public IEnumerable<PdiMovimentacaoLateral> PdiMovimentacoesLateral { get; set; }
    }
}
