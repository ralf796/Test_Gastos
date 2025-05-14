using Layers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test_Gastos.Controllers
{
    [Authorize]
    public class ReporteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult DataDevexpress(int tipo = 0, string fecha1 = "", string fecha2 = "")
        {
            try
            {
                List<Reporte_BE> lista = new List<Reporte_BE>();
                Reporte_BE item = new Reporte_BE
                {
                    fecha1 = Convert.ToDateTime(fecha1),
                    fecha2 = Convert.ToDateTime(fecha2)
                };
                if (tipo == 1)
                    lista = Reporte_BLL.RepDepositos(item);
                else if (tipo == 2)
                    lista = Reporte_BLL.RepGastos(item);

                return Json(new { state = 1, data = lista });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    State = -1,
                    Message = ex.Message
                });
            }
        }
    }
}
