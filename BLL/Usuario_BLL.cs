namespace Layers
{
    public class Usuario_BLL
    {
        public static List<Usuario_BE> Login(Usuario_BE item) => Usuario_DAL.Login(item);
        public static List<Usuario_BE> ListarUsuarios(Usuario_BE item) => Usuario_DAL.ListarUsuarios(item);
        public static List<Usuario_BE> GetUsuario(Usuario_BE item) => Usuario_DAL.GetUsuario(item);
        public static Respuesta Guardar(Usuario_BE item) => Usuario_DAL.Guardar(item);
        public static Respuesta Modificar(Usuario_BE item) => Usuario_DAL.Modificar(item);
        public static Respuesta Delete(Usuario_BE item) => Usuario_DAL.Delete(item);
    }
}