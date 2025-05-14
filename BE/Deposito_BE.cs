namespace Layers
{
    public class Deposito_BE
    {
        public int id_deposito { get; set; }
        public DateTime fecha { get; set; }
        public int id_fondo { get; set; }
        public decimal monto { get; set; }
        public int id_usuario { get; set; }
        public int estado { get; set; }
        public string fondo_monetario { get; set; } = string.Empty;
        public string usuario { get; set; } = string.Empty;
    }
}