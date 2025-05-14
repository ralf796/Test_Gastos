using Layers;

namespace Test_Gastos.Models
{
    public class ReporteViewModel
    {
        public int tipo { get; set; }
        public List<Reporte_BE> lista { get; set; } = new List<Reporte_BE>();
    }
}
