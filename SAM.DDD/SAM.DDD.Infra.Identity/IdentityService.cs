using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SAM.DDD.Infra.Identity
{
    public class IdentityService : IDisposable
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        public IdentityService(IConfiguration _configuration, string accessToken)
        {
            configuration = _configuration;

            client = new HttpClient
            {
                BaseAddress = new Uri(configuration["Authorization:Oidc:AuthorityHostSignIn"]),
                Timeout = TimeSpan.FromMinutes(5)
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<IdentityUser> GetIdentityAsync(int id)
        {
            var res = await client.GetAsync($"/api/v1/people/{id}?includeFeatures=true");
            var content = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IdentityUser>(content);
        }

        public void Dispose() => client?.Dispose();
   }
}
