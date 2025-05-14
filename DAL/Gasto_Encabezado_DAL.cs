namespace Layers
{
    public class Gasto_Encabezado_DAL
    {
        public static List<Gasto_Encabezado_BE> Listar(Gasto_Encabezado_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_listar_gasto_encabezado");
            List<Gasto_Encabezado_BE> result = unitOfWork.GetData<Gasto_Encabezado_BE>();
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Guardar(Gasto_Encabezado_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_insertar_gasto_encabezado");
            unitOfWork.AddParameter("id_fondo", item.id_fondo);
            unitOfWork.AddParameter("observaciones", item.observaciones);
            unitOfWork.AddParameter("nombre_comercio", item.nombre_comercio);
            unitOfWork.AddParameter("tipo_documento", item.tipo_documento);
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteScalar<int>();
            result.Resultado = true;
            return result;
        }        
        public static Respuesta Eliminar(Gasto_Encabezado_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_eliminar_gasto");
            unitOfWork.AddParameter("id_gasto_encabezado", item.id_gasto_encabezado);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
    }
}