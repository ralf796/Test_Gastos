namespace Layers
{
    public class Gasto_Detalle_BLL
    {
        public static List<Gasto_Detalle_BE> Listar(Gasto_Detalle_BE item) => Gasto_Detalle_DAL.Listar(item);
        public static Respuesta Guardar(Gasto_Detalle_BE item) => Gasto_Detalle_DAL.Guardar(item);
    }
}