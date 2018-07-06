using SAM.DDD.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SAM.DDD.Infra.Identity.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddOAuthAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.CallbackPath = configuration["Authorization:Oidc:CallBack"];
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.RequireHttpsMetadata = false;

                options.ClientId = configuration["Authorization:Oidc:ClientId"];
                options.ClientSecret = configuration["Authorization:Oidc:Secret"];

                options.ResponseType = OpenIdConnectResponseType.Code;

                options.Authority = configuration["Authorization:Oidc:AuthorityHostSignIn"];
                options.Resource = configuration["Authorization:Oidc:AuthorityHostSignIn"];

                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;

                options.Scope.Add("openid");
                options.Scope.Add("api");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("offline_access");

                options.Events = new OpenIdConnectEvents
                {
                    OnTokenValidated = context =>
                    {
                        var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                        var accessToken = context.TokenEndpointResponse.AccessToken;

                        claimsIdentity.AddClaims(accessToken);

                        var httpClient = new IdentityService(configuration, accessToken);
                        var id = claimsIdentity.GetClaims();
                        var user = httpClient.GetIdentityAsync(id).Result;

                        if (!user.IuCollaborator) throw new Exception("Colaborador inativo");

                        ClaimsExtensions.AddClaims(claimsIdentity, user.Claims);

                        var serviceProvider = services.BuildServiceProvider();
                        var colaboradorService = serviceProvider.GetService<IColaboradorService>();
                        var colaborador = colaboradorService.UpdateId(claimsIdentity.GetEmailClaim(), claimsIdentity.GetClaims());

                        if (colaborador != null && colaborador.TemSubordinados)
                            claimsIdentity.AddUsuarioSuperiorClaims();

                        var expiresIn = Convert.ToInt32(context.TokenEndpointResponse.ExpiresIn);
                        var expireDateCookie = DateTime.UtcNow.AddMinutes(expiresIn / 60).ToString("o", CultureInfo.InvariantCulture);

                        context.Response.Cookies.Append("expires_in", expireDateCookie);

                        return Task.CompletedTask;
                    }
                };

            });
        }
    }
}
