namespace Layers
{
    public class Deposito_BLL
    {
        public static List<Deposito_BE> Listar(Deposito_BE item) => Deposito_DAL.Listar(item);        
        public static Respuesta Guardar(Deposito_BE item) => Deposito_DAL.Guardar(item);
        public static Respuesta Eliminar(Deposito_BE item) => Deposito_DAL.Eliminar(item);
    }
}