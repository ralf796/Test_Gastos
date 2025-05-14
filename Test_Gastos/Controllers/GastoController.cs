using Layers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Test_Gastos.Controllers
{
    [Authorize]
    public class GastoController : SessionController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DataTable()
        {
            List<Gasto_Encabezado_BE> lista = Gasto_Encabezado_BLL.Listar(new Gasto_Encabezado_BE());
            return PartialView(lista);
        }

        public IActionResult DataTableDetalle(int id_gasto_encabezado = 0)
        {
            List<Gasto_Detalle_BE> lista = Gasto_Detalle_BLL.Listar(new Gasto_Detalle_BE { id_gasto_encabezado = id_gasto_encabezado });
            return PartialView(lista);
        }

        [HttpPost]
        public IActionResult Guardar(int id_fondo = 0, string observaciones = "", string nombre_comercio = "", string tipo_documento = "", int id_usuario = 0, List<Gasto_Detalle_BE> detalles = null)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (detalles == null || detalles.Count == 0)
                {
                    respuesta.Descripcion = "El gasto debe contener al menos un detalle.";
                    return Json(respuesta);
                }

                Gasto_Encabezado_BE encabezado = new Gasto_Encabezado_BE
                {
                    id_fondo = id_fondo,
                    observaciones = observaciones,
                    nombre_comercio = nombre_comercio,
                    tipo_documento = tipo_documento,
                    id_usuario = UsuarioActivo.IdUsuario,
                    estado = 1
                };
                Respuesta respuesta_enc = Gasto_Encabezado_BLL.Guardar(encabezado);
                if (respuesta_enc.Resultado)
                {
                    foreach (var detalle in detalles)
                    {
                        detalle.id_gasto_encabezado = respuesta_enc.Codigo;
                        Gasto_Detalle_BLL.Guardar(detalle);
                    }
                }
                respuesta.Resultado = true;
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al guardar el gasto: " + ex.Message;
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
        public IActionResult TipoGasto()
        {
            List<Tipo_Gasto_BE> lista = Tipo_Gasto_BLL.Listar(new Tipo_Gasto_BE());
            if (lista.Count > 0)
                lista = lista.Where(x => x.estado == 1).ToList();
            return Json(lista);
        }

        [HttpPost]
        public IActionResult Eliminar(int id_gasto = 0)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = Gasto_Encabezado_BLL.Eliminar(new Gasto_Encabezado_BE { id_gasto_encabezado = id_gasto });
            }
            catch (Exception ex)
            {
                respuesta.Descripcion = "Error al darle de baja: " + ex.Message;
            }
            return Json(respuesta);
        }
    }
}