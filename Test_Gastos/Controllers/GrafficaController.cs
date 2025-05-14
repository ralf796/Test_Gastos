using Layers;
using Microsoft.AspNetCore.Mvc;

namespace Test_Gastos.Controllers
{
    public class GrafficaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult DataDevexpress(string fecha1 = "", string fecha2 = "")
        {
            try
            {
                List<Grafico_BE> lista = new List<Grafico_BE>();
                Grafico_BE item = new Grafico_BE
                {
                    fecha1 = Convert.ToDateTime(fecha1),
                    fecha2 = Convert.ToDateTime(fecha2)
                };
                lista = Reporte_BLL.Graficos(item);
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
