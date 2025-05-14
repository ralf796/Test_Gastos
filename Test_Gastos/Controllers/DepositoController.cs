using Layers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test_Gastos.Controllers
{
    [Authorize]
    public class DepositoController : SessionController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DataTable()
        {
            List<Deposito_BE> lista = Deposito_BLL.Listar(new Deposito_BE());
            return PartialView(lista);
        }

        [HttpPost]
        public IActionResult Guardar(int id_fondo, decimal monto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                Deposito_BE item = new Deposito_BE
                {
                    id_fondo = id_fondo,
                    monto = monto,
                    id_usuario = UsuarioActivo.IdUsuario
                };

                respuesta = Deposito_BLL.Guardar(item);
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error: " + ex.Message;
            }
            return Json(respuesta);
        }

        [HttpPost]
        public IActionResult Eliminar(int id_deposito = 0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = Deposito_BLL.Eliminar(new Deposito_BE { id_deposito = id_deposito });
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al darle de baja: " + ex.Message;
            }
            return Json(respuesta);
        }

        public IActionResult FondoMonetario()
        {
            List<Fondo_Monetario_BE> lista = Fondo_Monetario_BLL.Listar(new Fondo_Monetario_BE());
            if (lista.Count > 0)
                lista = lista.Where(x => x.estado == 1).ToList();
            return Json(lista);
        }
    }
}