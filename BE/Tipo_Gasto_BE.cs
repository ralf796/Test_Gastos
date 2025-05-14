namespace Layers
{
    public class Tipo_Gasto_BE
    {
        public int id_tipo_gasto { get; set; }
        public string codigo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public int estado { get; set; }
    }
}
