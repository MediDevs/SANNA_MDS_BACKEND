namespace MDS.Dto
{

    public class MantenimientoPersonaMadDto
    {
        public long id_persona { get; set; }
        public long id_documento { get; set; }

        public long id_pais { get; set; }

        public string numero_documento { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        //public DateTime fecha_nacimiento { get; set; }
        public int genero { get; set; }
        //public string descripcion { get; set; }
        public string telefono_celular { get; set; }
        public bool estado { get; set; }
        public int usuario_creacion { get; set; }
        //public DateTime fecha_creacion { get; set; }

    }

    public class MantenimientoPersonaMadActualizarDto
    {
        public long id_persona { get; set; }
        public long id_documento { get; set; }
        public long id_pais { get; set; }
        public string numero_documento { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string email { get; set; }
        public int genero { get; set; }
        public string telefono_celular { get; set; }
        public bool estado { get; set; }
        public int usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }


    public class MantenimientoPersonasDto
    {
        public long? Id_persona { get; set; }
        public long? id_tipopersona { get; set; }
        public int? id_pais { get; set; }
        public int? id_ubigeo { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public DateTime fecha_naciemiento { get; set; }
        public string genero { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
        public string? direccion { get; set; }
        public string? email1 { get; set; }
        public string? email2 { get; set; }
        public string? telefono_casa { get; set; }
        public string telefono_celular { get; set; }
        public string? telefono_corporativo { get; set; }
        //public bool? estado { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public int? usuario_modificacion { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        //public long id_persona { get; set; }
        //public long id_documento { get; set; }
        //public int id_pais { get; set; }
        ////public string id_ubigeo { get; set; }
        //public string numero { get; set; }
        //public string nombres { get; set; }
        //public string paterno { get; set; }
        //public string materno { get; set; }
        //public string email { get; set; }
        //public DateTime fechanacimiento { get; set; }
        //public string genero { get; set; }
        ////public string direccion { get; set; }
        //public int usuariocreacion { get; set; }
        //public string telefonocasa { get; set; }
        //public string telefonocelular { get; set; }
    }


    public class PersonaDniDto
    {
        public string dni { get; set; }
    }

    public class PersonaCodigoDto
    {
        public int id_persona { get; set; }
    }
    public class PersonaDto
    {
        public int id_persona { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public string genero { get; set; }
        //public bool estado { get; set; }
    }

    public class MantenimientoPersonaDto
    {
        public long? Id_persona { get; set; }
        public long? id_tipopersona { get; set; }
        public int? id_pais { get; set; }
        public int? id_ubigeo { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public DateTime fecha_naciemiento { get; set; }
        public string genero { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
        public string? direccion { get; set; }
        public string? email1 { get; set; }
        public string? email2 { get; set; }
        public string? telefono_casa { get; set; }
        public string telefono_celular { get; set; }
        public string? telefono_corporativo { get; set; }
        //public bool? estado { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public int? usuario_modificacion { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }

}