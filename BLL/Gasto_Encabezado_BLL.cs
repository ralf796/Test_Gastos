namespace Layers
{
    public class Gasto_Encabezado_BLL
    {
        public static List<Gasto_Encabezado_BE> Listar(Gasto_Encabezado_BE item) => Gasto_Encabezado_DAL.Listar(item);
        public static Respuesta Guardar(Gasto_Encabezado_BE item) => Gasto_Encabezado_DAL.Guardar(item);        
        public static Respuesta Eliminar(Gasto_Encabezado_BE item) => Gasto_Encabezado_DAL.Eliminar(item);
    }
}