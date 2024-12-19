using System.Data.SqlTypes;

namespace MDS.DbContext.Entities
{
    public class HistoriaClinicaUbigeo
    {
        public string CODIGO { get; set; }

        public string DEPARTAMENTO { get; set; }

        public string PROVINCIA { get; set; }

        public string DISTRITO { get; set; }
    
    }

    public class HistoriaClinicaCliente
    {
        public int CODIGO { get; set; }
        public string NUMERO { get; set; }
    }

    public class HistoriaClinicaPaciente_x_Numero
    {
        public int CODIGO { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string NOMBRES { get; set; }
        public string TIPODOCUMENTO { get; set; }
        public string DNI { get; set; }
        public string FECHANACIMIENTO { get; set; }
        public int EDAD { get; set; }
        public int GENERO { get; set; }
        public string EMAIL { get; set; }
        public string CELULAR { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string PROVINCIA { get; set; }
        public string DISTRITO { get; set; }
        public string? DIRECCION { get; set; }
        public string? LOTE { get; set; }
        public string? INTERIOR { get; set; }
        public string? URBANIZACION { get; set; }
        public string? REFERENCIA { get; set; }
    }
    public class HistoriaClinicaPaciente_x_Dni
    {
        public string DNI { get; set; }

        public string NOMBRES { get; set; } 

        public long CODIGO { get; set; }

    }


    public class HistoriaClinicaMedioComunicacionMad
    {
        public long CHIS_ID { get; set; }

        public long CHIS_COD { get; set; }
        public long NHIS_NUMERO { get; set; }
        public int NHIS_USUARIO_CREACION { get; set; }
        public string DHIS_FECHA_CREACION { get; set; }
    }

    public class HistoriaClinicaMtoMad
    {
        public long CHIS_ID { get; set; }
        public int CMED_ID { get; set; }

        public int CPAC_ID { get; set; }

        public int CESP_ID { get; set; }

        public int CEST_ID { get; set; }

        public int CPER_ID { get; set; }

        public int CSER_ID { get; set; }

        public int CPAI_ID { get; set; }

        public string CUBI_ID { get; set; }

        public int CMEP_ID { get; set; }

        public int CTDO_ID { get; set; }

        public int CCLT_ID { get; set; }

        public int CDSN_ID { get; set; }

        public string SHIS_ESTADO { get; set; }

        public string SHIS_F_PROG { get; set; }

        public string SHIS_COD { get; set; }

        public DateTime DHIS_FECLLA_ATE { get; set; }

        public DateTime DHIS_HORLLA_ATE { get; set; }

        public int NHIS_CM_TIEMPO { get; set; }

        public DateTime DHIS_FEC_ATE { get; set; }

        public DateTime DHIS_HOR_ATE { get; set; }

        public DateTime DHIS_HRLLEDR { get; set; }

        public DateTime DHIS_HOROPLLA_ATE { get; set; }

        public string SHIS_FOR_ATE { get; set; }

        public string SHIS_PAC_VIP { get; set; }

        public string SHIS_GRUPO_CRONICOS { get; set; }


        public int NHIS_CONTADOR_PERIODO { get; set; }

        public string SHIS_COD_TIPO_SEG_CRONICO { get; set; }

        public string SHIS_EMPRESA_PACIENTE { get; set; }


        //INICIO DE NUEVOS CAMPOS PARA REGISTRAR HC

        //public string SHIS_CM_ESTADO { get; set; }

        //public int NHIS_COD_ESTADO { get; set; }

        //public int NHIS_CM_ORDEN { get; set; }

        public bool FHIS_FLG_CM_NUEVA { get; set; }

        public string SHIS_USULLA_ATE { get; set; }

        public string SHIS_COD_EMP { get; set; }

        public bool FHIS_FLAG_PROGRMADA { get; set; }

        public string SHIS_F_SOLDOCT { get; set; }

        public int NHIS_MOTIVO_TIPO_PROG { get; set; }

        public string SHIS_OBSERVACION { get; set; }

        public string FHIS_CM_DIRECTA { get; set; }

        public string SHIS_FLG_DIRECTO { get; set; }

        public bool FHIS_CM_DATOS_COMPLETOS { get; set; }

        public Decimal NHIS_TAR_ATE { get; set; }

        public string SHIS_FLAGMONE { get; set; }

        public Decimal NHIS_CAMBIO { get; set; }

        public string SHIS_CODTAR_ATE { get; set; }

        public string NTAR_ATE { get; set; }

        public string SHIS_TARJ_MC { get; set; }

        public DateTime FVENC_ATE { get; set; }

        public string SHIS_SIN_ATE { get; set; }

        public string SHIS_CONTACTO_PAC { get; set; }

        public string SHIS_CONTACTO_ASEG { get; set; }

        public string SHIS_COD_AUT_PRESTACION { get; set; }

        public string SHIS_COD_ASEGURADO { get; set; }

        public string SHIS_COD_SOLGEN { get; set; }

        public string CM_ASEG_PRODUCTO { get; set; }

        public string SHIS_POLIZA_ASEGURADO { get; set; }

        public string SHIS_POLIZA_CERTIFICADO { get; set; }

        public string SHIS_TIPO_AFILIACION { get; set; }

        public int NHIS_ID_PAQUETE { get; set; }

        public bool FHIS_PRIMERA_CONSULTA { get; set; }

        public int NHIS_CLASIFICACION_PAC { get; set; }

        public int NHIS_PERIODO_CONSULTA { get; set; }

        public string SHIS_TIPO_SERVICIO { get; set; }

        public string SHIS_TIPO_ATE { get; set; }

        public bool FHIS_FLG_REPROGRAMADA { get; set; }

        public string SHIS_TIPO_DOC_PAGO { get; set; }

        public int NHIS_ID_CONDICION_ESPECIAL_PAGO { get; set; }

        public string SHIS_DESCRP_ZONA { get; set; }

        //public string SHIS_EMPRESA_PACIENTE { get; set; }

        public int NHIS_ID_MRP { get; set; }

        public int NHIS_COD_CATEGORIA_SERV_CLIENTE { get; set; }

        public int NHIS_MODO_ATENCION_MEDICO { get; set; }











        public int NHIS_USUARIO_CREACION { get; set; }

        //public DateTime DHIS_FECHA_CREACION { get; set; }

    }








    public class HistoriasClinicas
    {

        public long CHIS_ID { get; set; }

        public long CMED_ID { get; set; }


        public long CPAC_ID { get; set; }

        public long CESP_ID { get; set; }

        public long CEST_ID { get; set; }

        public long CPER_ID { get; set; }

        public long CSER_ID { get; set; }

        public long CDSN_ID { get; set; }

        public long CPAI_ID { get; set; }

        public long CUBI_ID { get; set; }

        public long CPRV_ID { get; set; }

        public long CTDO_ID { get; set; }

        public long CPLA_ID { get; set; }

        public long CMOT_ID { get; set; }

        public long CCLT_ID { get; set; }

        public long CCLI_ID { get; set; }

        public int NHIS_COD { get; set; }

        public bool FHIS_SEGUI_ATE { get; set; }

        public bool FHIS_FLAG { get; set; }

        public bool FHIS_SB_ATE { get; set; }

        public bool FHIS_EXI_ATE { get; set; }

        public string SHIS_ESTADO { get; set; }

        public int NHIS_PRIORIDAD { get; set; }

        public string SHIS_FLAGMONE { get; set; }

        public int NHIS_CAMBIO { get; set; }

        public string SHIS_ACCIDE { get; set; }

        public string SHIS_COD_EMP { get; set; }

        public string SHIS_NOM_EMP { get; set; }

        public string SHIS_COD_TIT { get; set; }

        public string SHIS_NOM_TIT { get; set; }

        public string SHIS_COD_DEP { get; set; }

        public string SHIS_COD_DIR { get; set; }

        public string SHIS_TLF_DIR { get; set; }

        public string SHIS_DES_DIR { get; set; }

        public string SHIS_COD_DIS { get; set; }

        public string SHIS_DES_DIS { get; set; }

        public string SHIS_COD_PROV { get; set; }

        public string SHIS_DES_PROV { get; set; }

        public string SHIS_DIS_DIR { get; set; }

        public string SHIS_REF_DIR { get; set; }

        public DateTime DHIS_HOR_ATE { get; set; }

        public DateTime DHIS_FEC_ATE { get; set; }

        public DateTime DHIS_HORLLA_ATE { get; set; }

        public DateTime DHIS_FECLLA_ATE { get; set; }

        public string SHIS_USULLA_ATE { get; set; }

        public DateTime DHIS_HORASGDR_ATE { get; set; }

        public DateTime DHIS_FECASGDR_ATE { get; set; }

        public DateTime SHIS_USUASGDR_ATE { get; set; }

        public DateTime DHIS_HORDRLLA_ATE { get; set; }

        public DateTime DHIS_FECDRLLA_ATE { get; set; }

        public string SHIS_USUDRLLA_ATE { get; set; }

        public DateTime DHIS_HOROPLLA_ATE { get; set; }

        public DateTime DHIS_FECOPLLA_ATE { get; set; }

        public string SHIS_USUOPLLA_ATE { get; set; }

        public DateTime DHIS_HORDIA_ATE { get; set; }

        public DateTime DHIS_FECDIA_ATE { get; set; }

        public string SHIS_USUDIA_ATE { get; set; }

        public decimal NHIS_TAR_ATE { get; set; }

        public string SHIS_OBS_ATE { get; set; }

        public string SHIS_GENERO_ATE { get; set; }

        public int NHIS_EDAD_ATE { get; set; }

        public string SHIS_SIN_ATE { get; set; }

        public DateTime DHIS_HRLLEDR { get; set; }

        public string SHIS_ESTADO_ATE { get; set; }

        public string SHIS_FOR_ATE { get; set; }

        public string SHIS_CODTAR_ATE { get; set; }

        public string SHIS_NTAR_ATE { get; set; }

        public DateTime DHIS_FVENC_ATE { get; set; }

        public bool FHIS_NOVA { get; set; }

        public int NHIS_RZONA { get; set; }

        public int NHIS_RHOR { get; set; }

        public int NHIS_ROCUP { get; set; }

        public int NHIS_OTRO { get; set; }

        public int NHIS_RCAB { get; set; }

        public int NHIS_ABONADO { get; set; }

        public bool FHIS_VIS_PROG { get; set; }

        public decimal NHIS_PREMIO { get; set; } // SE CAMBIO F X N
        public string  SHIS_CODAUT_RIMAC { get; set; }

        public string SHIS_POLORD_RIMAC { get; set; }

        public string SHIS_POL_RIMAC { get; set; }

        public string SHIS_ORD_RIMAC { get; set; }

        public bool FHIS_OBS48 { get; set; }

        public bool FHIS_EXP { get; set; }

        public int NHIS_COD_EXP { get; set; }

        public int NHIS_COASEGURO { get; set; }

        public string SHIS_CANC_ATE { get; set; }

        public bool FHIS_ACTIVI { get; set; }

        public bool FHIS_ACTIVI1 { get; set; }

        public bool FHIS_BOOL_ORIGINAL { get; set; }

        public string SHIS_CHA_CODASEG { get; set; }

        public string SHIS_COD_ESP { get; set; }

        public string SHIS_COD_DIRECTO { get; set; }

        public string SHIS_COD_HIA { get; set; }

        public bool FHIS_VAL { get; set; }

        public string SHIS_F_SOLDOCT { get; set; }

        public string SHIS_F_PROG { get; set; }

        public string SHIS_FLG_DIRECTO { get; set; }

        public string SHIS_DNI { get; set; }

        public string SHIS_COD_TIPO_DOCTOR { get; set; }

        public string FHIS_FLGVNR { get; set; }

        public string SHIS_FLG_LISTGEN { get; set; }

        public DateTime DHIS_FEC_LISTGEN { get; set; }

        public string SHIS_USU_LISTGEN { get; set; }

        public DateTime DHOR_LISTGEN { get; set; }

        public int NHIS_COD_LISTGEN { get; set; }

        public int NHIS_CORREL { get; set; }

        public bool FHIS_FLG_BOLETA { get; set; }

        public string SHIS_COD_BOLETA { get; set; }

        public string SHIS_FLG_BOLMAN { get; set; }

        public string SHIS_CODASEG_EPS { get; set; }

        public DateTime DHIS_FEC_REG_BOL { get; set; }

        public string SHIS_USU_REG_BOL { get; set; }

        public string SHIS_FLG_FICHA { get; set; }

        public string SHIS_COD_DR_SOLICITADO { get; set; }

        public bool FHIS_FLAG_PROGRAMADA { get; set; }

        public string SHIS_FLG_DR_SOLICITADO { get; set; }

        public string SHIS_COD_SOLGEN { get; set; }

        public bool FHIS_FLG_ASIGNAR_DR { get; set; }

        public string SHIS_CEL_PAC { get; set; }

        public string SHIS_FLG_PVTA { get; set; }

        public int NHIS_CM_ORDEN { get; set; }

        public string SHIS_CM_ESTADO { get; set; }

        public string SHIS_CM_ESTADO_ANT { get; set; }

        public string SHIS_CM_REF_DIR { get; set; }

        public bool FHIS_CM_FLAG_VIP { get; set; }

        public bool FHIS_CM_DIRECTA { get; set; }

        public bool FHIS_CM_DATOS_COMPLETOS { get; set; }

        public int NHIS_CM_COD_PAC_DESEA { get; set; }

        public string SHIS_CM_DES_PAC_DESEA { get; set; }

        public string SHIS_CM_COD_DR_PAC_DESEA { get; set; }

        public string SHIS_CM_NOM_DR_PAC_DESEA { get; set; }

        public string SHIS_CONTACTO_PAC { get; set; }

        public int NHIS_CM_TIEMPO { get; set; }

        public bool FHIS_FLG_REPROGRAMADA { get; set; }

        public bool SHIS_CM_MOTIVO_CANCELACION { get; set; }

        public DateTime DHIS_FECLLEDR { get; set; }

        public string SHIS_CM_MONEDA_DEN { get; set; }

        public string SHIS_CM_DENOMINACION { get; set; }

        public string SHIS_CM_AUTORIZADO { get; set; }

        public string SHIS_CM_ESP_ANTERIOR { get; set; }

        public string SHIS_CM_COD_DR_ANTERIOR { get; set; }

        public string SHIS_CM_DR_ANTERIOR { get; set; }

        public DateTime DHIS_CM_FEC_ANTERIOR { get; set; }

        public DateTime DHIS_CM_HOR_ANTERIOR { get; set; }

        public DateTime DHIS_OBS_CM { get; set; }

        public bool FHIS_FLG_CM_NUEVA { get; set; }

        public DateTime DHIS_CM_FEC_DESASIG { get; set; }

        public DateTime DHIS_CM_HOR_DESASIG { get; set; }

        public string SHIS_CM_INF_PAC_ANTERIOR { get; set; }

        public string SHIS_COD_DIS_CAMBIAR { get; set; }

        public string SHIS_DES_DIS_CAMBIAR { get; set; }

        public string SHIS_COD_DR_ENV_MSJ { get; set; }

        public string SHIS_CONTACTO_ASEG { get; set; }

        public string SHIS_CODIGO_SIA { get; set; }

        public string SHIS_USU_BLOQ { get; set; }

        public decimal NHIS_CM_DEN_CAMBIO { get; set; }

        public string SHIS_CM_MOTIVO_CAMBIO_DED { get; set; }

        public string SHIS_CM_AUT_CAMBIO_DED { get; set; }

        public int NHIS_CM_DED_ANTERIOR { get; set; }

        public string SHIS_CM_OPCION_CAMBIO { get; set; }

        public string SHIS_CM_ASEG_PRODUCTO { get; set; }

        public int NHIS_CLASIFICACION_PAC { get; set; }

        public string SHIS_TIPO_SERVICIO { get; set; }

        public int NHIS_COD_ASIG { get; set; }

        public string SHIS_COD_AMB { get; set; }

        public string SHIS_NOM_AMB { get; set; }

        public string SHIS_NOM_CS { get; set; }

        public int NHIS_COD_CS { get; set; }
        public string SHIS_PAC_VIP { get; set; }
        public int NHIS_COD_ATE_PREVIA { get; set; }
        public int NHIS_COD_SUBCLASIF { get; set; }
        public string SHIS_TARJ_MC { get; set; }
        public string SHIS_TIPO_SERVAMB_DRMAS { get; set; }
        public string SHIS_TIPO_SERVAMB_PACIFICO { get; set; }
        public string SHIS_TIPO_ATE { get; set; }
        public DateTime DHIS_FECCONFIRMACION_ATE { get; set; }
        public DateTime DHIS_HORCONFIRMACION_ATE { get; set; }
        public string SHIS_USUCONFIRMACION_ATE { get; set; }
        public string SHIS_TIPO_REPROG { get; set; }
        public bool FHIS_FLG_TIEMPO_MAYOR { get; set; }
        public bool FHIS_FECHA_MAX { get; set; }
        public bool FHIS_HORA_MAX { get; set; }
        public string SHIS_MOTIVO_AUT { get; set; }
        public string SHIS_OBS_AUT { get; set; }
        public string SHIS_AMB_COD_DIS_ORIGEN { get; set; }
        public string SHIS_AMB_DES_DIS_ORIGEN { get; set; }
        public string SHIS_AMB_DIR_ORIGEN { get; set; }
        public string SHIS_AMB_REF_DIR_ORIGEN { get; set; }
        public string SHIS_COD_TIPO_PROG { get; set; }
        public string SHIS_COD_AMB_TIPO_SERV { get; set; }
        public DateTime DHIS_AMB_FECHA_INI { get; set; }
        public DateTime DHIS_AMB_HORA_INI { get; set; }
        public DateTime DHIS_AMB_FECHA_FIN { get; set; }
        public DateTime DHIS_AMB_HORA_FIN { get; set; }
        public int NHIS_AMB_TIEMPO { get; set; }
        public int NHIS_COD_TARIFA { get; set; }
        public string SHIS_AMB_COD_DIS_DESTINO { get; set; }
        public string SHIS_AMB_DES_DIS_DESTINO { get; set; }
        public string SHIS_AMB_DIR_DESTINO { get; set; }
        public string SHIS_AMB_COND_VIAJE { get; set; }
        public string SHIS_AMB_TIPO_TRASLADO { get; set; }
        public string SHIS_DES_SINIESTRO { get; set; }
        public bool FHIS_AMB_SERVICIO_PLAYA { get; set; }
        public bool FHIS_FLG_BOLETA_FACT { get; set; }
        public string SHIS_TIPO_DOC_PAGO { get; set; }
        public string SHIS_PERSONAL_CONTACTO { get; set; }
        public string SHIS_TLF_CONTACTO { get; set; }
        public bool FHIS_PRIMERA_CONSULTA { get; set; }
        public int NHIS_COD_REPO_AMB { get; set; }
        public bool FHIS_FLG_REG_BD_TABLET { get; set; }
        public string SHIS_COD_AUT_PRESTACION { get; set; }
        public string SHIS_COD_ASEGURADO { get; set; }
        public string SHIS_POLIZA_ASEGURADO { get; set; }
        public string SHIS_POLIZA_CERTIFICADO { get; set; }
        public string SHIS_TIPO_AFILIACION { get; set; }
        public bool FHIS_FLG_REINGRESAR_TABLET { get; set; }
        public int NHIS_COD_ESTADO { get; set; }
        public bool FHIS_FLG_REGISTRAR_ATE_TABLET { get; set; }
        public DateTime DHIS_FEC_ENV_SMS { get; set; }
        public DateTime DHIS_HOR_ENV_SMS { get; set; }
        public string SHIS_DESCRP_ZONA { get; set; }
        public bool FHIS_FLG_CORREO_ENVIADO { get; set; }
        public bool FHIS_FLG_SMS_ENVIADO { get; set; }
        public bool FHIS_FLG_SMS_PROGRAMADO { get; set; }
        public DateTime DHIS_FH_ASIGNACION { get; set; }
        public bool FHIS_ATENCION_REFERENCIAL { get; set; }
        public bool FHIS_FLG_CULMINADO_TABLET { get; set; }
        public bool FHIS_FLG_EXPORTADO_QW { get; set; }
        public DateTime DHIS_FECHA_EXPORTADO_QW { get; set; }
        public DateTime DHIS_FECHA_REINGRESO { get; set; }
        public int NHIS_COD_NO_TBL { get; set; }
        public int NHIS_ID_PAQUETE { get; set; }
        public bool FHIS_SERVICIO_PROVISIONADO_SAP { get; set; }
        public string SHIS_TIPO_REGISTRO_HHMM { get; set; }
        public DateTime DHIS_FECHAAJUSTEEXTORNO_HHMM { get; set; }
        public bool FHIS_SERVICIO_PROVISIONADO_HHMM { get; set; }
        public int NHIS_ID_CONDICION_ESPECIAL_PAGO { get; set; }
        public bool FHIS_FLG_VALIDACION_DIRECTA { get; set; }
        public bool FHIS_FLG_EXAMEN_MEDICO { get; set; }
        public bool FHIS_FLG_ENCUESTA_DOLOR_ABDOMINAL { get; set; }
        public string SHIS_EMPRESA_PACIENTE { get; set; }
        public bool FHIS_FLG_ASEG_REG { get; set; }
        public bool FHIS_PACIENTE_TRASLADO { get; set; }
        public int NHIS_ID_MRP { get; set; }
        public string SHIS_COD_DIST_ENVIO_BOLETA { get; set; }
        public string SHIS_DIRECCION_ENVIO_BOLETA { get; set; }
        public bool FHIS_FLG_COMPROBANTE_ENVIADO { get; set; }
        public bool FHIS_FLG_COMPROBANTE_ENVIO_VALIDANDO { get; set; }
        public string SHIS_COD_TIPO_CE_EMITIDO { get; set; }
        public DateTime DHIS_FEC_REG_CE { get; set; }
        public DateTime DHIS_HORA_REG_CE { get; set; }
        public string SHIS_NUMERO_CE { get; set; }
        public string SHIS_USUARIO_REG_CE { get; set; }
        public bool FHIS_FLG_SMS_CRONICO_PNE { get; set; }
        public bool FHIS_FLG_SMS_CRONICO_PNC { get; set; }
        public bool FHIS_FLG_ATENCION_PAGADA { get; set; }
        public int NHIS_ID_PERIODO_CONSULTA { get; set; }
        public int NHIS_CONTADOR_PERIODO { get; set; }
        public int NHIS_PERIODO_MES { get; set; }
        public string SHIS_NUMERO_ORDEN_DELIVERY { get; set; }
        public bool FHIS_FLG_ENV_CORREO_AUTO_DRONLINE { get; set; }
        public bool FHIS_FLG_REENVIAR_CE { get; set; }
        public int NHIS_COD_CATEGORIA_SERV_CLIENTE { get; set; }
        public bool FHIS_FLG_ONBASE { get; set; }
        public int NHIS_COD_DOCUMENTO_CULMINACION { get; set; }
        public int NHIS_COD_TIPO_INGRESO { get; set; }
        public bool FHIS_FLG_EFECTIVIDAD_ATE { get; set; }
        public bool FHIS_FLG_DERIVAR { get; set; }
        public string SHIS_DERIVAR_MOTIVO { get; set; }
        public string SHIS_UNIDAD_DERIVADA { get; set; }
        public bool FHIS_FLG_NUEVO_PAC_PROGRAMA { get; set; }
        public string SHIS_CARTA_GARANTIA { get; set; }
        public bool FHIS_FLG_ATE_CON_MED_COVID_19 { get; set; }
        public bool FHIS_EDITAR_PROVISIONADO_SAP { get; set; }
        public int NHIS_ESTADO_INCIDENCIA { get; set; }
        public int NHIS_NRO_INCIDENCIA { get; set; }
        public int NHIS_COD_CONVENIO { get; set; }
        public bool NHIS_FLG_COTIZADO_CALLMED { get; set; }
        public int NHIS_COD_PRIORIDAD_CALLMED { get; set; }
        public int NHIS_COD_MOTIVO_ATE_CALLMED { get; set; }
        public string SHIS_AMB_REF_DIR_DESTINO { get; set; }
        public int NHIS_ID_TIPO_TRASLADO_CALLMED { get; set; }
        public bool FHIS_FLG_NO_EMITIR_CE { get; set; }
        public string SHIS_NUM_OPERACION_AP { get; set; }
        public bool FHIS_FLG_INYECTABLE { get; set; }
        public DateTime DHIS_FECHA_INYECTABLE { get; set; }
        public int NHIS_INYECTABLE_CANTIDAD { get; set; }
        public bool FHIS_FLG_ENV_CORREO_AUTO_CRONICOS_RECETA { get; set; }
        public int NHIS_COD_TIPO_SEG_CRONICO { get; set; }
        public int NHIS_ID_ENVIO_CE { get; set; }
        public int NHIS_CLASIFICACION_PAC_CALLMED { get; set; }
        public int NHIS_CLASIFICACION_NEG_SOPORTE { get; set; }
        public bool FHIS_FLG_VALIDAR_LLEGADA_CALLMED { get; set; }
        public int NHIS_MODO_ATENCION_MEDICO { get; set; }
        public bool FHIS_FLG_MONITOREO { get; set; }
        public string SHIS_ANTECEDENTES_ATE { get; set; }
        public int NHIS_CLASIFICACION_ATENCION_REFERENCIADA { get; set; }
        public int NHIS_LABORATORIO_NUTRICION { get; set; }
        public int NHIS_ID_MECANISMO_PAGO { get; set; }
        public int NHIS_ID_BENEFICIO { get; set; }
        public bool FHIS_AGUDO_SBS { get; set; }
        public int FHIS_MOTIVO_TIPO_PROG { get; set; }
        public string SHIS_DNI_TITULAR { get; set; }
        public bool FHIS_FLG_PAGO_HHMM { get; set; }
        public bool FHIS_FLG_ENVIO_DOCUMENTOS_TELEMEDICINA { get; set; }
        public string SHIS_CONTRATANTE_CITRIX { get; set; }
        public bool FHIS_FLG_FICHA_MEDICA_REGISTRADA { get; set; }
        public bool FHIS_FLG_ENCUESTA_CRONICOS { get; set; }
        public string SHIS_USUARIO_REG_ENCUESTA_CRONICOS { get; set; }
        public bool FHIS_FLG_DEVENGADO { get; set; }
        public bool FHIS_FLG_PROBLEMAS_TI { get; set; }
        public DateTime DHIS_FECHA_OPERACION_AP { get; set; }
        public string SHIS_USO_EPP { get; set; }
        public string SHIS_GRUPO_CRONICOS { get; set; }
        public int NHIS_DIAS_DM { get; set; }
        public string SHIS_MEDIO_PAGO { get; set; }
        public bool FHIS_FLG_ENVIO_DOCUMENTOS_MIDOC { get; set; }
        public int NHIS_ID_TIPO_SERV_MI_DOC { get; set; }
        public bool FHIS_FLG_GUARDADO { get; set; }
        public bool FHIS_FLG_FICHA_PSICO { get; set; }
        public string SHIS_PERSONA_REPORTA_CLINICA { get; set; }
        public string SHIS_HORARIO_TRABAJO { get; set; }
        public string SHIS_CARGO { get; set; }
        public string SHIS_RELATO { get; set; }
        public DateTime DHIS_FECHA_ACCIDENTE { get; set; }
        public DateTime DHIS_HORA_ACCIDENTE { get; set; }
        public string SHIS_OBSERVACION { get; set; }
        public int NHIS_ID_PRIMERA_ATENCION { get; set; }
        public string SHIS_PRIMERA_ATENCION { get; set; }
        public string SHIS_METODO_VALIDACION { get; set; }
        public bool FHIS_HOJA_ATENCION { get; set; }
        public string CUBI_UBIGEO_ACCIDENTE { get; set; }
        public int NHIS_SKILL { get; set; }
        public int NHIS_MOTIVO_SKILL { get; set; }
        public bool FHIS_CENTRO_CLINICO { get; set; }
        public bool FHIS_EMPRESA { get; set; }
        public bool FHIS_CORREDOR_SEGURO { get; set; }
        public bool FHIS_PACIENTE_ASEGURADO { get; set; }
        public string SATE_PERSONA_REPORTA_EMPRESA { get; set; }
        public string SATE_PERSONA_REPORTA_SEGURO { get; set; }
        public bool SATE_PERSONA_REPORTA_ASEGURADO { get; set; }
        public int NHIS_USUARIO_CREACION { get; set; }
        public DateTime DHIS_FECHA_CREACION { get; set; }
        public int NHIS_USUARIO_MODIFICACION { get; set; }
        public DateTime DHIS_FECHA_MODIFICACION { get; set; }

        //NHIS_COD_CS INT,
        //SHIS_PAC_VIP                                                VARCHAR(10),			
        //NHIS_COD_ATE_PREVIA INT,
        //NHIS_COD_SUBCLASIF                                          INT,					
        //SHIS_TARJ_MC VARCHAR(20),			
        //SHIS_TIPO_SERVAMB_DRMAS VARCHAR(15), 			
        //SHIS_TIPO_SERVAMB_PACIFICO VARCHAR(15),			
        //SHIS_TIPO_ATE VARCHAR(30),			
        //DHIS_FECCONFIRMACION_ATE DATETIME,
        //DHIS_HORCONFIRMACION_ATE                                    DATETIME,				
        //SHIS_USUCONFIRMACION_ATE VARCHAR(15),			
        //SHIS_TIPO_REPROG CHAR(2),				
        //FHIS_FLG_TIEMPO_MAYOR BIT,
        //FHIS_FECHA_MAX                                              DATETIME,				
        //FHIS_HORA_MAX DATETIME,
        //SHIS_MOTIVO_AUT                                             VARCHAR(150),			
        //SHIS_OBS_AUT VARCHAR(150),			
        //SHIS_AMB_COD_DIS_ORIGEN CHAR(4),				
        //SHIS_AMB_DES_DIS_ORIGEN VARCHAR(25),			
        //SHIS_AMB_DIR_ORIGEN VARCHAR(100),			
        //SHIS_AMB_REF_DIR_ORIGEN VARCHAR(150),		 	
        //SHIS_COD_TIPO_PROG VARCHAR(3),				
        //SHIS_COD_AMB_TIPO_SERV VARCHAR(15), 			
        //DHIS_AMB_FECHA_INI DATETIME,
        //DHIS_AMB_HORA_INI                                           DATETIME,				
        //DHIS_AMB_FECHA_FIN DATETIME,
        //DHIS_AMB_HORA_FIN                                           DATETIME,				
        //NHIS_AMB_TIEMPO INT,
        //NHIS_COD_TARIFA                                             INT,					
        //SHIS_AMB_COD_DIS_DESTINO CHAR(4),				
        //SHIS_AMB_DES_DIS_DESTINO VARCHAR(25),			
        //SHIS_AMB_DIR_DESTINO VARCHAR(100),			
        //SHIS_AMB_COND_VIAJE VARCHAR(15),			
        //SHIS_AMB_TIPO_TRASLADO VARCHAR(10),			
        //SHIS_DES_SINIESTRO VARCHAR(20),			
        //FHIS_AMB_SERVICIO_PLAYA BIT,
        //FHIS_FLG_BOLETA_FACT                                        BIT,					
        //SHIS_TIPO_DOC_PAGO CHAR(1),				
        //SHIS_PERSONAL_CONTACTO VARCHAR(100),		 	
        //SHIS_TLF_CONTACTO VARCHAR(15),			
        //FHIS_PRIMERA_CONSULTA BIT,
        //NHIS_COD_REPO_AMB                                           INT,				    
        //FHIS_FLG_REG_BD_TABLET BIT,
        //SHIS_COD_AUT_PRESTACION                                     VARCHAR(20),            
        //SHIS_COD_ASEGURADO VARCHAR(25),			
        //SHIS_POLIZA_ASEGURADO VARCHAR(20), 		    
        //SHIS_POLIZA_CERTIFICADO VARCHAR(20),			
        //SHIS_TIPO_AFILIACION VARCHAR(80),			
        //FHIS_FLG_REINGRESAR_TABLET BIT,
        //NHIS_COD_ESTADO                                             INT,		            
        //FHIS_FLG_REGISTRAR_ATE_TABLET BIT,
        //DHIS_FEC_ENV_SMS                                            DATETIME,				
        //DHIS_HOR_ENV_SMS DATETIME,
        //SHIS_DESCRP_ZONA                                            VARCHAR(25),			
        //FHIS_FLG_CORREO_ENVIADO BIT,
        //FHIS_FLG_SMS_ENVIADO                                        BIT,					
        //FHIS_FLG_SMS_PROGRAMADO BIT,
        //DHIS_FH_ASIGNACION                                          DATETIME,				
        //FHIS_ATENCION_REFERENCIAL BIT,
        //FHIS_FLG_CULMINADO_TABLET                                   BIT,					
        //FHIS_FLG_EXPORTADO_QW BIT,
        //DHIS_FECHA_EXPORTADO_QW                                     DATETIME,				
        //DHIS_FECHA_REINGRESO DATETIME,
        //NHIS_COD_NO_TBL                                             INT,					
        //NHIS_ID_PAQUETE INT,
        //FHIS_SERVICIO_PROVISIONADO_SAP                              BIT, 					
        //SHIS_TIPO_REGISTRO_HHMM CHAR(1), 				
        //DHIS_FECHAAJUSTEEXTORNO_HHMM DATETIME,
        //FHIS_SERVICIO_PROVISIONADO_HHMM                             BIT,					
        //NHIS_ID_CONDICION_ESPECIAL_PAGO INT,
        //FHIS_FLG_VALIDACION_DIRECTA                                 BIT,			  		
        //FHIS_FLG_EXAMEN_MEDICO BIT,
        //FHIS_FLG_ENCUESTA_DOLOR_ABDOMINAL                           BIT,				  	
        //SHIS_EMPRESA_PACIENTE VARCHAR(100),			
        //FHIS_FLG_ASEG_REG BIT,
        //FHIS_PACIENTE_TRASLADO                                      BIT,					
        //NHIS_ID_MRP INT,
        //SHIS_COD_DIST_ENVIO_BOLETA                                  VARCHAR(6),		 		
        //SHIS_DIRECCION_ENVIO_BOLETA VARCHAR(100),			
        //FHIS_FLG_COMPROBANTE_ENVIADO BIT,
        //FHIS_FLG_COMPROBANTE_ENVIO_VALIDANDO                        BIT,					
        //SHIS_COD_TIPO_CE_EMITIDO CHAR(2),				
        //DHIS_FEC_REG_CE DATETIME,
        //DHIS_HORA_REG_CE                                            DATETIME,				
        //SHIS_NUMERO_CE VARCHAR(15),			
        //SHIS_USUARIO_REG_CE VARCHAR(15),			
        //FHIS_FLG_SMS_CRONICO_PNE BIT,
        //FHIS_FLG_SMS_CRONICO_PNC                                    BIT,					
        //FHIS_FLG_ATENCION_PAGADA BIT,
        //NHIS_ID_PERIODO_CONSULTA                                    INT,					
        //NHIS_CONTADOR_PERIODO INT,
        //NHIS_PERIODO_MES                                            SMALLINT,				
        //SHIS_NUMERO_ORDEN_DELIVERY VARCHAR(25),			
        //FHIS_FLG_ENV_CORREO_AUTO_DRONLINE BIT,
        //FHIS_FLG_REENVIAR_CE                                        BIT,					
        //NHIS_COD_CATEGORIA_SERV_CLIENTE INT,
        //FHIS_FLG_ONBASE                                             BIT,					
        //NHIS_COD_DOCUMENTO_CULMINACION INT,
        //NHIS_COD_TIPO_INGRESO                                       INT,					
        //FHIS_FLG_EFECTIVIDAD_ATE BIT,
        //FHIS_FLG_DERIVAR                                            BIT,					
        //SHIS_DERIVAR_MOTIVO VARCHAR(1000),			
        //SHIS_UNIDAD_DERIVADA VARCHAR(50),			
        //FHIS_FLG_NUEVO_PAC_PROGRAMA BIT,
        //SHIS_CARTA_GARANTIA                                         VARCHAR(15),			
        //FHIS_FLG_ATE_CON_MED_COVID_19 BIT,
        //FHIS_EDITAR_PROVISIONADO_SAP                                BIT,					
        //NHIS_ESTADO_INCIDENCIA INT,
        //NHIS_NRO_INCIDENCIA                                         INT,					
        //NHIS_COD_CONVENIO INT,
        //NHIS_FLG_COTIZADO_CALLMED                                   BIT,					
        //NHIS_COD_PRIORIDAD_CALLMED INT,
        //NHIS_COD_MOTIVO_ATE_CALLMED                                 INT,					
        //SHIS_AMB_REF_DIR_DESTINO VARCHAR(150),			
        //NHIS_ID_TIPO_TRASLADO_CALLMED INT,
        //FHIS_FLG_NO_EMITIR_CE                                       BIT,					
        //SHIS_NUM_OPERACION_AP VARCHAR(25),			
        //FHIS_FLG_INYECTABLE BIT,
        //DHIS_FECHA_INYECTABLE                                       DATETIME,				
        //NHIS_INYECTABLE_CANTIDAD INT,
        //FHIS_FLG_ENV_CORREO_AUTO_CRONICOS_RECETA                    BIT,					
        //NHIS_COD_TIPO_SEG_CRONICO INT,
        //NHIS_ID_ENVIO_CE                                            INT,				    
        //NHIS_CLASIFICACION_PAC_CALLMED INT,
        //NHIS_CLASIFICACION_NEG_SOPORTE                              INT,					
        //FHIS_FLG_VALIDAR_LLEGADA_CALLMED BIT,
        //NHIS_MODO_ATENCION_MEDICO                                   INT,					
        //FHIS_FLG_MONITOREO BIT,
        //SHIS_ANTECEDENTES_ATE                                       VARCHAR(500),			
        //NHIS_CLASIFICACION_ATENCION_REFERENCIADA INT,
        //NHIS_LABORATORIO_NUTRICION                                  INT,					
        //NHIS_ID_MECANISMO_PAGO INT,
        //NHIS_ID_BENEFICIO                                           INT,					
        //FHIS_AGUDO_SBS BIT,
        //FHIS_MOTIVO_TIPO_PROG                                       INT, 					
        //SHIS_DNI_TITULAR CHAR(8),				
        //FHIS_FLG_PAGO_HHMM BIT,
        //FHIS_FLG_ENVIO_DOCUMENTOS_TELEMEDICINA                      BIT,					
        //SHIS_CONTRATANTE_CITRIX VARCHAR(100),			
        //FHIS_FLG_FICHA_MEDICA_REGISTRADA BIT,
        //FHIS_FLG_ENCUESTA_CRONICOS                                  BIT,					
        //SHIS_USUARIO_REG_ENCUESTA_CRONICOS VARCHAR(50),			
        //FHIS_FLG_DEVENGADO BIT,
        //FHIS_FLG_PROBLEMAS_TI                                       BIT,					
        //DHIS_FECHA_OPERACION_AP DATETIME,
        //SHIS_USO_EPP                                                CHAR(2),				
        //SHIS_GRUPO_CRONICOS CHAR(2),				
        //NHIS_DIAS_DM INT,
        //SHIS_MEDIO_PAGO                                             VARCHAR(25),			
        //FHIS_FLG_ENVIO_DOCUMENTOS_MIDOC BIT,
        //NHIS_ID_TIPO_SERV_MI_DOC                                    INT,					
        //FHIS_FLG_GUARDADO BIT,
        //FHIS_FLG_FICHA_PSICO                                        BIT,					
        //SHIS_PERSONA_REPORTA_CLINICA VARCHAR(200), 			
        //SHIS_HORARIO_TRABAJO VARCHAR(200),			
        //SHIS_CARGO VARCHAR(200),			
        //SHIS_RELATO VARCHAR(200),			
        //DHIS_FECHA_ACCIDENTE DATE,
        //DHIS_HORA_ACCIDENTE                                         TIME(7),				
        //SHIS_OBSERVACION VARCHAR(200),			
        //NHIS_ID_PRIMERA_ATENCION INT,
        //SHIS_PRIMERA_ATENCION                                       VARCHAR(200),			
        //SHIS_METODO_VALIDACION VARCHAR(200), 			
        //FHIS_HOJA_ATENCION BIT,
        //CUBI_UBIGEO_ACCIDENTE                                       CHAR(6),				
        //NHIS_SKILL INT,
        //NHIS_MOTIVO_SKILL                                           INT,					
        //FHIS_CENTRO_CLINICO BIT,
        //FHIS_EMPRESA                                                BIT, 					
        //FHIS_CORREDOR_SEGURO BIT,
        //FHIS_PACIENTE_ASEGURADO                                     BIT,					
        //SATE_PERSONA_REPORTA_EMPRESA BIT,
        //SATE_PERSONA_REPORTA_SEGURO                                 BIT,					
        //SATE_PERSONA_REPORTA_ASEGURADO BIT,
        //NHIS_USUARIO_CREACION                                       INT,					
        //DHIS_FECHA_CREACION DATETIME,
        //NHIS_USUARIO_MODIFICACION                                   INT,					
        //DHIS_FECHA_MODIFICACION DATETIME,





    }

    public class HistoriaClinicaMad
    {
        public long CMED_ID { get; set; }

        public long CPAC_ID { get; set; }

        public long CESP_ID { get; set; }

        public long CEST_ID { get; set; }

        public long CPER_ID { get; set; }

        public long CSER_ID { get; set; }

        public long CDSN_ID { get; set; }

        public long CPAI_ID { get; set; }

        public long CUBI_ID { get; set; }

        public long CPRV_ID { get; set; }

        public long CTDO_ID { get; set; }

        public long CPLA_ID { get; set; }

        public long CMOT_ID { get; set; }

        public long CCLT_ID { get; set; }

        public long CCLI_ID { get; set; }

        public long NHIS_COD { get; set; }

        public bool FHIS_SEGUI_ATE { get; set; }

        public bool FHIS_FLAG { get; set; }

        public bool FHIS_SB_ATE { get; set; }

        public bool FHIS_EXI_ATE { get; set; }

        public string SHIS_ESTADO { get; set; }

        public int NHIS_PRIORIDAD { get; set; }

        public string SHIS_FLAGMONE { get; set; }

        public decimal NHIS_CAMBIO { get; set; }

        public string SHIS_ACCIDE { get; set; }

        public string SHIS_COD_EMP { get; set; }

        public string SHIS_NOM_EMP { get; set; }

        public string SHIS_COD_TIT { get; set; }

        public string SHIS_NOM_TIT { get; set; }

        public string SHIS_COD_DEP { get; set; }

        public string SHIS_COD_DIR { get; set; }

        public string SHIS_TLF_DIR { get; set; }

        public string SHIS_DES_DIR { get; set; }

        public string SHIS_COD_DIS { get; set; }

        public string SHIS_DES_DIS { get; set; }

        public string SHIS_COD_PROV { get; set; }

        public string SHIS_DES_PROV { get; set; }

        public string SHIS_DIS_DIR { get; set; }

        public string SHIS_REF_DIR { get; set; }

        public DateTime DHIS_HOR_ATE { get; set; }

        public DateTime DHIS_FEC_ATE { get; set; }

        public DateTime DHIS_HORLLA_ATE { get; set; }

        public DateTime DHIS_FECLLA_ATE { get; set; }

        public string SHIS_USULLA_ATE { get; set; }

        public DateTime DHIS_HORASGDR_ATE { get; set; }

        public DateTime DHIS_FECASGDR_ATE { get; set; }

        public string SHIS_USUASGDR_ATE { get; set; }

        public DateTime DHIS_HORDRLLA_ATE { get; set; }

        public DateTime DHIS_FECDRLLA_ATE { get; set; }

        public string SHIS_USUDRLLA_ATE { get; set; }

        public DateTime DHIS_HOROPLLA_ATE { get; set; }

        public DateTime DHIS_FECOPLLA_ATE { get; set; }

        public string SHIS_USUOPLLA_ATE { get; set; }

        public DateTime DHIS_HORDIA_ATE { get; set; }

        public DateTime DHIS_FECDIA_ATE { get; set; }

        public string SHIS_USUDIA_ATE { get; set; }

        public int NHIS_TAR_ATE { get; set; }

        public string SHIS_OBS_ATE { get; set; }

        public string SHIS_GENERO_ATE { get; set; }

        public int NHIS_EDAD_ATE { get; set; }

        public string SHIS_SIN_ATE { get; set; }

        public DateTime DHIS_HRLLEDR { get; set; }

        public string SHIS_ESTADO_ATE { get; set; }

        public string SHIS_FOR_ATE { get; set; }

        public string SHIS_CODTAR_ATE { get; set; }

        public string SHIS_NTAR_ATE { get; set; }

        public DateTime DHIS_FVENC_ATE { get; set; }

        public bool FHIS_NOVA { get; set; }

        public int NHIS_RZONA { get; set; }

        public int NHIS_RHOR { get; set; }

        public int NHIS_ROCUP { get; set; }

        public int NHIS_OTRO { get; set; }

        public int NHIS_RCAB { get; set; }

        public int NHIS_ABONADO { get; set; }

        public bool FHIS_VIS_PROG { get; set; }

        public decimal FHIS_PREMIO { get; set; }

        public string SHIS_CODAUT_RIMAC { get; set; }

        public string SHIS_POLORD_RIMAC { get; set; }

        public string SHIS_POL_RIMAC { get; set; }

        public string SHIS_ORD_RIMAC { get; set; }

        public bool FHIS_OBS48 { get; set; }

        public bool FHIS_EXP { get; set; }

        public int NHIS_COD_EXP { get; set; }

        public int NHIS_COASEGURO { get; set; }

        public string SHIS_CANC_ATE { get; set; }

        public bool FHIS_ACTIVI { get; set; }

        public bool FHIS_ACTIVI1 { get; set; }

        public bool FHIS_BOOL_ORIGINAL { get; set; }

        public string SHIS_CHA_CODASEG { get; set; }

        public string SHIS_COD_ESP { get; set; }

        public string SHIS_COD_DIRECTO { get; set; }

        public string SHIS_COD_HIA { get; set; }

        public bool FHIS_VAL { get; set; }

        public string SHIS_F_SOLDOCT { get; set; }

        public string SHIS_F_PROG { get; set; }

        public string SHIS_FLG_DIRECTO { get; set; }

        public string SHIS_DNI { get; set; }

        public string SHIS_COD_TIPO_DOCTOR { get; set; }

        public bool FHIS_FLGVNR { get; set; }

        public string SHIS_FLG_LISTGEN { get; set; }

        public DateTime DHIS_FEC_LISTGEN { get; set; }

        public string SHIS_USU_LISTGEN { get; set; }

        public DateTime DHOR_LISTGEN { get; set; }

        public int NHIS_COD_LISTGEN { get; set; }

        public int NHIS_CORREL { get; set; }

        public bool FHIS_FLG_BOLETA { get; set; }

        public string SHIS_COD_BOLETA { get; set; }

        public string SHIS_FLG_BOLMAN { get; set; }

        public string SHIS_CODASEG_EPS { get; set; }

        public DateTime DHIS_FEC_REG_BOL { get; set; }

        public string SHIS_USU_REG_BOL { get; set; }

        public string SHIS_FLG_FICHA { get; set; }

        public string SHIS_COD_DR_SOLICITADO { get; set; }

        public bool FHIS_FLAG_PROGRAMADA { get; set; }

        public string SHIS_FLG_DR_SOLICITADO { get; set; }

        public string SHIS_COD_SOLGEN { get; set; }

        public bool FHIS_FLG_ASIGNAR_DR { get; set; }

        public string SHIS_CEL_PAC { get; set; }

        public string SHIS_FLG_PVTA { get; set; }

        public int NHIS_CM_ORDEN { get; set; }
        public string SHIS_CM_ESTADO { get; set; }

        public string SHIS_CM_ESTADO_ANT { get; set; }

        public string SHIS_CM_REF_DIR { get; set; }

        public bool FHIS_CM_FLAG_VIP { get; set; }

        public bool FHIS_CM_DIRECTA { get; set; }

        public bool FHIS_CM_DATOS_COMPLETOS { get; set; }

        public int NHIS_CM_COD_PAC_DESEA { get; set; }

        public string SHIS_CM_DES_PAC_DESEA { get; set; }

        public string SHIS_CM_COD_DR_PAC_DESEA { get; set; }

        public string SHIS_CM_NOM_DR_PAC_DESEA { get; set; }

        public string SHIS_CONTACTO_PAC { get; set; }

        public int NHIS_CM_TIEMPO { get; set; }

        public bool FHIS_FLG_REPROGRAMADA { get; set; }

        public string SHIS_CM_MOTIVO_CANCELACION { get; set; }

        public DateTime DHIS_FECLLEDR { get; set; }

        public string SHIS_CM_MONEDA_DEN { get; set; }

        public string SHIS_CM_DENOMINACION { get; set; }

        public string SHIS_CM_AUTORIZADO { get; set; }

        public string SHIS_CM_ESP_ANTERIOR { get; set; }

        public string SHIS_CM_COD_DR_ANTERIOR { get; set; }

        public string SHIS_CM_DR_ANTERIOR { get; set; }

        public DateTime DHIS_CM_FEC_ANTERIOR { get; set; }

        public DateTime DHIS_CM_HOR_ANTERIOR { get; set; }

        public string DHIS_OBS_CM { get; set; } //DHIS_OBS_CM 

        public bool FHIS_FLG_CM_NUEVA { get; set; }

        public DateTime DHIS_CM_FEC_DESASIG { get; set; }

        public DateTime DHIS_CM_HOR_DESASIG { get; set; }

        public string SHIS_CM_INF_PAC_ANTERIOR { get; set; }

        public string SHIS_COD_DIS_CAMBIAR { get; set; }

        public string SHIS_DES_DIS_CAMBIAR { get; set; }

        public string SHIS_COD_DR_ENV_MSJ { get; set; }

        public string SHIS_CONTACTO_ASEG { get; set; }

        public string SHIS_CODIGO_SIA { get; set; }

        public string SHIS_USU_BLOQ { get; set; }

        public decimal NHIS_CM_DEN_CAMBIO { get; set; }

        public string SHIS_CM_MOTIVO_CAMBIO_DED { get; set; }

        public string SHIS_CM_AUT_CAMBIO_DED { get; set; }

        public decimal NHIS_CM_DED_ANTERIOR { get; set; }

        public string SHIS_CM_OPCION_CAMBIO { get; set; }

        public string SHIS_CM_ASEG_PRODUCTO { get; set; }

        public int NHIS_CLASIFICACION_PAC { get; set; }

        public string SHIS_TIPO_SERVICIO { get; set; }

        public int NHIS_COD_ASIG { get; set; }

        public string SHIS_COD_AMB { get; set; }

        public string SHIS_NOM_AMB { get; set; }

        public string SHIS_NOM_CS { get; set; }

        public int NHIS_COD_CS { get; set; }

        public string SHIS_PAC_VIP { get; set; }

        public int NHIS_COD_ATE_PREVIA { get; set; }

        public int NHIS_COD_SUBCLASIF { get; set; }

        public string SHIS_TARJ_MC { get; set; }

        public string SHIS_TIPO_SERVAMB_DRMAS { get; set; }

        public string SHIS_TIPO_SERVAMB_PACIFICO { get; set; }

        public string SHIS_TIPO_ATE { get; set; }

        public DateTime DHIS_FECCONFIRMACION_ATE { get; set; }

        public DateTime DHIS_HORCONFIRMACION_ATE { get; set; }

        public string SHIS_USUCONFIRMACION_ATE { get; set; }

        public string SHIS_TIPO_REPROG { get; set; }

        public bool FHIS_FLG_TIEMPO_MAYOR { get; set; }

        public bool FHIS_FECHA_MAX { get; set; }

        public bool FHIS_HORA_MAX { get; set; }

        public string SHIS_MOTIVO_AUT { get; set; }

        public string SHIS_OBS_AUT { get; set; }

        public string SHIS_AMB_COD_DIS_ORIGEN { get; set; }

        public string SHIS_AMB_DES_DIS_ORIGEN { get; set; }

        public string SHIS_AMB_DIR_ORIGEN { get; set; }

        public string SHIS_AMB_REF_DIR_ORIGEN { get; set; }

        public string SHIS_COD_TIPO_PROG { get; set; }

        public string SHIS_COD_AMB_TIPO_SERV { get; set; }

        public DateTime DHIS_AMB_FECHA_INI { get; set; }

        public DateTime DHIS_AMB_HORA_INI { get; set; }

        public DateTime DHIS_AMB_FECHA_FIN { get; set; }

        public DateTime DHIS_AMB_HORA_FIN { get; set; }

        public int NHIS_AMB_TIEMPO { get; set; }

        public int NHIS_COD_TARIFA { get; set; }

        public string SHIS_AMB_COD_DIS_DESTINO { get; set; }

        public string SHIS_AMB_DES_DIS_DESTINO { get; set; }

        public string SHIS_AMB_DIR_DESTINO { get; set; }

        public string SHIS_AMB_COND_VIAJE { get; set; }

        public string SHIS_AMB_TIPO_TRASLADO { get; set; }

        public string SHIS_DES_SINIESTRO { get; set; }

        public bool FHIS_AMB_SERVICIO_PLAYA { get; set; }

        public bool FHIS_FLG_BOLETA_FACT { get; set; }

        public string SHIS_TIPO_DOC_PAGO { get; set; }

        public string SHIS_PERSONAL_CONTACTO { get; set; }

        public string SHIS_TLF_CONTACTO { get; set; }

        public bool FHIS_PRIMERA_CONSULTA { get; set; }

        public int NHIS_COD_REPO_AMB { get; set; }

        public bool FHIS_FLG_REG_BD_TABLET { get; set; }

        public string SHIS_COD_AUT_PRESTACION { get; set; }

        public string SHIS_COD_ASEGURADO { get; set; }

        public string SHIS_POLIZA_ASEGURADO { get; set; }

        public string SHIS_POLIZA_CERTIFICADO { get; set; }

        public string SHIS_TIPO_AFILIACION { get; set; }

        public bool FHIS_FLG_REINGRESAR_TABLET { get; set; }

        public int NHIS_COD_ESTADO { get; set; }

        public bool FHIS_FLG_REGISTRAR_ATE_TABLET { get; set; }

        public DateTime DHIS_FEC_ENV_SMS { get; set; }

        public DateTime DHIS_HOR_ENV_SMS { get; set; }

        public string SHIS_DESCRP_ZONA { get; set; }

        public bool FHIS_FLG_CORREO_ENVIADO { get; set; }

        public bool FHIS_FLG_SMS_ENVIADO { get; set; }

        public bool FHIS_FLG_SMS_PROGRAMADO { get; set; }

        public DateTime DHIS_FH_ASIGNACION { get; set; }

        public bool FHIS_ATENCION_REFERENCIAL { get; set; }

        public bool FHIS_FLG_CULMINADO_TABLET { get; set; }

        public bool FHIS_FLG_EXPORTADO_QW { get; set; }

        public DateTime DHIS_FECHA_EXPORTADO_QW { get; set; }

        public DateTime DHIS_FECHA_REINGRESO { get; set; }

        public int NHIS_COD_NO_TBL { get; set; }

        public int NHIS_ID_PAQUETE { get; set; }

        public bool FHIS_SERVICIO_PROVISIONADO_SAP { get; set; }

        public string SHIS_TIPO_REGISTRO_HHMM { get; set; }

        public DateTime DHIS_FECHAAJUSTEEXTORNO_HHMM { get; set; }

        public bool FHIS_SERVICIO_PROVISIONADO_HHMM { get; set; }

        public int NHIS_ID_CONDICION_ESPECIAL_PAGO { get; set; }

        public bool FHIS_FLG_VALIDACION_DIRECTA { get; set; }

        public bool FHIS_FLG_EXAMEN_MEDICO { get; set; }

        public bool FHIS_FLG_ENCUESTA_DOLOR_ABDOMINAL { get; set; }

        public string SHIS_EMPRESA_PACIENTE { get; set; }

        public bool FHIS_FLG_ASEG_REG { get; set; }

        public bool FHIS_PACIENTE_TRASLADO { get; set; }

        public int NHIS_ID_MRP { get; set; }

        public string SHIS_COD_DIST_ENVIO_BOLETA { get; set; }

        public string SHIS_DIRECCION_ENVIO_BOLETA { get; set; }

        public bool FHIS_FLG_COMPROBANTE_ENVIADO { get; set; }

        public bool FHIS_FLG_COMPROBANTE_ENVIO_VALIDANDO { get; set; }

        public string SHIS_COD_TIPO_CE_EMITIDO { get; set; }

        public DateTime DHIS_FEC_REG_CE { get; set; }

        public DateTime DHIS_HORA_REG_CE { get; set; }

        public string SHIS_NUMERO_CE { get; set; }

        public string SHIS_USUARIO_REG_CE { get; set; }

        public bool FHIS_FLG_SMS_CRONICO_PNE { get; set; }

        public bool FHIS_FLG_SMS_CRONICO_PNC { get; set; }

        public bool FHIS_FLG_ATENCION_PAGADA { get; set; }

        public int NHIS_ID_PERIODO_CONSULTA { get; set; }

        public int NHIS_CONTADOR_PERIODO { get; set; }

        public int NHIS_PERIODO_MES { get; set; }

        public string SHIS_NUMERO_ORDEN_DELIVERY { get; set; }

        public bool FHIS_FLG_ENV_CORREO_AUTO_DRONLINE { get; set; }

        public bool FHIS_FLG_REENVIAR_CE { get; set; }

        public int NHIS_COD_CATEGORIA_SERV_CLIENTE { get; set; }

        public bool FHIS_FLG_ONBASE { get; set; }

        public int NHIS_COD_DOCUMENTO_CULMINACION { get; set; }

        public int NHIS_COD_TIPO_INGRESO { get; set; }

        public bool FHIS_FLG_EFECTIVIDAD_ATE { get; set; }

        public bool FHIS_FLG_DERIVAR { get; set; }

        public string SHIS_DERIVAR_MOTIVO { get; set; }

        public string SHIS_UNIDAD_DERIVADA { get; set; }

        public bool FHIS_FLG_NUEVO_PAC_PROGRAMA { get; set; }

        public string SHIS_CARTA_GARANTIA { get; set; }

        public bool FHIS_FLG_ATE_CON_MED_COVID_19 { get; set; }

        public bool FHIS_EDITAR_PROVISIONADO_SAP { get; set; }

        public int NHIS_ESTADO_INCIDENCIA { get; set; }

        public int NHIS_NRO_INCIDENCIA { get; set; }

        public int NHIS_COD_CONVENIO { get; set; }

        public bool FHIS_FLG_COTIZADO_CALLMED { get; set; }

        public int NHIS_COD_PRIORIDAD_CALLMED { get; set; }

        public int NHIS_COD_MOTIVO_ATE_CALLMED { get; set; }

        public string SHIS_AMB_REF_DIR_DESTINO { get; set; }

        public int NHIS_ID_TIPO_TRASLADO_CALLMED { get; set; }

        public bool FHIS_FLG_NO_EMITIR_CE { get; set; }

        public string SHIS_NUM_OPERACION_AP { get; set; }

        public bool MyProperty { get; set; }

        public DateTime DHIS_FECHA_INYECTABLE { get; set; }

        public int NHIS_INYECTABLE_CANTIDAD { get; set; }

        public bool FHIS_FLG_ENV_CORREO_AUTO_CRONICOS_RECETA { get; set; }

        public int NHIS_COD_TIPO_SEG_CRONICO { get; set; }

        public int NHIS_ID_ENVIO_CE { get; set; }

        public int NHIS_CLASIFICACION_PAC_CALLMED { get; set; }

        public int NHIS_CLASIFICACION_NEG_SOPORTE { get; set; }

        public bool FHIS_FLG_VALIDAR_LLEGADA_CALLMED { get; set; }

        public int NHIS_MODO_ATENCION_MEDICO { get; set; }

        public bool FHIS_FLG_MONITOREO { get; set; }

        public string SHIS_ANTECEDENTES_ATE { get; set; }

        public int NHIS_CLASIFICACION_ATENCION_REFERENCIADA { get; set; }

        public int NHIS_LABORATORIO_NUTRICION { get; set; }

        public int NHIS_ID_MECANISMO_PAGO { get; set; }

        public int NHIS_ID_BENEFICIO { get; set; }

        public bool FHIS_AGUDO_SBS { get; set; }

        public int NHIS_MOTIVO_TIPO_PROG { get; set; } //VERIFICAR = FHIS_MOTIVO_TIPO_PROG

        public string SHIS_DNI_TITULAR { get; set; }

        public bool FHIS_FLG_PAGO_HHMM { get; set; }

        public bool FHIS_FLG_ENVIO_DOCUMENTOS_TELEMEDICINA { get; set; }

        public string SHIS_CONTRATANTE_CITRIX { get; set; }

        public bool FHIS_FLG_FICHA_MEDICA_REGISTRADA { get; set; }

        public bool FHIS_FLG_ENCUESTA_CRONICOS { get; set; }

        public string SHIS_USUARIO_REG_ENCUESTA_CRONICOS { get; set; }

        public bool FHIS_FLG_DEVENGADO { get; set; }

        public bool FHIS_FLG_PROBLEMAS_TI { get; set; }

        public DateTime DHIS_FECHA_OPERACION_AP { get; set; }

        public string SHIS_USO_EPP { get; set; }

        public string SHIS_GRUPO_CRONICOS { get; set; }

        public int NHIS_DIAS_DM { get; set; }

        public string SHIS_MEDIO_PAGO { get; set; }

        public bool FHIS_FLG_ENVIO_DOCUMENTOS_MIDOC { get; set; }

        public int NHIS_ID_TIPO_SERV_MI_DOC { get; set; }

        public bool FHIS_FLG_GUARDADO { get; set; }

        public bool FHIS_FLG_FICHA_PSICO { get; set; }

        public string SHIS_PERSONA_REPORTA_CLINICA { get; set; }

        public string SHIS_HORARIO_TRABAJO { get; set; }

        public string SHIS_CARGO { get; set; }

        public string SHIS_RELATO { get; set; }

        public DateTime DHIS_FECHA_ACCIDENTE { get; set; }
        public DateTime DHIS_HORA_ACCIDENTE { get; set; }

        public string SHIS_OBSERVACION { get; set; }

        public int NHIS_ID_PRIMERA_ATENCION { get; set; }

        public string SHIS_PRIMERA_ATENCION { get; set; }

        public string SHIS_METODO_VALIDACION { get; set; }

        public bool FHIS_HOJA_ATENCION { get; set; }

        public string SUBI_UBIGEO_ACCIDENTE { get; set; } //CUBI_UBIGEO_ACCIDENTE

        public int NHIS_SKILL { get; set; }

        public int NHIS_MOTIVO_SKILL { get; set; }

        public bool FHIS_CENTRO_CLINICO { get; set; }

        public bool FHIS_EMPRESA { get; set; }

        public bool FHIS_CORREDOR_SEGURO { get; set; }

        public bool FHIS_PACIENTE_ASEGURADO { get; set; }

        public string SATE_PERSONA_REPORTA_EMPRESA { get; set; }

        public string SATE_PERSONA_REPORTA_SEGURO { get; set; }

        public bool FATE_PERSONA_REPORTA_ASEGURADO { get; set; } // SATE_PERSONA_REPORTA_ASEGURADO

        public int NHIS_USUARIO_CREACION { get; set; }

        public DateTime DHIS_FECHA_CREACION { get; set; }

        public int NHIS_USUARIO_MODIFICACION { get; set; }

        public DateTime DHIS_FECHA_MODIFICACION { get; set; }
        ///--------------------------
        public long cod_historia_clinica { get; set; }//MAD - SCTR
        public string paciente { get; set; }//MAD - SCTR
        public string fecha_creacion { get; set; }//MAD - SCTR
        public string fecha_nacimiento { get; set; }//MAD - SCTR
        public int edad { get; set; }//MAD - SCTR
        public string hora_atencion { get; set; }//MAD - SCTR
        public string celular { get; set; }//MAD - SCTR
        public int id_cliente { get; set; }//MAD - SCTR
        public string? id_paciente { get; set; }//MAD
        public string? id_medico { get; set; }//MAD
        public string? vip { get; set; }//MAD
        public string? medico { get; set; }//MAD
        public string? aseguradora { get; set; }//MAD
        public string? especialidad { get; set; }//MAD
        public string? sintomas { get; set; }//MAD
        public string? tipo_atencion { get; set; }//MAD
        public string? programacion { get; set; }//MAD
        public string? nro_descanso_medico { get; set; }//MAD
        public string? cambio_realizar { get; set; }//MAD
        public string? moneda_deducible { get; set; }//MAD
        public string? monto_deducible { get; set; }//MAD
        public string? coaseguro { get; set; }//MAD
        public string? tipo_documento_pago { get; set; }//MAD
        public string? numero_documento_pago { get; set; }//MAD
        public string? forma_pago { get; set; }//MAD
        public string? moneda_denominacion { get; set; }//MAD
        public string? monto_denominacion { get; set; }//MAD
        public string? telefono { get; set; }//MAD
        public string? anexo { get; set; }//MAD
        public string? referencia { get; set; }//MAD
        public string? direccion { get; set; }//MAD
        public string? provincia { get; set; }//MAD
        public string? distrito { get; set; }//MAD

    }

    public class Historias_clinicas
    {

        public long CHIS_ID { get; set; }

        public long CMED_ID { get; set; }

        public long CPAC_ID { get; set; }

        public long CESP_ID { get; set; }


        public long CEST_ID  { get; set; }

        public long CPER_ID { get; set; }

        public long CSER_ID { get; set; }

        public long CDSN_ID { get; set; }

        public long CPAI_ID { get; set; }

        public long CUBI_ID { get; set; }

        public long CPRV_ID { get; set; }

        public long CTDO_ID { get; set; }

        public long CPLA_ID { get; set; }


        public long CMOT_ID { get; set; }

        public long CCLT_ID { get; set; }

        public long CCLI_ID { get; set; }

        public long MNHIS_COD { get; set; }

        public bool FHIS_SEGUI_ATE { get; set; }

        public bool FHIS_FLAG { get; set; }

        public bool FHIS_SB_ATE { get; set; }

        public bool FHIS_EXI_ATE { get; set; }

        public string SHIS_ESTADO { get; set; }

        public int NHIS_PRIORIDAD { get; set; }

        public string SHIS_FLAGMONE { get; set; }

        public decimal NHIS_CAMBIO { get; set; }

        public string SHIS_ACCIDE { get; set; }

        public string SHIS_COD_EMP { get; set; }

        public string SHIS_NOM_EMP { get; set; }

        public string SHIS_COD_TIT { get; set; }

        public string SHIS_NOM_TIT { get; set; }

        public string SHIS_COD_DEP { get; set; }

        public string SHIS_COD_DIR { get; set; }

        public string SHIS_TLF_DIR { get; set; }

        public string SHIS_DES_DIR { get; set; }

        public string SHIS_COD_DIS { get; set; }

        public string SHIS_DES_DIS { get; set; }

        public string SHIS_COD_PROV { get; set; }

        public string SHIS_DES_PROV { get; set; }

        public string SHIS_DIS_DIR { get; set; }

        public string SHIS_DNI { get; set; }


    }

    public class HistoriaClinicas
    {

        public long CHIS_ID { get; set; }

        public string E { get; set; }

        public string PROG { get; set; }

        public long CODATE { get; set; }

        public string CLASIF { get; set; }

        public string E_TABLET { get; set; }

        public string CODAUTORIZACION { get; set; }

        public string FECLLA { get; set; }

        public string HRLLA { get; set; }

        public int TIEMPO { get; set; }

        public string FECATE { get; set; }

        public string HRXDEFECTO { get; set; }

        public string HRESTIMADA { get; set; }

        public string HRLLEGADA { get; set; }

        public string PROVINCIA { get; set; }

        public string DISTRITO { get; set; }

        public string PACIENTE { get; set; }

        public string FPAGO { get; set; }

        public string VIP { get; set; }

        public string GRUPO { get; set; }

        public string PERIODO { get; set; }

        public int CONT { get; set; }

        public string PERFIL { get; set; }

        public string ESPEC { get; set; }

        public string DOCTOR { get; set; }

        public string GRUPOS { get; set; }

        public string EMPRESA { get; set; }

        public string USUARIO { get; set; }

        public int COD_DOC { get; set; }
        public string CM_ESTADO { get; set; }



    }
    
    public class HistoriaClinica
    {
        public long cod_historia_clinica { get; set; }//MAD - SCTR
        public string paciente { get; set; }//MAD - SCTR
        public string fecha_creacion { get; set; }//MAD - SCTR
        public string fecha_nacimiento { get; set; }//MAD - SCTR
        public int edad { get; set; }//MAD - SCTR
        public string hora_atencion { get; set; }//MAD - SCTR
        public string celular { get; set; }//MAD - SCTR
        public int id_cliente { get; set; }//MAD - SCTR
        public string? id_paciente { get; set; }//MAD
        public string? id_medico { get; set; }//MAD
        public string? vip { get; set; }//MAD
        public string? medico { get; set; }//MAD
        public string? aseguradora { get; set; }//MAD
        public string? especialidad { get; set; }//MAD
        public string? sintomas { get; set; }//MAD
        public string? tipo_atencion { get; set; }//MAD
        public string? programacion { get; set; }//MAD
        public string? nro_descanso_medico { get; set; }//MAD
        public string? cambio_realizar { get; set; }//MAD
        public string? moneda_deducible { get; set; }//MAD
        public string? monto_deducible { get; set; }//MAD
        public string? coaseguro { get; set; }//MAD
        public string? tipo_documento_pago { get; set; }//MAD
        public string? numero_documento_pago { get; set; }//MAD
        public string? forma_pago { get; set; }//MAD
        public string? moneda_denominacion { get; set; }//MAD
        public string? monto_denominacion { get; set; }//MAD
        public string? telefono { get; set; }//MAD
        public string? anexo { get; set; }//MAD
        public string? referencia { get; set; }//MAD
        public string? direccion { get; set; }//MAD
        public string? provincia { get; set; }//MAD
        public string? distrito { get; set; }//MAD
    }

    /*INICIO SCTR*/
    public class HistoriaClinicaSctr
    {
        public long cod_historia_clinica { get; set; }//MAD - SCTR
        public string paciente { get; set; }//MAD - SCTR
        public string fecha_creacion { get; set; }//MAD - SCTR
        public string fecha_nacimiento { get; set; }//MAD - SCTR
        public int edad { get; set; }//MAD - SCTR
        public string hora_atencion { get; set; }//MAD - SCTR
        public string celular { get; set; }//MAD - SCTR
        public string pais { get; set; }//MAD - SCTR
        public int id_cliente { get; set; }//MAD - SCTR
        public string? sexo { get; set; }//SCTR
        public string? documento_identidad { get; set; }//SCTR
        public string? numero_documento_id { get; set; }//SCTR
        public string? descripcion_ipress { get; set; }//SCTR
        public string? ipress_telefono { get; set; }//SCTR
        public string? ipress_anexo { get; set; }//SCTR
        public string? empresa { get; set; }//SCTR
        public string? empresa_ruc { get; set; }//SCTR
        public string? horario_trabajo { get; set; }//SCTR
        public string? puesto_cargo { get; set; }//SCTR
        public string? relato { get; set; }//SCTR
        public string? fecha_accidente { get; set; }//SCTR
        public string? hora_accidente { get; set; }//SCTR
        public string? tipo_historia_clinica { get; set; }//SCTR
        public string? pase_atencion { get; set; }//SCTR
        public string? motivo { get; set; }//SCTR
        public string? observacion { get; set; }//SCTR
        public string? ipress_primera_ate { get; set; }//SCTR
        public int? id_clinica { get; set; }//SCTR
        public string? persona_reporta { get; set; }//SCTR
        public int? id_motivo { get; set; }//SCTR
        public int? id_clinica_primera_atencion { get; set; }//SCTR
        public int? numero_atencion { get; set; }//SCTR
        public int? metodo_validacion { get; set; }//SCTR
        public Boolean? hoja_atencion { get; set; }//SCTR
        public int? id_plan { get; set; }//SCTR
        public int? skill { get; set; }//SCTR
        public int? motivo_skill { get; set; }//SCTR
    }

    public class HistoriaClinicaBandejaSctr
    {
        public long cod_historia_clinica { get; set; }
        public string tipo_historia_clinica { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string documento_identidad { get; set; }
        public string numero { get; set; }
        public string paciente { get; set; }
        public string fecha_nacimiento { get; set; }
        public string clinica { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string hoja_atencion { get; set; }
        public string medio_validacion { get; set; }
        public string pase_atencion { get; set; }
        public string observacion { get; set; }
        public string empresa { get; set; }
        public string empresa_ruc { get; set; }
        public string usuario_creacion { get; set; }
        public string motivo { get; set; }
        public string plan { get; set; }
        public string skill { get; set; }
        public long NHIS_PK_POSTGRES { get; set; }
    }

    public class HistoriaClinicaBandejaOtrasLlamadas
    {
        public long cod_historia_clinica { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string clinica { get; set; }
        public string usuario_creacion { get; set; }
        public string motivo { get; set; }
        public string skill { get; set; }
        public string procedencia { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string persona_reporta { get; set; }
        public string motivo_de_llamada { get; set; }
    }
    /*FIN SCTR*/

    /*INICIO AMBULANCIA*/
    public class HistoriaClinicaBandejaAmbulancia
    {
        public int cod_historia_clinica { get; set; }
        public string cod_siteds { get; set; }
        public string cotizado { get; set; }
        public string estado { get; set; }
        public string estado_sm { get; set; }
        public string tipo_servicio { get; set; }
        public string cod_amb_tipo_serv { get; set; }
        public string servicio { get; set; }
        public int? id_paciente { get; set; }
        public int? id_persona { get; set; }
        public Boolean? servicio_playa { get; set; }
        public string? deducible { get; set; }
        public string? coaseguro { get; set; }
        public int? cod_prioridad { get; set; }
        public int? cod_motivo { get; set; }
        public string? cod_asegurado { get; set; }
        public string poliza_asegurado { get; set; }
        public string poliza_certificado { get; set; }
        public string numero_documento_id { get; set; }
        public string correo_electronico { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public string documento_identidad { get; set; }
        public int id_cliente { get; set; }
        public string empresa { get; set; }
        public int? cod_proveedor { get; set; }
        public string proveedor { get; set; }
        public string centro_medico_derivado { get; set; }
        public string especialidad { get; set; }
        public string paciente { get; set; }
        public string prioridad { get; set; }
        public string direccion { get; set; }
        public string direccion_destino { get; set; }
        public int? id_clinica_origen { get; set; }
        public int? id_clinica_destino { get; set; }
        public string alergia_medica { get; set; }
        public string antecedente { get; set; }
        //public string solicitud { get; set; }
        public string regla_oro { get; set; }
        public string ubicacion_dentro_clinica_origen { get; set; }
        public string ubicacion_dentro_clinica_destino { get; set; }
        public string fecha_evento_adverso { get; set; }
        public Boolean? contratante_citrix { get; set; }
        public Boolean? fuera_cobertura { get; set; }
        public string nro_placa_vehicular_poliza { get; set; }
        public string nro_poliza { get; set; }
        public string nro_siniestro_poliza { get; set; }
        public Boolean? flg_ambulancia_respiratoria { get; set; }
        public string ambulancia_respiratoria { get; set; }
        public int? id_tipo_ambulancia { get; set; }
        public int? id_solicitud { get; set; }
        public int? id_solicitante { get; set; }
        public string motivo { get; set; }
        public string motivo_atencion { get; set; }
        public string clasificacion { get; set; }
        public string usuario_creacion { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string observacion { get; set; }
    }

    public class HistoriaClinicaAmbulancia
    {
        //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
        public int CPAR_ID_MOTIVO_CALLMEDICO { get; set; }
        public int CPAR_ID_REFERENCIA_AMBULANCIA { get; set; }
        public int CCEN_ID { get; set; }
        public int CECM_ID { get; set; }
        public int CPAR_ID_SOLICITUD { get; set; }
        public int CHIS_ID { get; set; }

        //TBLMDS_HISTORIA_CLINICA
        public string SHIS_ESTADO { get; set; }
        public string SHIS_CM_ESTADO { get; set; }
        public string NHIS_COD_ESTADO { get; set; }
        public string FHIS_FLG_CM_NUEVA { get; set; }
        public string NHIS_CM_ORDEN { get; set; }
        public string SHIS_REF_DIR { get; set; }
        public string SHIS_CM_REF_DIR { get; set; }
        public string FHIS_FLAG_PROGRAMADA { get; set; }
        public string SHIS_F_PROG { get; set; }
        public string SHIS_COD_TIPO_PROG { get; set; }
        public string SHIS_COD_DR_SOLICITADO { get; set; }
        public string SHIS_COD_DEP { get; set; }
        public string FHIS_CM_DIRECTA { get; set; }
        public string SHIS_FLG_DIRECTO { get; set; }
        public string FHIS_CM_DATOS_COMPLETOS { get; set; }
        public string NHIS_TAR_ATE { get; set; }
        public string SHIS_TIPO_SERVAMB_DRMAS { get; set; }
        public string SHIS_COD_AMB_TIPO_SERV { get; set; }
        public string NHIS_COASEGURO { get; set; }
        public string SHIS_FLAGMONE { get; set; }
        public string NHIS_CAMBIO { get; set; }
        public string SHIS_FOR_ATE { get; set; }
        public string SHIS_CM_MONEDA_DEN { get; set; }
        public string NHIS_CM_DEN_CAMBIO { get; set; }
        public string SHIS_CM_DENOMINACION { get; set; }
        public string SHIS_CONTACTO_PAC { get; set; }
        public string SHIS_CONTACTO_ASEG { get; set; }
        public string SHIS_TIPO_SERVICIO { get; set; }
        public string NHIS_CLASIFICACION_PAC { get; set; }
        public string SHIS_TIPO_DOC_PAGO { get; set; }
        public string SHIS_DESCRP_ZONA { get; set; }
        public string SHIS_COD_EMP { get; set; }
        public string SHIS_USULLA_ATE { get; set; }
        public string CPAC_ID { get; set; }
        public string CPER_ID { get; set; }
        public string CCLI_ID { get; set; }
        public string SHIS_NOM_EMP { get; set; }
        public string DHIS_OBS_CM { get; set; }
        public string NHIS_CLASIFICACION_PAC_CALLMED { get; set; }
        public string SHIS_COD_AUT_PRESTACION { get; set; }
        public string SHIS_COD_ASEGURADO { get; set; }
        public string SHIS_CM_ASEG_PRODUCTO { get; set; }
        public string SHIS_POLIZA_ASEGURADO { get; set; }
        public string SHIS_POLIZA_CERTIFICADO { get; set; }
    }
    /*FIN AMBULANCIA*/

    /*INICIO MAD*/
    public class ClienteAseguradora
    {
        public int CCLT_ID { get; set; }
        //public string SIAF_FINANCIAMIENTO { get; set; }
        public string? SCLT_NOMBRE { get; set; }

    }
    /*FIN MAD*/

    #region "Estado 0 - 2 - 3"
    public class HistoriaClinicaMadAsignacionTiempoDoctor
    {
        public string SHIS_FORMAPAGO { get; set; }
        public string DEN { get; set; }
        public string SHIS_CM_ESTADO { get; set; }
        public int IDCLIENTE { get; set; }
        public int CPER_ID { get; set; }
        public string PACIENTE { get; set; }
        public int EDAD { get; set; }
        public string SPER_TELEFONO_CELULAR { get; set; }
        public string DISTRITO { get; set; }
        public string SDIR_REFERENCIA { get; set; }
        public string SDIR_DESCRIPCION { get; set; }
        public string SDIR_NRO_LOTE { get; set; }
        public string SDIR_INTERIOR { get; set; }
        public string SHIS_OBSERVACION { get; set; }
        public string SHIS_CM_DES_PAC_DESEA { get; set; }
        public int NHIS_CM_COD_PAC_DESEA { get; set; }
        public string SHIS_CM_COD_DR_PAC_DESEA { get; set; }
        public string SHIS_PAC_VIP { get; set; }
        public string SHIS_TIPO_ATE { get; set; }
        public int NHIS_CLASIFICACION_PAC { get; set; }
        public string SHIS_F_PROG { get; set; }
        public DateTime DHIS_FEC_ATE { get; set; }
        public DateTime DHIS_HOR_ATE { get; set; }
        public string SHIS_F_SOLDOCT { get; set; }
        public string SHIS_TMP_COD_TIT { get; set; }
        public int NHIS_MOTIVO_TIPO_PROG { get; set; }
        public int CMED_ID { get; set; }
        public string MEDICO { get; set; }
        public int CESP_ID { get; set; }
        public string ESPECIALIDAD { get; set; }
        public string SHIS_TIPO_DOC_PAGO { get; set; }
        public bool FHIS_CM_DATOS_COMPLETOS { get; set; }
        public string SUBI_PROVINCIA { get; set; }
    }

    public class HistoriaClinicaMadAsignacionEspecialidad
    {
        public int CESP_ID { get; set; }
        public string SESP_NOMBRE { get; set; }
    }

    public class HistoriaClinicaMadAsignacionMedico
    {
        public int CMED_ID { get; set; }
        public string MEDICO { get; set; }
        public string SMED_TIPO_DOCTOR { get; set; }
        public int CESP_ID { get; set; }
        public string SMEP_DESCRIPCION { get; set; }
    }

    public class HistoriaClinicaMadAsignacionEspecialidadMedico
    {
        public int CMED_ID { get; set; }
        public string MEDICO { get; set; }
        public string SMED_TIPO_DOCTOR { get; set; }
    }
    #endregion

    #region "Estado 3 - 5"
    public class HistoriaClinicaMadValidacionTiempo
    {
        public string SHIS_CM_ESTADO { get; set; }
        public int NHIS_CLASIFICACION_PAC { get; set; }
        public string MEDICO { get; set; }
        public string SPER_TELEFONO_CELULAR { get; set; }
        public string SMED_BEEPER { get; set; }
        public string DIRECCION { get; set; }
        public string SDIR_NRO_LOTE { get; set; }
        public string SDIR_INTERIOR { get; set; }
        public string SDIR_URBANIZACION { get; set; }
        public string SDIR_REFERENCIA { get; set; }
        public string CONDUCTOR { get; set; }

    }
    #endregion

    #region "Estado 3 - 6"
    public class HistoriaClinicaMadConfirmarRecepcionMensaje
    {
        public int CHIS_ID { get; set; }
        public string SHIS_CM_ESTADO { get; set; }
        public string SHIS_F_PROG { get; set; }
        public DateTime DHIS_HOR_ATE { get; set; }
        public bool FHIS_FLG_REPROGRAMADA { get; set; }
        public string PACIENTE { get; set; }
        public string DISTRITO { get; set; }
        public string DIRECCION { get; set; }
        public string MEDICO { get; set; }
        public string CONDUCTOR { get; set; }
    }
    #endregion
}