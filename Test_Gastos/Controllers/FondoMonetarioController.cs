using Layers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test_Gastos.Controllers
{
    public class FondoMonetarioController : SessionController
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
            List<Fondo_Monetario_BE> lista = Fondo_Monetario_BLL.Listar(new Fondo_Monetario_BE());
            return PartialView(lista);
        }

        [HttpPost]
        public IActionResult Guardar(string descripcion = "", int id_tipo_fondo = 0, decimal saldo = 0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Fondo_Monetario_BE item = new Fondo_Monetario_BE
                {
                    descripcion = descripcion,
                    id_tipo_fondo = id_tipo_fondo,
                    saldo = saldo,
                    id_usuario = UsuarioActivo.IdUsuario
                };
                respuesta = Fondo_Monetario_BLL.Guardar(item);
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = ex.Message;
            }
            return Json(respuesta);
        }

        [HttpPost]
        public IActionResult Modificar(int id_fondo = 0, string descripcion = "", int id_tipo_fondo = 0, decimal saldo = 0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Fondo_Monetario_BE item = new Fondo_Monetario_BE
                {
                    id_fondo = id_fondo,
                    descripcion = descripcion,
                    id_tipo_fondo = id_tipo_fondo,
                    id_usuario = UsuarioActivo.IdUsuario,
                    saldo = saldo
                };
                respuesta = Fondo_Monetario_BLL.Modificar(item);
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al actualizar: " + ex.Message;
            }
            return Json(respuesta);
        }

        [HttpPost]
        public IActionResult Eliminar(int id_fondo = 0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = Fondo_Monetario_BLL.Delete(new Fondo_Monetario_BE { id_fondo = id_fondo });
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al darle de baja: " + ex.Message;
            }
            return Json(respuesta);
        }
    }
}