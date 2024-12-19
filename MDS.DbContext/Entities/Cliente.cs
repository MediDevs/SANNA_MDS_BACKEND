using MDS.Infrastructure.DbUtility;

namespace MDS.DbContext.Entities
{

    public class ClienteSiteds
    {
        public int CCLT_ID { get; set; }

        public string SIAF_FINANCIAMIENTO { get; set; }

        public string SCLT_NOMBRE { get; set; }
    }

    public class ClienteSitedsAsegurado
    {
        public int CCLT_ID { get; set; }

        public string SIAF_FINANCIAMIENTO { get; set; }

    }
    public class ClienteSitedsAseguradora
    {
        public int CCLT_ID { get; set; }

        public string SIAF_FINANCIAMIENTO { get; set; }

    }

    public class Clientes
    {
        public int CCLT_ID { get; set; }

        public string? SCLT_NOMBRE { get; set; }

        public string SSCE_DESCRIPCION { get; set; }

    }

    public class Cliente
    {        
        public int CCLT_ID { get; set; }
        public string? SCLT_NOMBRE { get; set; }
        public string? SCLT_DESCRIPCION { get; set; }
        public string? SCLT_DIRECCION { get; set; }
        public string? CUBI_UBIGEO { get; set; }
        public string? SCLT_RUC { get; set; }
        public bool FCLT_ESTADO { get; set; }
    }


    public class MantenimientoCliente
    {
        public bool FCLT_ESTADO { get; set; }
        public int CCLT_ID { get; set; }
        public string? SCLT_NOMBRE { get; set; }
        public string? SCLT_DESCRIPCION { get; set; }
        public string? SCLT_DIRECCION { get; set; }
        public string? SCLT_DISTRITO { get; set; }
        public string? SCLT_RUC { get; set; }
        public int NCLT_DSCTO_PED { get; set; }
        public decimal NCLT_FACTOR_LAB { get; set; }
        public int NCLT_DSCTO_LAB { get; set; }
        public decimal NCLT_COSTO { get; set; }
        public string? CCLT_CONV_EMP { get; set; }
        public decimal NCLT_COSTO_ALT { get; set; }
        public string? SCLT_FLAG_TIPO { get; set; }
        public bool FCLT_ACTIVI_OPERACIONES { get; set; }
        public decimal NCLT_FACTOR_LAB_PROV { get; set; }
        public bool FCLT_ACTIVO_FACT { get; set; }
        public int NCLT_RELACIONADO { get; set; }
        public bool FCLT_ACTIVO_LAB { get; set; }
        public bool FCLT_ACTIVO_AMB { get; set; }
        public bool FCLT_CLIENTE_PLAYA { get; set; }
        public string? SCLT_EMAIL { get; set; }
        public string? SCLT_URBANIZACION { get; set; }
        public int NCLT_DIAS_PLAZO { get; set; }
        public string SCLT_COD_TIPO_DOC_ID { get; set; }
        public string SCLT_EMAIL_CON_COPIA { get; set; }
        public string SCLT_PERSONAL_CONTACTO { get; set; }
        public string SCLT_TLF_CONTACTO { get; set; }
        public int NCLT_ID_DOC_ID { get; set; }
        public bool FCLT_SAP_FLG_REGISTRADO { get; set; }
        public bool FCLT_ACTIVO_DRONLINE { get; set; }
        public bool FCLT_FLG_CARGAR_BD { get; set; }
        public string? SCLT_NOM_ASEG_ONBASE { get; set; }
        public bool SCLT_VISIBLE_MELCHORITA { get; set; }
        public bool SCLT_VISIBLE_CALLMEDICO { get; set; }
        public int NCLT_DIAS_CREDITO { get; set; }
        public bool FCLT_FLG_CAPITADO { get; set; }
        public bool FCLT_VISIBLE_HOME_CARE { get; set; }
        public int NCLT_USUARIO_CREACION { get; set; }
        public DateTime DCLT_FECHA_CREACION { get; set; }
        public int NCLT_USUARIO_MODIFICACION { get; set; }
        public DateTime DCLT_FECHA_MODIFICACION { get; set; }
    }

    public class ClientesSiteds
    {
        //public string CCLT_ID { get; set; }
        public int id { get; set; }
        public string codigo_financiamiento { get; set; }
        public string? nombre { get; set; }

    }
}