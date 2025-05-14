using Layers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test_Gastos.Controllers
{
    public class PresupuestoController : SessionController
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DataTable(int anio = 0, int mes = 0)
        {
            List<Presupuesto_BE> lista = Presupuesto_BLL.Listar(new Presupuesto_BE { id_usuario = UsuarioActivo.IdUsuario, anio = anio, mes = mes });
            return PartialView(lista);
        }
        public IActionResult TipoGasto()
        {
            List<Tipo_Gasto_BE> lista = Tipo_Gasto_BLL.Listar(new Tipo_Gasto_BE());
            if (lista.Count > 0)
                lista = lista.Where(x => x.estado == 1).ToList();
            return Json(lista);
        }
    }
}