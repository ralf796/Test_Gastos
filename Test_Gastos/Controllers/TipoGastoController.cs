using Layers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test_Gastos.Controllers
{
    public class TipoGastoController : SessionController
    {
        [Authorize]
        public IActionResult Index()
        {
            if (UsuarioActivo.Usuario != "" && UsuarioActivo.Usuario != null)
                return View();
            else
                return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult DataTable()
        {
            List<Tipo_Gasto_BE> lista = Tipo_Gasto_BLL.Listar(new Tipo_Gasto_BE());
            return PartialView(lista);
        }

        [HttpPost]
        public IActionResult Guardar(string codigo= "", string descripcion= "")
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Tipo_Gasto_BE item = new Tipo_Gasto_BE
                {
                    codigo=codigo,
                    descripcion=descripcion
                };
                respuesta = Tipo_Gasto_BLL.Guardar(item);
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = ex.Message;
            }
            return Json(respuesta);
        }

        [HttpPost]
        public IActionResult Modificar(int id_tipo_gasto=0,string codigo = "", string descripcion = "")
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Tipo_Gasto_BE item = new Tipo_Gasto_BE
                {
                    id_tipo_gasto= id_tipo_gasto,
                    codigo = codigo,
                    descripcion = descripcion
                };
                respuesta = Tipo_Gasto_BLL.Modificar(item);
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al actualizar: " + ex.Message;
            }
            return Json(respuesta);
        }

        [HttpPost]
        public IActionResult Eliminar(int id_tipo_gasto = 0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = Tipo_Gasto_BLL.Delete(new Tipo_Gasto_BE { id_tipo_gasto = id_tipo_gasto, });
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al darle de baja: " + ex.Message;
            }
            return Json(respuesta);
        }
    }
}