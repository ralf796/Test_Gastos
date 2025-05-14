using Layers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test_Gastos.Controllers
{
    public class UsuarioController : SessionController
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
            List<Usuario_BE> lista = Usuario_BLL.ListarUsuarios(new Usuario_BE());
            return PartialView(lista);
        }

        [HttpPost]
        public IActionResult Guardar(
            string identificacion = "",
            string nombre = "",
            string apellido = "",
            string usuario = "",
            string password = "",
            string fecha_nacimiento = "",
            string direccion = "",
            string correo = "",
            string telefono = "")
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Usuario_BE item = new Usuario_BE
                {
                    identificacion = identificacion,
                    nombre = nombre,
                    apellido = apellido,
                    usuario = usuario,
                    password = password,
                    fecha_nacimiento = DateTime.Parse(fecha_nacimiento),
                    direccion = direccion,
                    correo = correo,
                    telefono = telefono
                };
                respuesta = Usuario_BLL.Guardar(item);
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = ex.Message;
            }
            return Json(respuesta);
        }


        [HttpPost]
        public JsonResult GetUsuario(int id_usuario)
        {
            try
            {
                Usuario_BE item = new Usuario_BE();
                List<Usuario_BE> lista = Usuario_BLL.GetUsuario(new Usuario_BE { id_usuario = id_usuario });

                if (lista.Count > 0)
                {
                    item = lista[0];
                    item.fecha_nacimiento_string = item.fecha_nacimiento.ToString("yyyy-MM-dd");
                }

                return Json(new
                {
                    success = true,
                    data = item
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Modificar(
        int id_usuario = 0,
        string identificacion = "",
        string nombre = "",
        string apellido = "",
        string usuario = "",
        string password = "",
        string fecha_nacimiento = "",
        string direccion = "",
        string correo = "",
        string telefono = "")
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Usuario_BE item = new Usuario_BE
                {
                    id_usuario = id_usuario,
                    identificacion = identificacion,
                    nombre = nombre,
                    apellido = apellido,
                    usuario = usuario,
                    password = password,
                    fecha_nacimiento = DateTime.Parse(fecha_nacimiento),
                    direccion = direccion,
                    correo = correo,
                    telefono = telefono
                };

                respuesta = Usuario_BLL.Modificar(item);
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al actualizar el usuario: " + ex.Message;
            }
            return Json(respuesta);
        }


        [HttpPost]
        public IActionResult Eliminar(int id_usuario = 0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = Usuario_BLL.Delete(new Usuario_BE { id_usuario = id_usuario, });
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al darle de baja al usuario: " + ex.Message;
            }
            return Json(respuesta);
        }
    }
}