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

        [HttpPost]
        public IActionResult Guardar(int id_tipo_gasto = 0, decimal monto = 0, int anio=0, int mes=0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Presupuesto_BE item = new Presupuesto_BE
                {
                    id_tipo_gasto = id_tipo_gasto,
                    monto = monto,
                    anio = anio,
                    mes = mes,
                    id_usuario = UsuarioActivo.IdUsuario
                };
                respuesta = Presupuesto_BLL.Guardar(item);
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al guardar el presupuesto: " + ex.Message;
            }
            return Json(respuesta);
        }
        [HttpPost]
        public IActionResult Eliminar(int id_presupuesto = 0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = Presupuesto_BLL.Eliminar(new Presupuesto_BE { id_presupuesto = id_presupuesto });
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al eliminar el presupuesto: " + ex.Message;
            }
            return Json(respuesta);
        }


    }
}