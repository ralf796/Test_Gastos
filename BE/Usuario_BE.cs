namespace Layers
{
    public class Usuario_BE
    {
        public string PRIMER_NOMBRE { get; set; } = string.Empty;
        public string SEGUNDO_NOMBRE { get; set; } = string.Empty;
        public string PRIMER_APELLIDO { get; set; } = string.Empty;
        public string SEGUNDO_APELLIDO { get; set; } = string.Empty;
        public string CELULAR { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public int id_rol { get; set; }
        public int id_usuario { get; set; }
        public string password { get; set; } = string.Empty;
        public string NOMBRE_ROL { get; set; } = string.Empty;
        public string? path { get; set; }
        public int ID_EMPLEADO { get; set; }
        public int CODPADRE { get; set; }
        public int CODMENU { get; set; }
        public int ORDEN { get; set; }
        public string ICONO { get; set; } = string.Empty;
        public string LINK { get; set; } = string.Empty;
        public int tipo { get; set; }
        public int port { get; set; }
        public string email_cc { get; set; } = string.Empty;
        public string email_cco { get; set; } = string.Empty;
        public string email_server { get; set; } = string.Empty;
        public string display_name { get; set; } = string.Empty;
        public string nombre_sistema { get; set; } = string.Empty;
        public string logo_codemind { get; set; } = string.Empty;
        public string logo_empresa { get; set; } = string.Empty;
        public int login { get; set; }
        public int id_empresa { get; set; }
        public string nombre_empresa { get; set; } = string.Empty;
        public int id_sucursal { get; set; }
        public string nombre_sucursal { get; set; } = string.Empty;
        public string correo_sucursal { get; set; } = string.Empty;
        public string direccion_sucursal { get; set; } = string.Empty;
        public string telefono_sucursal { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public string url_fotografia { get; set; } = string.Empty;
        public string cui { get; set; } = string.Empty;
        public int genero { get; set; }
        public string telefono { get; set; } = string.Empty;
        public int id_departamento { get; set; }
        public int id_municipio { get; set; }
        public int id_canton { get; set; }
        public string correo { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public DateTime fecha_nacimiento { get; set; }
        public string creado_por { get; set; } = string.Empty;
        public int estado { get; set; }
        public int tiene_usuario { get; set; }
        public int id_vestimenta { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public string imagen { get; set; } = string.Empty;
        public int id_devoto { get; set; }
        public string path_foto { get; set; } = string.Empty;
        public int id_menu { get; set; }
        public int cod_padre { get; set; }
        public int pago_mensual { get; set; }
        public int dia_vencimiento { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public int pendiente_de_pago { get; set; }
        public int bloqueo_sistema { get; set; }
        public string identificacion { get; set; } = string.Empty;
        public string usuario{ get; set; } = string.Empty;
        public string fecha_nacimiento_string { get; set; } = string.Empty;
    }
}
