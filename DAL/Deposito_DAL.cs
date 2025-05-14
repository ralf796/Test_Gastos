namespace Layers
{
    public class Deposito_DAL
    {
        public static List<Deposito_BE> Listar(Deposito_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_listar_depositos");
            List<Deposito_BE> result = unitOfWork.GetData<Deposito_BE>();
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Guardar(Deposito_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_insertar_deposito");
            unitOfWork.AddParameter("id_fondo", item.id_fondo);
            unitOfWork.AddParameter("monto", item.monto);
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            return result;
        }
        public static Respuesta Eliminar(Deposito_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_eliminar_deposito");
            unitOfWork.AddParameter("id_deposito", item.id_deposito);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
    }
}