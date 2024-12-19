namespace MDS.DbContext.Entities
{
    public class Persona
    {
        public int CPER_ID { get; set; }
        public string SPER_APELLIDO_PATERNO { get; set; }
        public string SPER_APELLIDO_MATERNO { get; set; }
        public string SPER_NOMBRES { get; set; }
        public string SPER_NUMERO_DOCUMENTO { get; set; }
        public string NPER_GENERO { get; set; }
        //public bool FPER_ESTADO { get; set; }
    }
    public class MantenimientoPersonaMad
    {
        public long CTDO_ID { get; set; }

        public long CPAI_ID { get; set; }

        public string SPER_NUMERO_DOCUMENTO { get; set; }

        public string SPER_NOMBRES { get; set; }

        public string SPER_APELLIDO_PATERNO { get; set; }

        public string SPER_APELLIDO_MATERNO { get; set; }

        //public DateTime DPER_FECHA_NACIMIENTO { get; set; }

        public int NPER_GENERO { get; set; }

        //public string SDIR_DESCRIPCION { get; set; }

        public string SPER_TELEFONO_CELULAR { get; set; }

        public bool FPER_ESTADO { get; set; }

        public int NPER_USUARIO_CREACION { get; set; }

        //public DateTime DPER_FECHA_CREACION { get; set; }
    }

    public class MantenimientoPersonaMadActualizar
    {
        public long CPER_ID { get; set; }
        public long CTDO_ID { get; set; }
        public long CPAI_ID { get; set; }
        public string SPER_NUMERO_DOCUMENTO { get; set; }
        public string SPER_NOMBRES { get; set; }
        public string SPER_APELLIDO_PATERNO { get; set; }
        public string SPER_APELLIDO_MATERNO { get; set; }
        public DateTime DPER_FECHA_NACIMIENTO { get; set; }
        public string SPER_EMAIL { get; set; }
        public int NPER_GENERO { get; set; }
        public string SPER_TELEFONO_CELULAR { get; set; }
        public bool FPER_ESTADO { get; set; }
        public int NPER_USUARIO_MODIFICACION { get; set; }
        public DateTime DPER_FECHA_MODIFICACION { get; set; }
    }

    public class MantenimientoPersonas
    {
        public int CPAI_IDPAIS { get; set; }
        public int CUBI_IDUBIGEO { get; set; }
        public string SPER_NOMBRES { get; set; }
        public string SPER_APELLIDO_PATERNO { get; set; }
        public string SPER_APELLIDO_MATERNO { get; set; }
        public string SPER_NUMERO_DOCUMENTO { get; set; }
        public DateTime DPER_FECHA_NACIMIENTO { get; set; }
        public string NPER_GENERO { get; set; }
        public string SPER_DEPARTAMENTO { get; set; }
        public string SPER_PROVINCIA { get; set; }
        public string SPER_DISTRITO { get; set; }
        public string SPER_DIRECCION { get; set; }
        public string SPER_EMAIL1 { get; set; }
        public string SPER_EMAIL2 { get; set; }
        public string SPER_TELEFONO_CASA { get; set; }
        public string SPER_TELEFONO_CELULAR { get; set; }
        public string SPER_TELEFONO_CORPORATIVO { get; set; }
        //public bool FPER_ESTADO { get; set; }
        public int NPER_USUARIO_CREACION { get; set; }
        public DateTime NPER_FECHA_CREACION { get; set; }
        public int NPER_USUARIO_MODIFICACION { get; set; }
        public DateTime DPER_FECHA_MODIFICACION { get; set; }
        //public int CPAI_ID { get; set; }
        //public long CTDO_ID { get; set; }
        ////public string CUBI_ID { get; set; }
        //public string SPER_NOMBRES { get; set; }
        //public string SPER_APELLIDO_PATERNO { get; set; }
        //public string SPER_APELLIDO_MATERNO { get; set; }
        //public string SPER_NUMERO_DOCUMENTO { get; set; }
        //public DateTime DPER_FECHA_NACIMIENTO { get; set; }
        //public string NPER_GENERO { get; set; }
        //public string SPER_EMAIL { get; set; }
        ////public string SPER_DIRECCION { get; set; }
        //public int NPER_USUARIO_CREACION { get; set; }
        //public string SPER_TELEFONO_CASA { get; set; }
        //public string SPER_TELEFONO_CELULAR { get; set; }
    }
    
    public class MantenimientoPersona
    {
        public int CPAI_IDPAIS { get; set; }
        public int CUBI_IDUBIGEO { get; set; }
        public string SPER_NOMBRES { get; set; }
        public string SPER_APELLIDO_PATERNO { get; set; }
        public string SPER_APELLIDO_MATERNO { get; set; }
        public string SPER_NUMERO_DOCUMENTO { get; set; }
        public DateTime DPER_FECHA_NACIMIENTO { get; set; }
        public string NPER_GENERO { get; set; }
        public string SPER_DEPARTAMENTO { get; set; }
        public string SPER_PROVINCIA { get; set; }
        public string SPER_DISTRITO { get; set; }
        public string SPER_DIRECCION { get; set; }
        public string SPER_EMAIL1 { get; set; }
        public string SPER_EMAIL2 { get; set; }
        public string SPER_TELEFONO_CASA { get; set; }
        public string SPER_TELEFONO_CELULAR { get; set; }
        public string SPER_TELEFONO_CORPORATIVO { get; set; }
        //public bool FPER_ESTADO { get; set; }
        public int NPER_USUARIO_CREACION { get; set; }
        public DateTime NPER_FECHA_CREACION { get; set; }
        public int NPER_USUARIO_MODIFICACION { get; set; }
        public DateTime DPER_FECHA_MODIFICACION { get; set; }
    }

    public class PersonaDni
    {
        public string SPER_NUMERO_DOCUMENTO { get; set; }

    }

    public class PersonaCodigo
    {
        public int CPER_ID { get; set; }
    }


}
