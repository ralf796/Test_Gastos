namespace Layers
{
    public class Presupuesto_BLL
    {
        public static List<Presupuesto_BE> Listar(Presupuesto_BE item) => Presupuesto_DAL.Listar(item);
        public static Respuesta Guardar(Presupuesto_BE item) => Presupuesto_DAL.Guardar(item);
        public static Respuesta Eliminar(Presupuesto_BE item) => Presupuesto_DAL.Eliminar(item);
    }
}