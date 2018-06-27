using AutoMapper;
using SAM.DDD.Application.ViewModels;
using SAM.DDD.Domain.Entities;
using SAM.DDD.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SAM.DDD.Infra.Identity.Extensions;
using SAM.DDD.Infra.Identity;

namespace SAM.DDD.Site.Controllers
{
    [Authorize(Policies.Administrador)]
    public class ExemploController : Controller
    {
        private readonly IColaboradorService colaboradorService;
        private readonly IMapper mapper;

        public ExemploController(IColaboradorService _colaboradorService, IMapper _mapper) {
            mapper = _mapper;
            colaboradorService = _colaboradorService;
        } 

        [HttpPost]
        public ActionResult Inserir(ColaboradorViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var colaborador = Mapper.Map<Colaborador>(model);
            colaboradorService.Add(colaborador);

            return RedirectToAction("Listar");

        }

        [HttpGet]
        public ActionResult Inserir()
        {
            return View();
        }

        public ActionResult Listar()
        {
            var isAdmin = User.IsAdministrador();
            var isSuperior = User.IsColaboradorSuperior();
            var isColaborador = User.IsColaborador();


            var colaboradores = colaboradorService.Get(null, x => x.OrderBy(i => i.NumeroFuncional));
            var model = mapper.Map<ColaboradorViewModel[]>(colaboradores);

            return View(model);
        }

        public JsonResult Delete()
        {
            var colaborador = colaboradorService.GetById(333);
            colaboradorService.Delete(colaborador);

            return Json("Colaborador Deletado");
        }
    }
}