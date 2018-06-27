using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace SAM.DDD.Site.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration _configuration)
        {
           configuration = _configuration;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public ActionResult SignIn()
        {
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            var idToken = await HttpContext.GetTokenAsync("id_token");
            await HttpContext.SignOutAsync("Cookies");

            return Redirect(configuration["Authorization:Oidc:AuthorityHostSignOut"] + idToken);

        }
    }
}