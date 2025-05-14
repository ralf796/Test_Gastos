namespace Layers
{
    public class Usuario_DAL
    {
        public static List<Usuario_BE> Login(Usuario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_login");
            unitOfWork.AddParameter("usuario", item.usuario);
            unitOfWork.AddParameter("password", item.password);
            List<Usuario_BE> result = unitOfWork.GetData<Usuario_BE>();
            unitOfWork.Dispose();
            return result;
        }
        public static List<Usuario_BE> ListarUsuarios(Usuario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_listar_usuario");
            List<Usuario_BE> result = unitOfWork.GetData<Usuario_BE>();
            unitOfWork.Dispose();
            return result;
        }
        public static List<Usuario_BE> GetUsuario(Usuario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_listar_usuario_por_id");
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            List<Usuario_BE> result = unitOfWork.GetData<Usuario_BE>();
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Guardar(Usuario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_insertar_usuario");
            unitOfWork.AddParameter("IDENTIFICACION", item.identificacion);
            unitOfWork.AddParameter("NOMBRE", item.nombre);
            unitOfWork.AddParameter("APELLIDO", item.apellido);
            unitOfWork.AddParameter("USUARIO", item.usuario);
            unitOfWork.AddParameter("PASSWORD", item.password);
            unitOfWork.AddParameter("FECHA_NACIMIENTO", item.fecha_nacimiento);
            unitOfWork.AddParameter("DIRECCION", item.direccion);
            unitOfWork.AddParameter("CORREO", item.correo);
            unitOfWork.AddParameter("TELEFONO", item.telefono);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            return result;
        }
        public static Respuesta Modificar(Usuario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_modificar_usuario");
            unitOfWork.AddParameter("ID_USUARIO", item.id_usuario);
            unitOfWork.AddParameter("IDENTIFICACION", item.identificacion);
            unitOfWork.AddParameter("NOMBRE", item.nombre);
            unitOfWork.AddParameter("APELLIDO", item.apellido);
            unitOfWork.AddParameter("USUARIO", item.usuario);
            unitOfWork.AddParameter("FECHA_NACIMIENTO", item.fecha_nacimiento);
            unitOfWork.AddParameter("DIRECCION", item.direccion);
            unitOfWork.AddParameter("CORREO", item.correo);
            unitOfWork.AddParameter("TELEFONO", item.telefono);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
        public static Respuesta Delete(Usuario_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_eliminar_usuario");
            unitOfWork.AddParameter("id_usuario", item.id_usuario);
            Respuesta result = new Respuesta();
            result.Codigo = unitOfWork.ExecuteNonQuery();
            result.Resultado = true;
            unitOfWork.Dispose();
            return result;
        }
    }
}