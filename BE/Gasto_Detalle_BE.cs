namespace Layers
{
    public class Gasto_Detalle_BE
    {
        public int id_gasto_detalle { get; set; }
        public int id_gasto_encabezado { get; set; }
        public int id_tipo_gasto { get; set; }
        public decimal monto { get; set; }
        public string descripcion { get; set; } = string.Empty;
    }
}