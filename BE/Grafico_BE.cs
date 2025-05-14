namespace Layers
{
    public class Grafico_BE
    {
        public DateTime fecha1 { get; set; }
        public DateTime fecha2 { get; set; }
        public string tipo_gasto { get; set; } = string.Empty;
        public decimal monto_presupuestado { get; set; }
        public decimal monto_ejecutado { get; set; }
    }
}
