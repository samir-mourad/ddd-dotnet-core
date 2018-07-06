using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;


namespace SAM.DDD.Infra.Identity.Extensions
{
    public static class ClaimsExtensions
    {
        public static bool IsAdministrador(this ClaimsPrincipal identity) => 
               identity.HasClaim(x => x.Type == "profile"
                                   && x.Value == $"Administrador SPDI#{identity.GetClientId()}");


        public static bool IsColaboradorSuperior(this ClaimsPrincipal identity) =>
               identity.HasClaim(x => x.Type == "profile"
                                   && x.Value == $"UsuarioSuperior SPDI#{identity.GetClientId()}");

        public static bool IsColaborador(this ClaimsPrincipal identity) =>
               identity.HasClaim(x => x.Type == "profile"
                                   && x.Value == $"Usuario SPDI#{identity.GetClientId()}");

        public static string GetClientId(this ClaimsPrincipal identity) =>
               identity.Claims.Single(x => x.Type == "client_id").Value;

        public static string GetClientId(this ClaimsIdentity identity) =>
              identity.Claims.Single(x => x.Type == "client_id").Value;

        public static void AddUsuarioSuperiorClaims(this ClaimsIdentity identity) => identity.AddClaim(new Claim("profile", $"UsuarioSuperior SPDI#{identity.GetClientId()}"));

        public static void AddClaims(this ClaimsIdentity identity, string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            var jwt = ReadAccessToken(accessToken);
            var filteredClaims = FilterClaims(identity.Claims, jwt.Claims);

            identity.AddClaims(filteredClaims);
        }

        public static void AddClaims(this ClaimsIdentity identity, IEnumerable<Claim> claims)
        {
            var claimsUser = FilterClaims(identity.Claims, claims);
            identity.AddClaims(claimsUser);
        }

        public static int GetClaims(this ClaimsIdentity identity) => Convert.ToInt32(identity.FindFirst("id").Value);
        public static string GetEmailClaim(this ClaimsIdentity identity) => identity.FindFirst("email").Value;
        public static string GetUserNameClaim(IEnumerable<Claim> identity) => identity.FirstOrDefault(x => x.Type == "name")?.Value;

        private static JwtSecurityToken ReadAccessToken(string accessToken) =>
               new JwtSecurityTokenHandler().ReadToken(accessToken) as JwtSecurityToken;

        private static IEnumerable<Claim> FilterClaims(IEnumerable<Claim> identityClaims, IEnumerable<Claim> otherClaims) =>
               otherClaims.Where(t => identityClaims.All(i => i.Type != t.Type && i.Type != t.Type));
    }
}
