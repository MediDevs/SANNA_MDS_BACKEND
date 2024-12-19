using System.ComponentModel.DataAnnotations;

namespace MDS.Api.Models
{

    public class RegistrarHistoriaClinicaModel
    {
        public string e { get; set; }
        public string prog { get; set; }
        public long codate { get; set; }
        public string clasif { get; set; }
        public string e_tablet { get; set; }
        public long codautorizacion { get; set; }
        public string feclla { get; set; }
        public string hrlla { get; set; }
        public string tiempo { get; set; }
        public string fecate { get; set; }
        public string hrxdefecto { get; set; }
        public string hrestimada { get; set; }
        public string hrllegada { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string paciente { get; set; }
        public string fpago { get; set; }
        public string vip { get; set; }
        public string grupo { get; set; }
        public string periodo { get; set; }
        public string cont { get; set; }
        public string perfil { get; set; }
        public string espec { get; set; }
        public string doctor { get; set; }
        public string grupos { get; set; }
        public string empresa { get; set; }
        public string usuario { get; set; }
        public string cod_doc { get; set; }
    }

    public class CreateHistoriaClinicaMedioComunicacionMadViewModel
    {
        public long id_historiaclinica { get; set; }
        public long numero { get; set; }
        public int usuario_creacion { get; set; }
    }

    public class CreateHistoriaClinicaMadViewModel
    {
        public long cmed_id { get; set; }

        public int cpac_id { get; set; }

        public int cesp_id { get; set; }

        public int cest_id { get; set; }

        public int cper_id { get; set; }

        public int cser_id { get; set; }

        public int cpai_id { get; set; }

        public string cubi_id { get; set; }

        public int cmep_id { get; set; }

        public int ctdo_id { get; set; }

        public int cclt_id { get; set; }

        public int cdsn_id { get; set; }

        public string estado { get; set; }

        public string prog { get; set; }

        public string codautorizacion { get; set; }

        public DateTime feclla { get; set; }

        public DateTime horlla { get; set; }

        public int tiempo { get; set; }

        public DateTime fecate { get; set; }

        public DateTime horate { get; set; }

        public DateTime hrlledr { get; set; }

        public DateTime horoplla { get; set; }

        public string fpago { get; set; }

        public string vip { get; set; }

        public string grupo { get; set; }

        public int cont { get; set; }

        public string perfil { get; set; }

        public string empresa { get; set; }


        //INICIO DE NUEVOS CAMPOS PARA ESTADO EN MAD

        //public string cm_estado { get; set; }       //SHIS_CM_ESTADO

        //public int cod_estado { get; set; }         //NHIS_COD_ESTADO

        //public int cm_orden { get; set; }           //NHIS_CM_ORDEN


        public bool flg_cm_nueva { get; set; }      //FHIS_FLG_CM_NUEVA

        public string usulla_ate { get; set; }      //SHIS_USULLA_ATE

        public string cod_emp { get; set; }         //SHIS_COD_EMP

        public bool flag_programada { get; set; }   //FHIS_FLAG_PROGRAMADA

        public string f_soldoct { get; set; }       //SHIS_F_SOLDOCT

        public int motivo_tipo_prog { get; set; }   //@NHIS_MOTIVO_TIPO_PROG

        public string observacion { get; set; }     //SHIS_OBSERVACION

        public decimal tar_ate { get; set; }        //NHIS_TAR_ATE

        public decimal cambio { get; set; }         //NHIS_CAMBIO

        public string codtar_ate { get; set; }      //SHIS_CODTAR_ATE

        public string ntar_ate { get; set; }        //SHIS_NTAR_ATE

        public string tarj_mc { get; set; }         //SHIS_TARJ_MC

        public DateTime fvenc_ate { get; set; }     //DHIS_FVENC_ATE

        public string sin_ate { get; set; }         //SHIS_SIN_ATE

        public string contacto_pac { get; set; }    //SHIS_CONTACTO_PAC

        public string contacto_aseg { get; set; }   //SHIS_CONTACTO_ASEG

        public string cod_aut_prestacion { get; set; }  //SHIS_COD_AUT_PRESTACION

        public string cod_asegurado { get; set; }       //SHIS_COD_ASEGURADO

        public string cod_solgen { get; set; }          //SHIS_COD_SOLGEN

        public string cm_aseg_producto { get; set; }    //SHIS_CM_ASEG_PRODUCTO

        public string poliza_asegurado { get; set; }    //SHIS_POLIZA_ASEGURADO

        public string poliza_certificado { get; set; }  //SHIS_POLIZA_CERTIFICADO

        public string tipo_afiliacion { get; set; }     //SHIS_TIPO_AFILIACION

        public int id_paquete { get; set; }             //NHIS_ID_PAQUETE

        public bool primera_consulta { get; set; }      //FHIS_PRIMERA_CONSULTA

        public int clasificacion_pac { get; set; }      //NHIS_CLASIFICACION_PAC

        public int id_periodo_consulta { get; set; }    //NHIS_ID_PERIODO_CONSULTA    

        public string tipo_ate { get; set; }            //SHIS_TIPO_ATE

        public string tipo_doc_pago { get; set; }       //SHIS_TIPO_DOC_PAGO

        public int id_condicion_especial_pago { get; set; }     //NHIS_ID_CONDICION_ESPECIAL_PAGO

        public string descrp_zona { get; set; }                 //SHIS_DESCRP_ZONA

        public string empresa_paciente { get; set; }            //SHIS_EMPRESA_PACIENTE

        public int id_mrp { get; set; }                         //NHIS_ID_MRP

        public int cod_categoria_serv_cliente { get; set; }     //NHIS_COD_CATEGORIA_SERV_CLIENTE

        public int modo_atencion_medico { get; set; }           //NHIS_MODO_ATENCION_MEDICO

        public int usuariocreacion { get; set; }

        //public DateTime fechacreacion { get; set; }

    }
    public class CreateHistoriaClinicaViewModel
    {
        public string? pk_pg { get; set; }
        //[Required]
        public long id_persona { get; set; }
        //[Required]
        public long id_empresa { get; set; }
        //[Required]
        public long id_clinica { get; set; }
        //[Required]
        public long id_motivo { get; set; }
        //[Required]
        public int id_plan { get; set; }
        //[Required]
        public string? horario_trabajo { get; set; }
        //[Required]
        public string? cargo { get; set; }
        public string? relato { get; set; }
        public string? fecha_accidente { get; set; }
        public string? hora_accidente { get; set; }
        public string observacion { get; set; }
        public string? primera_atencion { get; set; }
        //[Required]
        public string? metodo_validacion { get; set; }
        //[Required]
        public int? hoja_atencion { get; set; }
        //[Required]
        public string? ubigeo { get; set; }
        //[Required]
        public int skill { get; set; }
        //[Required]
        public int motivo_skill { get; set; }
        public int centro_clinico { get; set; }
        public int empresa { get; set; }
        public int corredor_seguro { get; set; }
        public int paciente_asegurado { get; set; }
        public string? persona_reporta_clinica { get; set; }
        public string? persona_reporta_empresa { get; set; }
        public string? persona_reporta_seguro { get; set; }
        public string? persona_reporta_asegurado { get; set; }
        public int usuario_creacion { get; set; }
        public string? usuario_creacion_pg { get; set; }
        public int pase_atencion { get; set; }
        public int? id_clinica_primera_atencion { get; set; }
        public int estado { get; set; }

        //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
        public int? CPAR_ID_MOTIVO_CALLMEDICO { get; set; }
        public int? CPAR_ID_REFERENCIA_AMBULANCIA { get; set; }
        public int? CCEN_ID { get; set; }
        public int? CECM_ID { get; set; }
        public int? CPAR_ID_SOLICITUD { get; set; }

        //TBLMDS_HISTORIA_CLINICA
        public string? SHIS_CM_ESTADO { get; set; }
        public int? NHIS_COD_ESTADO { get; set; }
        public Boolean? FHIS_FLG_CM_NUEVA { get; set; }
        public int? NHIS_CM_ORDEN { get; set; }
        public string? SHIS_REF_DIR { get; set; }
        public int? NHIS_EDAD_ATE { get; set; }
        public string? SHIS_CEL_PAC { get; set; }
        public string? SHIS_NOM_EMP { get; set; }
        public string? SHIS_CM_REF_DIR { get; set; }
        public Boolean? FHIS_FLAG_PROGRAMADA { get; set; }
        public int? NHIS_COD_TARIFA { get; set; }
        public string? SHIS_F_PROG { get; set; }
        public string? SHIS_COD_TIPO_PROG { get; set; }
        public string? SHIS_COD_DR_SOLICITADO { get; set; }
        public string? SHIS_COD_DEP { get; set; }
        public Boolean? FHIS_CM_DIRECTA { get; set; }
        public string? SHIS_FLG_DIRECTO { get; set; }
        public Boolean? FHIS_CM_DATOS_COMPLETOS { get; set; }
        public int? NHIS_COD_PRIORIDAD_CALLMED { get; set; }
        public int? NHIS_COD_MOTIVO_ATE_CALLMED { get; set; }
        public int? NHIS_TAR_ATE { get; set; }
        public string? DHIS_FEC_ATE { get; set; }
        public string? SHIS_TIPO_SERVAMB_DRMAS { get; set; }
        public string? SHIS_COD_AMB_TIPO_SERV { get; set; }
        public int? NHIS_COASEGURO { get; set; }
        public string? SHIS_FLAGMONE { get; set; }
        public int? NHIS_CAMBIO { get; set; }
        public string? SHIS_FOR_ATE { get; set; }
        public string? SHIS_CM_MONEDA_DEN { get; set; }
        public int? NHIS_CM_DEN_CAMBIO { get; set; }
        public string? SHIS_CM_DENOMINACION { get; set; }
        public string? SHIS_CONTACTO_PAC { get; set; }
        public string? SHIS_CONTACTO_ASEG { get; set; }
        public string? SHIS_AMB_DIR_ORIGEN { get; set; }
        public string? SHIS_AMB_DES_DIS_ORIGEN { get; set; }
        public string? SHIS_AMB_COD_DIS_ORIGEN { get; set; }
        public string? SHIS_AMB_REF_DIR_ORIGEN { get; set; }
        public string? DHIS_AMB_FECHA_INI { get; set; }
        public string? DHIS_AMB_HORA_INI { get; set; }
        public string? DHIS_AMB_FECHA_FIN { get; set; }
        public string? DHIS_AMB_HORA_FIN { get; set; }
        public string? SHIS_AMB_COD_DIS_DESTINO { get; set; }
        public string? SHIS_AMB_DES_DIS_DESTINO { get; set; }
        public string? SHIS_AMB_DIR_DESTINO { get; set; }
        public string? SHIS_AMB_REF_DIR_DESTINO { get; set; }
        public string? SHIS_TIPO_SERVICIO { get; set; }
        public int? NHIS_CLASIFICACION_PAC { get; set; }
        public string? SHIS_TIPO_DOC_PAGO { get; set; }
        public string? SHIS_DESCRP_ZONA { get; set; }
        public string? DHIS_HOR_ATE { get; set; }
        public string? SHIS_COD_EMP { get; set; }
        public string? SHIS_USULLA_ATE { get; set; }
        public int? CPAC_ID { get; set; }
        public int? CPER_ID { get; set; }
        public int? CCLI_ID { get; set; }
        public string? DHIS_OBS_CM { get; set; }
        public int? NHIS_CLASIFICACION_PAC_CALLMED { get; set; }
        public int? NHIS_ID_TIPO_TRASLADO_CALLMED { get; set; }
        public string? SHIS_COD_AUT_PRESTACION { get; set; }
        public string? SHIS_CONTRATANTE_CITRIX { get; set; }
        public string? SHIS_COD_ASEGURADO { get; set; }
        public string? SHIS_CM_ASEG_PRODUCTO { get; set; }
        public string? SHIS_POLIZA_ASEGURADO { get; set; }
        public string? SHIS_POLIZA_CERTIFICADO { get; set; }
        public Boolean? FHIS_AMB_SERVICIO_PLAYA { get; set; }
        public Boolean? FHIS_FUERA_COBERTURA { get; set; }
        public string? SHIS_DIRECCION_ORIGEN { get; set; }
        public string? SHIS_DIRECCION_DESTINO { get; set; }
        public int? CCLI_ID_ORIGEN { get; set; }
        public int? CCLI_ID_DESTINO { get; set; }
        public string? SHIS_ALERGIA_MEDICA { get; set; }
        public string? SHIS_ATENCEDENTE { get; set; }
        public int? CTAM_ID { get; set; }
        public string? SHIS_RUC_EVENTO { get; set; }
        public string? SHIS_RAZON_SOCIAL_EVENTO { get; set; }
        public string? SHIS_DIRECCION_FISCAL_EVENTO { get; set; }
        public int? CPOL_ID { get; set; }
        public string? SHIS_NRO_PLACA { get; set; }
        public string? SHIS_NRO_POLIZA { get; set; }
        public string? SHIS_SINIESTRO { get; set; }
        public string? SHIS_AHUTORIZA_CORTESIA { get; set; }
        public string? SHIS_REGLA_ORO { get; set; }
        public Boolean? FHIS_AMB_RESPIRATORIA { get; set; }
        public int? CPAR_ID_SOLICITANTE { get; set; }
        public string? SHIS_UBIC_DENTRO_CLINICA_ORIGEN { get; set; }
        public string? SHIS_UBIC_DENTRO_CLINICA_DESTINO { get; set; }
        public int? NPRV_ID { get; set; }
        public string? DHIS_FECHA_EVENTO_ADVERSO { get; set; }
        public Boolean? FHIS_CITRIX { get; set; }
    }

    public class UpdateHistoriaClinicaViewModel
    {
        public string? pk_pg { get; set; }
        [Required]
        public long cod_historia_clinica { get; set; }
        //[Required]
        public long id_persona { get; set; }
        //[Required]
        public long id_empresa { get; set; }
        //[Required]
        public long id_clinica { get; set; }
        //[Required]
        public long id_motivo { get; set; }
        //[Required]
        public int id_plan { get; set; }
        //[Required]
        public string? horario_trabajo { get; set; }
        //[Required]
        public string? cargo { get; set; }
        public string? relato { get; set; }
        public string? fecha_accidente { get; set; }
        public string? hora_accidente { get; set; }
        public string observacion { get; set; }
        public string? primera_atencion { get; set; }
        //[Required]
        public string? metodo_validacion { get; set; }
        //[Required]
        public int? hoja_atencion { get; set; }
        //[Required]
        public string? ubigeo { get; set; }
        //[Required]
        public int skill { get; set; }
        //[Required]
        public int motivo_skill { get; set; }
        public int centro_clinico { get; set; }
        public int empresa { get; set; }
        public int corredor_seguro { get; set; }
        public int paciente_asegurado { get; set; }
        public string? persona_reporta_clinica { get; set; }
        public string? persona_reporta_empresa { get; set; }
        public string? persona_reporta_seguro { get; set; }
        public string? persona_reporta_asegurado { get; set; }
        public int usuario_modificacion { get; set; }
        public string? usuario_modificacion_pg { get; set; }
        public int? id_clinica_primera_atencion { get; set; }
        public int? pase_atencion { get; set; }
        public int estado { get; set; }
    }

    public class DeleteHistoriaClinicaViewModel
    {
        public string? pk_pg { get; set; }
        [Required]
        public long cod_historia_clinica { get; set; }
        public long? id_motivo { get; set; }
        public int usuario_eliminacion { get; set; }
        public string? usuario_eliminacion_pg { get; set; }
    }

    public class AddHistoriaClinicaMadAuditoriaEstadoViewModel
    {
        public int NUMEROHISTORIA { get; set; }
        public string ESTADO { get; set; }
        public string USUARIO { get; set; }
        public string OBSERVACION { get; set; }
        public string CAMBIO { get; set; }
        public int USUARIO_CREACION { get; set; }
    }

    public class SPRMDS_UPDATE_HISTORIA_CLINICA_AUDITORIA_ESTADOViewModel
    {
        public int @CHIS_ID { get; set; }
        public int @CMED_ID { get; set; }
        public string @SHIS_COD_TIPO_DOCTOR { get; set; }
        public DateTime @DHIS_HORASGDR_ATE { get; set; }
        public DateTime @DHIS_FECASGDR_ATE { get; set; }
        public string @SHIS_USUASGDR_ATE { get; set; }
        public int @CESP_ID { get; set; }
        public DateTime @DHIS_FEC_ATE { get; set; }
        public DateTime @DHIS_HOR_ATE { get; set; }
        public string @SHIS_TMP_COD_TIT { get; set; }
        public int @NHIS_CM_TIEMPO { get; set; }
        public string @SHIS_COD_DR_SOLICITADO { get; set; }
        public bool @FHIS_FLAG_PROGRAMADA { get; set; }
        public string @SHIS_F_SOLDOCT { get; set; }
        public string @SHIS_F_PROG { get; set; }
        public int @NHIS_MOTIVO_TIPO_PROG { get; set; }
        public int @NHIS_CLASIFICACION_NEG_SOPORTE { get; set; }
        public string @SHIS_CM_ESTADO { get; set; }
        public int @NHIS_COD_ESTADO { get; set; }
        public int @NHIS_ORDEN { get; set; }
        public string @SHIS_CM_ESP_ANTERIOR { get; set; }
        public string @SHIS_CM_COD_DR_ANTERIOR { get; set; }
        public string @SHIS_CM_DR_ANTERIOR { get; set; }
        public bool @FHIS_FLG_VALIDACION_DIRECTA { get; set; }
    }
}
