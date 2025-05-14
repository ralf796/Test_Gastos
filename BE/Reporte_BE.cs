namespace Layers
{
    public class Reporte_BE
    {
        public DateTime fecha1 { get; set; }
        public DateTime fecha2 { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; } = string.Empty;
        public string nombre_comercio { get; set; } = string.Empty;
        public string tipo_documento { get; set; } = string.Empty;
        public string usuario { get; set; } = string.Empty;
        public int estado { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public string tipo_gasto { get; set; } = string.Empty;
        public decimal monto { get; set; }
    }
}