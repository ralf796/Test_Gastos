namespace Layers
{
    public class Fondo_Monetario_DAL
    {
        public static List<Fondo_Monetario_BE> Listar(Fondo_Monetario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_listar_fondo_monetario");
            List<Fondo_Monetario_BE> result = unitOfWork.GetData<Fondo_Monetario_BE>();
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Guardar(Fondo_Monetario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_insertar_fondo_monetario");
            unitOfWork.AddParameter("descripcion", item.descripcion);
            unitOfWork.AddParameter("id_tipo_fondo", item.id_tipo_fondo);
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            unitOfWork.AddParameter("saldo", item.saldo);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            return result;
        }
        public static Respuesta Modificar(Fondo_Monetario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_modificar_fondo_monetario");
            unitOfWork.AddParameter("id_fondo", item.id_fondo);
            unitOfWork.AddParameter("descripcion", item.descripcion);
            unitOfWork.AddParameter("id_tipo_fondo", item.id_tipo_fondo);
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            unitOfWork.AddParameter("saldo", item.saldo);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Delete(Fondo_Monetario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_eliminar_fondo_monetario");
            unitOfWork.AddParameter("id_fondo", item.id_fondo);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
    }
}