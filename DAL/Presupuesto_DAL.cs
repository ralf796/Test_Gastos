namespace Layers
{
    public class Presupuesto_DAL
    {
        public static List<Presupuesto_BE> Listar(Presupuesto_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_listar_presupuesto_por_usuario");
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            unitOfWork.AddParameter("mes", item.mes);
            unitOfWork.AddParameter("anio", item.anio);
            List<Presupuesto_BE> result = unitOfWork.GetData<Presupuesto_BE>();
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Modificar(Presupuesto_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_insertar_presupuesto");
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            unitOfWork.AddParameter("id_tipo_gasto", item.id_tipo_gasto);
            unitOfWork.AddParameter("monto", item.monto);
            unitOfWork.AddParameter("mes", item.mes);
            unitOfWork.AddParameter("anio", item.anio);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Guardar(Presupuesto_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_insertar_presupuesto");
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            unitOfWork.AddParameter("id_tipo_gasto", item.id_tipo_gasto);
            unitOfWork.AddParameter("monto", item.monto);
            unitOfWork.AddParameter("mes", item.mes);
            unitOfWork.AddParameter("anio", item.anio);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            return result;
        }
        public static Respuesta Eliminar(Presupuesto_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_eliminar_presupuesto");
            unitOfWork.AddParameter("id_presupuesto", item.id_presupuesto);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            return result;
        }
    }
}