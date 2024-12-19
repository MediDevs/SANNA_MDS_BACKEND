namespace MDS.Dto
{

    public class ClienteSitedsAseguradoDto
    {
        public int id_cliente { get; set; }

        public string id_financiamiento { get; set; }

    }

    public class ClienteSitedsDto
    {
        public int id_cliente { get; set; }

        public string codigo_financiamiento { get; set; }

        public string nombre { get; set; }
    }

    public class ClientesDto
    {
        public int id_cliente { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }

    }

    public class ClienteDto
    {
        public int id_cliente { get; set; }        
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public string? direccion { get; set; }
        public string? ubigeo { get; set; }
        public string? ruc { get; set; }
        public bool estado { get; set; }
    }

    public class MantenimientoClienteDto
    {
        public int? id_cliente { get; set; }
        public bool? estado { get; set; }
        public string nombre { get; set; }
        public string? descripcion { get; set; }
        public string? direccion { get; set; }
        public string? distrito { get; set; }
        public string ruc { get; set; }
        public int? dscto_ped { get; set; }
        public decimal? factor_lab { get; set; }
        public int? dscto_lab { get; set; }
        public decimal? costo { get; set; }
        public string? conv_emp { get; set; }
        public decimal? costo_alt { get; set; }
        public string? flag_tipo { get; set; }
        public bool? activi_operaciones { get; set; }
        public decimal? factor_lab_prov { get; set; }
        public bool? activo_fact { get; set; }
        public int? relacionado { get; set; }
        public bool? activo_lab { get; set; }
        public bool? activo_amb { get; set; }
        public bool? cliente_playa { get; set; }
        public string? email { get; set; }
        public string? urbanizacion { get; set; }
        public int? dias_plazo { get; set; }
        public string? cod_tipo_doc_id { get; set; }
        public string? email_con_copia { get; set; }
        public string? personal_contacto { get; set; }
        public string? tlf_contacto { get; set; }
        public int? id_doc_id { get; set; }
        public bool? sap_flg_registrado { get; set; }
        public bool? activo_dronline { get; set; }
        public bool? flg_cargar_bd { get; set; }
        public string? nom_aseg_onbase { get; set; }
        public bool? visible_melchorita { get; set; }
        public bool? visible_callmedico { get; set; }
        public int? dias_credito { get; set; }
        public bool? flg_capitado { get; set; }
        public bool? visible_home_care { get; set; }
        public int usuario_creacion { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public int? usuario_modificacion { get; set; }
        public DateTime? fecha_modificacion { get; set; }
    }
}
