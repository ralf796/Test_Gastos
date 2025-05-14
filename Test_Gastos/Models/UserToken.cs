using System.Security.Claims;

namespace Test_Gastos.Models
{
    public class UserToken
    {
        public UserToken(ClaimsPrincipal user)
        {
            Claim? parameter;
            parameter = user.Claims.FirstOrDefault(x => x.Type == "Usuario");
            if (parameter != null)
                Usuario = parameter.Value;
            parameter = user.Claims.FirstOrDefault(x => x.Type == "primer_nombre");
            if (parameter != null)
                primer_nombre = parameter.Value;
            parameter = user.Claims.FirstOrDefault(x => x.Type == "primer_apellido");
            if (parameter != null)
                primer_apellido = parameter.Value;
            parameter = user.Claims.FirstOrDefault(x => x.Type == "IdUsuario");
            if (parameter != null)
                IdUsuario = Convert.ToInt32(parameter.Value);
            parameter = user.Claims.FirstOrDefault(x => x.Type == "PathFoto");
            if (parameter != null)
                PathFoto = parameter.Value;
        }
        public string Usuario { get; set; } = string.Empty;
        public string primer_nombre { get; set; } = string.Empty;
        public string primer_apellido { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public string PathFoto { get; set; } = string.Empty;
    }
}