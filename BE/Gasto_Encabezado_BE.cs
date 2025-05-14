namespace Layers
{
    public class Gasto_Encabezado_BE
    {
        public int id_gasto_encabezado { get; set; }
        public DateTime fecha { get; set; }
        public int id_fondo{ get; set; }
        public string observaciones { get; set; } = string.Empty;
        public string nombre_comercio { get; set; } = string.Empty;
        public string tipo_documento { get; set; } = string.Empty;
        public int id_usuario { get; set; }
        public int estado { get; set; }
        public string usuario{ get; set; } = string.Empty;
        public string descripcion{ get; set; } = string.Empty;
    }
}
