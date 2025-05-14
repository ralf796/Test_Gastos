namespace Layers
{
    public class Tipo_Gasto_DAL
    {        
        public static List<Tipo_Gasto_BE> Listar(Tipo_Gasto_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_listar_tipo_gasto");
            List<Tipo_Gasto_BE> result = unitOfWork.GetData<Tipo_Gasto_BE>();
            unitOfWork.Dispose();
            return result;
        }        
        public static Respuesta Guardar(Tipo_Gasto_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_insertar_tipo_gasto");
            unitOfWork.AddParameter("codigo", item.codigo);
            unitOfWork.AddParameter("descripcion", item.descripcion);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            return result;
        }
        public static Respuesta Modificar(Tipo_Gasto_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_modificar_tipo_gasto");
            unitOfWork.AddParameter("id_tipo_gasto", item.id_tipo_gasto);
            unitOfWork.AddParameter("codigo", item.codigo);
            unitOfWork.AddParameter("descripcion", item.descripcion);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Delete(Tipo_Gasto_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_eliminar_tipo_gasto");
            unitOfWork.AddParameter("id_tipo_gasto", item.id_tipo_gasto);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
    }
}