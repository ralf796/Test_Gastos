namespace Layers
{
    public class Gasto_Detalle_DAL
    {
        public static List<Gasto_Detalle_BE> Listar(Gasto_Detalle_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_listar_gasto_detalle");
            unitOfWork.AddParameter("id_gasto_encabezado", item.id_gasto_encabezado);
            List<Gasto_Detalle_BE> result = unitOfWork.GetData<Gasto_Detalle_BE>();
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Guardar(Gasto_Detalle_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_insertar_gasto_detalle");
            unitOfWork.AddParameter("id_gasto_encabezado", item.id_gasto_encabezado);
            unitOfWork.AddParameter("id_tipo_gasto", item.id_tipo_gasto);
            unitOfWork.AddParameter("monto", item.monto);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            return result;
        }                
    }
}