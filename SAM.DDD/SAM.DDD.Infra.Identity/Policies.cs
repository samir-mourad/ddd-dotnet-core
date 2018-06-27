using SAM.DDD.Infra.Identity.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace SAM.DDD.Infra.Identity
{
    public static class Policies
    {
        public static void Configure(AuthorizationOptions options)
        {
            options.AddPolicy(Administrador, p => p.RequireAssertion(i => i.User.IsAdministrador()));
            options.AddPolicy(ColaboradorSuperior, p => p.RequireAssertion(i => i.User.IsColaboradorSuperior()));
            options.AddPolicy(Colaborador, p => p.RequireAssertion(i => i.User.IsColaborador()));
        }

        public const string Administrador = "acesso:administrador";
        public const string ColaboradorSuperior = "acesso:superior";
        public const string Colaborador = "acesso:colaborador";
    }
}
