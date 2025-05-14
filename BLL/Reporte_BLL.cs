namespace Layers
{
    public class Reporte_BLL
    {
        public static List<Reporte_BE> RepDepositos(Reporte_BE item) => Reporte_DAL.RepDepositos(item);        
        public static List<Reporte_BE> RepGastos(Reporte_BE item) => Reporte_DAL.RepGastos(item);        
        public static List<Grafico_BE> Graficos(Grafico_BE item) => Reporte_DAL.Graficos(item);        
    }
}