namespace Layers
{
    public class Presupuesto_BE
    {
        public int id_usuario{ get; set; }
        public int mes{ get; set; }
        public int anio{ get; set; }
        public int estado { get; set; }
        public string tipo_fondo { get; set; } = string.Empty;
        public int id_presupuesto { get; set; }
        public int id_tipo_gasto { get; set; }
        public decimal monto { get; set; }
        public string tipo_gasto{ get; set; } = string.Empty;
    }
}