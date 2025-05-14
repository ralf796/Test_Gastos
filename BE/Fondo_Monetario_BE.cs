namespace Layers
{
    public class Fondo_Monetario_BE
    {
        public int id_fondo { get; set; }
        public int id_tipo_fondo { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public string usuario { get; set; } = string.Empty;
        public decimal saldo { get; set; }
        public int id_usuario { get; set; }
        public int estado { get; set; }
        public string tipo_fondo { get; set; } = string.Empty;
    }
}