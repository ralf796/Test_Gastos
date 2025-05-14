namespace Layers
{
    public class Presupuesto_BLL
    {
        public static List<Presupuesto_BE> Listar(Presupuesto_BE item) => Presupuesto_DAL.Listar(item);
    }
}