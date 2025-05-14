using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_Gastos.Models;
namespace Test_Gastos.Controllers
{
    public class HomeController : SessionController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            UserToken UsuarioActivo = new UserToken(HttpContext.User);
            ViewBag.UsuarioActivo = UsuarioActivo;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*
        public JsonResult Grafica_1()
        {
            List<Reportes_BE> lista = new List<Reportes_BE>();
            lista = PRINT_Reportes_BLL.Grafica(new Reportes_BE { tipo = 8 });
            if (lista.Count == 0)
                lista.Add(new Reportes_BE { vendedor = "SIN VENTAS" });
            return Json(lista);
        }        
        */
    }
}