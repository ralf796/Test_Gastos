namespace Layers
{
    public class Fondo_Monetario_BLL
    {
        public static List<Fondo_Monetario_BE> Listar(Fondo_Monetario_BE item) => Fondo_Monetario_DAL.Listar(item);        
        public static Respuesta Guardar(Fondo_Monetario_BE item) => Fondo_Monetario_DAL.Guardar(item);
        public static Respuesta Modificar(Fondo_Monetario_BE item) => Fondo_Monetario_DAL.Modificar(item);
        public static Respuesta Delete(Fondo_Monetario_BE item) => Fondo_Monetario_DAL.Delete(item);
    }
}