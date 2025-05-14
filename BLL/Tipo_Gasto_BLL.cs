namespace Layers
{
    public class Tipo_Gasto_BLL
    {
        public static List<Tipo_Gasto_BE> Listar(Tipo_Gasto_BE item) => Tipo_Gasto_DAL.Listar(item);
        public static Respuesta Guardar(Tipo_Gasto_BE item) => Tipo_Gasto_DAL.Guardar(item);
        public static Respuesta Modificar(Tipo_Gasto_BE item) => Tipo_Gasto_DAL.Modificar(item);
        public static Respuesta Delete(Tipo_Gasto_BE item) => Tipo_Gasto_DAL.Delete(item);
    }
}