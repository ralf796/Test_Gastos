namespace Layers
{
    public class Reporte_DAL
    {
        public static List<Reporte_BE> RepDepositos(Reporte_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_reporte_deposito");
            unitOfWork.AddParameter("fecha_inicial", item.fecha1);
            unitOfWork.AddParameter("fecha_final", item.fecha2);
            List<Reporte_BE> result = unitOfWork.GetData<Reporte_BE>();
            unitOfWork.Dispose();
            return result;
        }        
        public static List<Reporte_BE> RepGastos(Reporte_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_reporte_gasto");
            unitOfWork.AddParameter("fecha_inicial", item.fecha1);
            unitOfWork.AddParameter("fecha_final", item.fecha2);
            List<Reporte_BE> result = unitOfWork.GetData<Reporte_BE>();
            unitOfWork.Dispose();
            return result;
        }        
        public static List<Grafico_BE> Graficos(Grafico_BE item)
        {
            Extensiones.UnitOfWork unitOfWork = new Extensiones.UnitOfWork("sp_reporte_grafico_presupuesto_vs_ejecucion");
            unitOfWork.AddParameter("fecha_inicio", item.fecha1);
            unitOfWork.AddParameter("fecha_final", item.fecha2);
            List<Grafico_BE> result = unitOfWork.GetData<Grafico_BE>();
            unitOfWork.Dispose();
            return result;
        }        
    }
}