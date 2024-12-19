using System;

namespace MDS.Dto
{
    public class HistoriaClinicaUbigeoDto
    {
        public string codigo { get; set; }

        public string departamento { get; set; }

        public string provincia { get; set; }

        public string distrito { get; set; }

    }

    public class HistoriaClinicaClienteDto
    {
        public int codigo { get; set; }
        public string numero { get; set; }
    }

    public class HistoriaClinicaPaciente_x_NumeroDto
    {
        public int codigo { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombres { get; set; }
        public string tipodocumento { get; set; }
        public string dni { get; set; }
        public string fechanacimiento { get; set; }
        public int edad { get; set; }
        public int genero { get; set; }
        public string? email { get; set; }
        public string? celular { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string? direccion { get; set; }
        public string? lote { get; set; }
        public string? interior { get; set; }
        public string? urbanizacion { get; set; }
        public string? referencia { get; set; }
    }

    public class HistoriaClinicaPaciente_x_DniDto
    {
        public string dni { get; set; }

        public string nombres { get; set; }

        public long codigo { get; set; }

    }

    public class RegistrarHistoriaClinicaDto
    {
        public long numero_historia { get; set; }
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
    public class Prueba_Historias_ClinicasDto
    {

        public long chis_id { get; set; }

        public string e { get; set; }

        public long codate { get; set; }

        public string distrito { get; set; }

        public string paciente { get; set; }

        public string fecha { get; set; }

    }


    public class HistoriaClinicaMadDto
    {
        public long cmed_id { get; set; }

        public long cpac_id { get; set; }

        public long cesp_id { get; set; }

        public long cest_id { get; set; }

        public long cper_id { get; set; }

        public long cser_id { get; set; }

        public long cdsn_id { get; set; }

        public long cpai_id { get; set; }

        public long cubi_id { get; set; }

        public long cprv_id { get; set; }

        public long ctdo_id { get; set; }

        public long cpla_id { get; set; }

        public long cmot_id { get; set; }

        public long cclt_id { get; set; }

        public long ccli_id { get; set; }

        public long nhis_cod { get; set; }

        public bool fhis_segui_ate { get; set; }

        public bool fhis_flag { get; set; }

        public bool fhis_sb_ate { get; set; }

        public bool fhis_exi_ate { get; set; }

        public string shis_estado { get; set; }

        public int nhis_prioridad { get; set; }

        public string shis_flagmone { get; set; }

        public decimal nhis_cambio { get; set; }

        public string shis_accide { get; set; }

        public string shis_cod_emp { get; set; }

        public string shis_nom_emp { get; set; }

        public string shis_cod_tit { get; set; }

        public string shis_nom_tit { get; set; }

        public string shis_cod_dep { get; set; }

        public string shis_cod_dir { get; set; }

        public string shis_tlf_dir { get; set; }

        public string shis_des_dir { get; set; }

        public string shis_cod_dis { get; set; }

        public string shis_des_dis { get; set; }

        public string shis_cod_prov { get; set; }

        public string shis_des_prov { get; set; }

        public string shis_dis_dir { get; set; }

        public string shis_ref_dir { get; set; }

        public DateTime dhis_hor_ate { get; set; }

        public DateTime dhis_fec_ate { get; set; }

        public DateTime dhis_horlla_ate { get; set; }

        public DateTime dhis_feclla_ate { get; set; }

        public string shis_usulla_ate { get; set; }

        public DateTime dhis_horasgdr_ate { get; set; }

        public DateTime dhis_fecasgdr_ate { get; set; }

        public string shis_usuasgdr_ate { get; set; }

        public DateTime dhis_hordrlla_ate { get; set; }

        public DateTime dhis_fecdrlla_ate { get; set; }

        public string shis_usudrlla_ate { get; set; }

        public DateTime dhis_horoplla_ate { get; set; }

        public DateTime dhis_fecoplla_ate { get; set; }

        public string shis_usuoplla_ate { get; set; }

        public DateTime dhis_hordia_ate { get; set; }

        public DateTime dhis_fecdia_ate { get; set; }

        public string shis_usudia_ate { get; set; }

        public int nhis_tar_ate { get; set; }

        public string shis_obs_ate { get; set; }

        public string shis_genero_ate { get; set; }

        public int nhis_edad_ate { get; set; }

        public string shis_sin_ate { get; set; }

        public DateTime dhis_hrlledr { get; set; }

        public string shis_estado_ate { get; set; }

        public string shis_for_ate { get; set; }

        public string shis_codtar_ate { get; set; }

        public string shis_ntar_ate { get; set; }

        public DateTime dhis_fvenc_ate { get; set; }

        public bool fhis_nova { get; set; }

        public int nhis_rzona { get; set; }

        public int nhis_rhor { get; set; }

        public int nhis_rocup { get; set; }

        public int nhis_otro { get; set; }

        public int nhis_rcab { get; set; }

        public int nhis_abonado { get; set; }

        public bool fhis_vis_prog { get; set; }

        public decimal fhis_premio { get; set; }

        public string shis_codaut_rimac { get; set; }

        public string shis_polord_rimac { get; set; }

        public string shis_pol_rimac { get; set; }

        public string shis_ord_rimac { get; set; }

        public bool fhis_obs48 { get; set; }

        public bool fhis_exp { get; set; }

        public int nhis_cod_exp { get; set; }

        public int nhis_coaseguro { get; set; }

        public string shis_canc_ate { get; set; }

        public bool fhis_activi { get; set; }

        public bool fhis_activi1 { get; set; }

        public bool fhis_bool_original { get; set; }

        public string shis_cha_codaseg { get; set; }

        public string shis_cod_esp { get; set; }

        public string shis_cod_directo { get; set; }

        public string shis_cod_hia { get; set; }

        public bool fhis_val { get; set; }

        public string shis_f_soldoct { get; set; }

        public string shis_f_prog { get; set; }

        public string shis_flg_directo { get; set; }

        public string shis_dni { get; set; }

        public string shis_cod_tipo_doctor { get; set; }

        public bool fhis_flgvnr { get; set; }

        public string shis_flg_listgen { get; set; }

        public DateTime dhis_fec_listgen { get; set; }

        public string shis_usu_listgen { get; set; }

        public DateTime dhor_listgen { get; set; }

        public int nhis_cod_listgen { get; set; }

        public int nhis_correl { get; set; }

        public bool fhis_flg_boleta { get; set; }

        public string shis_cod_boleta { get; set; }

        public string shis_flg_bolman { get; set; }

        public string shis_codaseg_eps { get; set; }

        public DateTime dhis_fec_reg_bol { get; set; }

        public string shis_usu_reg_bol { get; set; }

        public string shis_flg_ficha { get; set; }

        public string shis_cod_dr_solicitado { get; set; }

        public bool fhis_flag_programada { get; set; }

        public string shis_flg_dr_solicitado { get; set; }

        public string shis_cod_solgen { get; set; }

        public bool fhis_flg_asignar_dr { get; set; }

        public string shis_cel_pac { get; set; }

        public string shis_flg_pvta { get; set; }

        public int nhis_cm_orden { get; set; }
        public string shis_cm_estado { get; set; }

        public string shis_cm_estado_ant { get; set; }

        public string shis_cm_ref_dir { get; set; }

        public bool fhis_cm_flag_vip { get; set; }

        public bool fhis_cm_directa { get; set; }

        public bool fhis_cm_datos_completos { get; set; }

        public int nhis_cm_cod_pac_desea { get; set; }

        public string shis_cm_des_pac_desea { get; set; }

        public string shis_cm_cod_dr_pac_desea { get; set; }

        public string shis_cm_nom_dr_pac_desea { get; set; }

        public string shis_contacto_pac { get; set; }

        public int nhis_cm_tiempo { get; set; }

        public bool fhis_flg_reprogramada { get; set; }

        public string shis_cm_motivo_cancelacion { get; set; }

        public DateTime dhis_feclledr { get; set; }

        public string shis_cm_moneda_den { get; set; }

        public string shis_cm_denominacion { get; set; }

        public string shis_cm_autorizado { get; set; }

        public string shis_cm_esp_anterior { get; set; }

        public string shis_cm_cod_dr_anterior { get; set; }

        public string shis_cm_dr_anterior { get; set; }

        public DateTime dhis_cm_fec_anterior { get; set; }

        public DateTime dhis_cm_hor_anterior { get; set; }

        public string dhis_obs_cm { get; set; } //dhis_obs_cm 

        public bool fhis_flg_cm_nueva { get; set; }

        public DateTime dhis_cm_fec_desasig { get; set; }

        public DateTime dhis_cm_hor_desasig { get; set; }

        public string shis_cm_inf_pac_anterior { get; set; }

        public string shis_cod_dis_cambiar { get; set; }

        public string shis_des_dis_cambiar { get; set; }

        public string shis_cod_dr_env_msj { get; set; }

        public string shis_contacto_aseg { get; set; }

        public string shis_codigo_sia { get; set; }

        public string shis_usu_bloq { get; set; }

        public decimal nhis_cm_den_cambio { get; set; }

        public string shis_cm_motivo_cambio_ded { get; set; }

        public string shis_cm_aut_cambio_ded { get; set; }

        public decimal nhis_cm_ded_anterior { get; set; }

        public string shis_cm_opcion_cambio { get; set; }

        public string shis_cm_aseg_producto { get; set; }

        public int nhis_clasificacion_pac { get; set; }

        public string shis_tipo_servicio { get; set; }

        public int nhis_cod_asig { get; set; }

        public string shis_cod_amb { get; set; }

        public string shis_nom_amb { get; set; }

        public string shis_nom_cs { get; set; }

        public int nhis_cod_cs { get; set; }

        public string shis_pac_vip { get; set; }

        public int nhis_cod_ate_previa { get; set; }

        public int nhis_cod_subclasif { get; set; }

        public string shis_tarj_mc { get; set; }

        public string shis_tipo_servamb_drmas { get; set; }

        public string shis_tipo_servamb_pacifico { get; set; }

        public string shis_tipo_ate { get; set; }

        public DateTime dhis_fecconfirmacion_ate { get; set; }

        public DateTime dhis_horconfirmacion_ate { get; set; }

        public string shis_usuconfirmacion_ate { get; set; }

        public string shis_tipo_reprog { get; set; }

        public bool fhis_flg_tiempo_mayor { get; set; }

        public bool fhis_fecha_max { get; set; }

        public bool fhis_hora_max { get; set; }

        public string shis_motivo_aut { get; set; }

        public string shis_obs_aut { get; set; }

        public string shis_amb_cod_dis_origen { get; set; }

        public string shis_amb_des_dis_origen { get; set; }

        public string shis_amb_dir_origen { get; set; }

        public string shis_amb_ref_dir_origen { get; set; }

        public string shis_cod_tipo_prog { get; set; }

        public string shis_cod_amb_tipo_serv { get; set; }

        public DateTime dhis_amb_fecha_ini { get; set; }

        public DateTime dhis_amb_hora_ini { get; set; }

        public DateTime dhis_amb_fecha_fin { get; set; }

        public DateTime dhis_amb_hora_fin { get; set; }

        public int nhis_amb_tiempo { get; set; }

        public int nhis_cod_tarifa { get; set; }

        public string shis_amb_cod_dis_destino { get; set; }

        public string shis_amb_des_dis_destino { get; set; }

        public string shis_amb_dir_destino { get; set; }

        public string shis_amb_cond_viaje { get; set; }

        public string shis_amb_tipo_traslado { get; set; }

        public string shis_des_siniestro { get; set; }

        public bool fhis_amb_servicio_playa { get; set; }

        public bool fhis_flg_boleta_fact { get; set; }

        public string shis_tipo_doc_pago { get; set; }

        public string shis_personal_contacto { get; set; }

        public string shis_tlf_contacto { get; set; }

        public bool fhis_primera_consulta { get; set; }

        public int nhis_cod_repo_amb { get; set; }

        public bool fhis_flg_reg_bd_tablet { get; set; }

        public string shis_cod_aut_prestacion { get; set; }

        public string shis_cod_asegurado { get; set; }

        public string shis_poliza_asegurado { get; set; }

        public string shis_poliza_certificado { get; set; }

        public string shis_tipo_afiliacion { get; set; }

        public bool fhis_flg_reingresar_tablet { get; set; }

        public int nhis_cod_estado { get; set; }

        public bool fhis_flg_registrar_ate_tablet { get; set; }

        public DateTime dhis_fec_env_sms { get; set; }

        public DateTime dhis_hor_env_sms { get; set; }

        public string shis_descrp_zona { get; set; }

        public bool fhis_flg_correo_enviado { get; set; }

        public bool fhis_flg_sms_enviado { get; set; }

        public bool fhis_flg_sms_programado { get; set; }

        public DateTime dhis_fh_asignacion { get; set; }

        public bool fhis_atencion_referencial { get; set; }

        public bool fhis_flg_culminado_tablet { get; set; }

        public bool fhis_flg_exportado_qw { get; set; }

        public DateTime dhis_fecha_exportado_qw { get; set; }

        public DateTime dhis_fecha_reingreso { get; set; }

        public int nhis_cod_no_tbl { get; set; }

        public int nhis_id_paquete { get; set; }

        public bool fhis_servicio_provisionado_sap { get; set; }

        public string shis_tipo_registro_hhmm { get; set; }

        public DateTime dhis_fechaajusteextorno_hhmm { get; set; }

        public bool fhis_servicio_provisionado_hhmm { get; set; }

        public int nhis_id_condicion_especial_pago { get; set; }

        public bool fhis_flg_validacion_directa { get; set; }

        public bool fhis_flg_examen_medico { get; set; }

        public bool fhis_flg_encuesta_dolor_abdominal { get; set; }

        public string shis_empresa_paciente { get; set; }

        public bool fhis_flg_aseg_reg { get; set; }

        public bool fhis_paciente_traslado { get; set; }

        public int nhis_id_mrp { get; set; }

        public string shis_cod_dist_envio_boleta { get; set; }

        public string shis_direccion_envio_boleta { get; set; }

        public bool fhis_flg_comprobante_enviado { get; set; }

        public bool fhis_flg_comprobante_envio_validando { get; set; }

        public string shis_cod_tipo_ce_emitido { get; set; }

        public DateTime dhis_fec_reg_ce { get; set; }

        public DateTime dhis_hora_reg_ce { get; set; }

        public string shis_numero_ce { get; set; }

        public string shis_usuario_reg_ce { get; set; }

        public bool fhis_flg_sms_cronico_pne { get; set; }

        public bool fhis_flg_sms_cronico_pnc { get; set; }

        public bool fhis_flg_atencion_pagada { get; set; }

        public int nhis_id_periodo_consulta { get; set; }

        public int nhis_contador_periodo { get; set; }

        public int nhis_periodo_mes { get; set; }

        public string shis_numero_orden_delivery { get; set; }

        public bool fhis_flg_env_correo_auto_dronline { get; set; }

        public bool fhis_flg_reenviar_ce { get; set; }

        public int nhis_cod_categoria_serv_cliente { get; set; }

        public bool fhis_flg_onbase { get; set; }

        public int nhis_cod_documento_culminacion { get; set; }

        public int nhis_cod_tipo_ingreso { get; set; }

        public bool fhis_flg_efectividad_ate { get; set; }

        public bool fhis_flg_derivar { get; set; }

        public string shis_derivar_motivo { get; set; }

        public string shis_unidad_derivada { get; set; }

        public bool fhis_flg_nuevo_pac_programa { get; set; }

        public string shis_carta_garantia { get; set; }

        public bool fhis_flg_ate_con_med_covid_19 { get; set; }

        public bool fhis_editar_provisionado_sap { get; set; }

        public int nhis_estado_incidencia { get; set; }

        public int nhis_nro_incidencia { get; set; }

        public int nhis_cod_convenio { get; set; }

        public bool fhis_flg_cotizado_callmed { get; set; }

        public int nhis_cod_prioridad_callmed { get; set; }

        public int nhis_cod_motivo_ate_callmed { get; set; }

        public string shis_amb_ref_dir_destino { get; set; }

        public int nhis_id_tipo_traslado_callmed { get; set; }

        public bool fhis_flg_no_emitir_ce { get; set; }

        public string shis_num_operacion_ap { get; set; }

        public bool myproperty { get; set; }

        public DateTime dhis_fecha_inyectable { get; set; }

        public int nhis_inyectable_cantidad { get; set; }

        public bool fhis_flg_env_correo_auto_cronicos_receta { get; set; }

        public int nhis_cod_tipo_seg_cronico { get; set; }

        public int nhis_id_envio_ce { get; set; }

        public int nhis_clasificacion_pac_callmed { get; set; }

        public int nhis_clasificacion_neg_soporte { get; set; }

        public bool fhis_flg_validar_llegada_callmed { get; set; }

        public int nhis_modo_atencion_medico { get; set; }

        public bool fhis_flg_monitoreo { get; set; }

        public string shis_antecedentes_ate { get; set; }

        public int nhis_clasificacion_atencion_referenciada { get; set; }

        public int nhis_laboratorio_nutricion { get; set; }

        public int nhis_id_mecanismo_pago { get; set; }

        public int nhis_id_beneficio { get; set; }

        public bool fhis_agudo_sbs { get; set; }

        public int nhis_motivo_tipo_prog { get; set; } //verificar = fhis_motivo_tipo_prog

        public string shis_dni_titular { get; set; }

        public bool fhis_flg_pago_hhmm { get; set; }

        public bool fhis_flg_envio_documentos_telemedicina { get; set; }

        public string shis_contratante_citrix { get; set; }

        public bool fhis_flg_ficha_medica_registrada { get; set; }

        public bool fhis_flg_encuesta_cronicos { get; set; }

        public string shis_usuario_reg_encuesta_cronicos { get; set; }

        public bool fhis_flg_devengado { get; set; }

        public bool fhis_flg_problemas_ti { get; set; }

        public DateTime dhis_fecha_operacion_ap { get; set; }

        public string shis_uso_epp { get; set; }

        public string shis_grupo_cronicos { get; set; }

        public int nhis_dias_dm { get; set; }

        public string shis_medio_pago { get; set; }

        public bool fhis_flg_envio_documentos_midoc { get; set; }

        public int nhis_id_tipo_serv_mi_doc { get; set; }

        public bool fhis_flg_guardado { get; set; }

        public bool fhis_flg_ficha_psico { get; set; }

        public string shis_persona_reporta_clinica { get; set; }

        public string shis_horario_trabajo { get; set; }

        public string shis_cargo { get; set; }

        public string shis_relato { get; set; }

        public DateTime dhis_fecha_accidente { get; set; }
        public DateTime dhis_hora_accidente { get; set; }

        public string shis_observacion { get; set; }

        public int nhis_id_primera_atencion { get; set; }

        public string shis_primera_atencion { get; set; }

        public string shis_metodo_validacion { get; set; }

        public bool fhis_hoja_atencion { get; set; }

        public string subi_ubigeo_accidente { get; set; } //cubi_ubigeo_accidente

        public int nhis_skill { get; set; }

        public int nhis_motivo_skill { get; set; }

        public bool fhis_centro_clinico { get; set; }

        public bool fhis_empresa { get; set; }

        public bool fhis_corredor_seguro { get; set; }

        public bool fhis_paciente_asegurado { get; set; }

        public string sate_persona_reporta_empresa { get; set; }

        public string sate_persona_reporta_seguro { get; set; }

        public bool fate_persona_reporta_asegurado { get; set; } // sate_persona_reporta_asegurado

        public int nhis_usuario_creacion { get; set; }

        public DateTime dhis_fecha_creacion { get; set; }

        public int nhis_usuario_modificacion { get; set; }

        public DateTime dhis_fecha_modificacion { get; set; }

    }

    public class Historias_ClinicasDto
    {

        public long chis_id { get; set; }

        public long cmed_id { get; set; }

        public long cpac_id { get; set; }

        public long cesp_id { get; set; }


        public long cest_id { get; set; }

        public long cper_id { get; set; }

        public long cser_id { get; set; }

        public long cdsn_id { get; set; }

        public long cpai_id { get; set; }

        public long cubi_id { get; set; }

        public long cprv_id { get; set; }

        public long ctdo_id { get; set; }

        public long cpla_id { get; set; }


        public long cmot_id { get; set; }

        public long cclt_id { get; set; }

        public long ccli_id { get; set; }

        public long mnhis_cod { get; set; }

        public bool fhis_segui_ate { get; set; }

        public bool fhis_flag { get; set; }

        public bool fhis_sb_ate { get; set; }

        public bool fhis_exi_ate { get; set; }

        public string shis_estado { get; set; }

        public int nhis_prioridad { get; set; }

        public string shis_flagmone { get; set; }

        public decimal nhis_cambio { get; set; }

        public string shis_accide { get; set; }

        public string shis_cod_emp { get; set; }

        public string shis_nom_emp { get; set; }

        public string shis_cod_tit { get; set; }

        public string shis_nom_tit { get; set; }

        public string shis_cod_dep { get; set; }

        public string shis_cod_dir { get; set; }

        public string shis_tlf_dir { get; set; }

        public string shis_des_dir { get; set; }

        public string shis_cod_dis { get; set; }

        public string shis_des_dis { get; set; }

        public string shis_cod_prov { get; set; }

        public string shis_des_prov { get; set; }

        public string shis_dis_dir { get; set; }

        public string shis_dni { get; set; }



    }

    public class ListadoHistoriaClinicaDto
    {
        public long chis_id { get; set; }

        public string e { get; set; }

        public string prog { get; set; }

        public long codate { get; set; }

        public string clasif { get; set; }

        public string e_tablet { get; set; }

        public string codautorizacion { get; set; }

        public string feclla { get; set; }

        public string hrlla { get; set; }

        public int tiempo { get; set; }

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

        public int cont { get; set; }


        public string perfil { get; set; }


        public string espec { get; set; }

        public string doctor { get; set; }

        public string grupos { get; set; }

        public string empresa { get; set; }

        public string usuario { get; set; }

        public int cod_doc { get; set; }
        public string cm_estado { get; set; }

    }
    public class HistoriaClinicaDto
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


    public class HistoriaClinicaMedioComunicacionMtoMadDto
    {

        public long id_historiaclinica { get; set; }
        public long numero { get; set; }
        public int usuario_creacion { get; set; }
    }

    public class HistoriaClinicaMtoMadDto
    {
        public long id_historiaclinica { get; set; }
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
    public class HistoriaClinicaMtoDto
    {
        public long cod_historia_clinica { get; set; }
        public long cod_seguimiento { get; set; }
        public long id_persona { get; set; }
        public long id_empresa { get; set; }
        public long id_clinica { get; set; }
        public long? id_motivo { get; set; }
        public int id_plan { get; set; }
        public string telefono { get; set; }
        public string anexo { get; set; }
        public string horario_trabajo { get; set; }
        public string cargo { get; set; }
        public string relato { get; set; }
        public string fecha_accidente { get; set; }
        public string hora_accidente { get; set; }
        public string observacion { get; set; }
        public string primera_atencion { get; set; }
        public string metodo_validacion { get; set; }
        public int? hoja_atencion { get; set; }
        public string ubigeo { get; set; }
        public int skill { get; set; }
        public int motivo_skill { get; set; }
        public int centro_clinico { get; set; }
        public int empresa { get; set; }
        public int corredor_seguro { get; set; }
        public int paciente_asegurado { get; set; }
        public string persona_reporta_clinica { get; set; }
        public string persona_reporta_empresa { get; set; }
        public string persona_reporta_seguro { get; set; }
        public string persona_reporta_asegurado { get; set; }
        public int? id_clinica_primera_atencion { get; set; }
        public int estado { get; set; }
        public int? pase_atencion { get; set; }
        public int usuario_creacion { get; set; }
        public int usuario_eliminacion { get; set; }
        //public DateTime DATE_FECHA_CREACION { get; set; }
        //public int usuario_modificacion { get; set; }
        //public DateTime DATE_FECHA_MODIFICACION { get; set; }

        //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
        public int? CPAR_ID_MOTIVO_CALLMEDICO { get; set; }
        public int? CPAR_ID_REFERENCIA_AMBULANCIA { get; set; }
        public int? CCEN_ID { get; set; }
        public int? CECM_ID { get; set; }
        public int? CPAR_ID_SOLICITUD { get; set; }
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

        //TBLMDS_HISTORIA_CLINICA
        public string? SHIS_ESTADO { get; set; }
        public string? SHIS_CM_ESTADO { get; set; }
        public int? NHIS_COD_ESTADO { get; set; }
        public Boolean? FHIS_FLG_CM_NUEVA { get; set; }
        public int? NHIS_CM_ORDEN { get; set; }
        public string? SHIS_REF_DIR { get; set; }
        public string? SHIS_NOM_EMP { get; set; }
        public int? NHIS_EDAD_ATE { get; set; }
        public string? SHIS_CEL_PAC { get; set; }
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
        public string? SHIS_TIPO_SERVICIO { get; set; }
        public int? NHIS_COD_PRIORIDAD_CALLMED { get; set; }
        public int? NHIS_COD_MOTIVO_ATE_CALLMED { get; set; }
        public int? NHIS_CLASIFICACION_PAC { get; set; }
        public string? SHIS_TIPO_DOC_PAGO { get; set; }
        public string? SHIS_DESCRP_ZONA { get; set; }
        public string? SHIS_PERSONAL_CONTACTO { get; set; }
        public string? DHIS_HOR_ATE { get; set; }
        public string? SHIS_COD_EMP { get; set; }
        public string? SHIS_AMB_COD_DIS_ORIGEN { get; set; }
        public string? SHIS_AMB_DES_DIS_ORIGEN { get; set; }
        public string? SHIS_AMB_DIR_ORIGEN { get; set; }
        public string? SHIS_AMB_REF_DIR_ORIGEN { get; set; }
        public string? DHIS_AMB_FECHA_INI { get; set; }
        public string? DHIS_AMB_HORA_INI { get; set; }
        public string? DHIS_AMB_FECHA_FIN { get; set; }
        public string? DHIS_AMB_HORA_FIN { get; set; }
        public string? SHIS_AMB_COD_DIS_DESTINO { get; set; }
        public string? SHIS_AMB_DES_DIS_DESTINO { get; set; }
        public string? SHIS_AMB_DIR_DESTINO { get; set; }
        public string? SHIS_AMB_REF_DIR_DESTINO { get; set; }
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
        public string? FPAC_FLG_CONFLICTIVO_CALLMED { get; set; }
    }

    public class HistoriaClinicaBandejaDto
    {
        public long pk_pg { get; set; }
        public long cod_historia_clinica { get; set; }
        public string? tipo_historia_clinica { get; set; }
        public string estado { get; set; }
        public string fecha_creacion { get; set; }
        public string hora_creacion { get; set; }
        public string? documento_identidad { get; set; }
        public string? numero { get; set; }
        public string? paciente { get; set; }
        public string? fecha_nacimiento { get; set; }
        public string clinica { get; set; }
        public string? empresa { get; set; }
        public string? empresa_ruc { get; set; }
        public string usuario_creacion { get; set; }
        public string motivo { get; set; }
        public string? plan { get; set; }
        public string skill { get; set; }
        public string? procedencia { get; set; }
        public string? departamento { get; set; }
        public string? provincia { get; set; }
        public string? distrito { get; set; }
        public string? hoja_atencion { get; set; }
        public string? medio_validacion { get; set; }
        public string? pase_atencion { get; set; }
        public string? observacion { get; set; }
        public string? persona_reporta { get; set; }
        public string? motivo_de_llamada { get; set; }
    }

    /*INICIO MAD*/
    public class ClienteAseguradoraDto
    {
        public int id_cliente { get; set; }
        public string? nombre { get; set; }

    }
    /*FIN MAD*/




    #region "Estados 0 - 2 - 3"
    public class HistoriaClinicaMadAuditoriaEstadoDto
    {
        public int NUMEROHISTORIA { get; set; }
        public string ESTADO { get; set; }
        public string USUARIO { get; set; }
        public string OBSERVACION { get; set; }
        public string CAMBIO { get; set; }
        public int USUARIO_CREACION { get; set; }
        public int onRespuesta { get; set; }
    }
    public class HistoriaClinicaMadEstadoDto
    {
        public int CHIS_ID { get; set; }
        public int CMED_ID { get; set; }
        public string SHIS_COD_TIPO_DOCTOR { get; set; }
        public DateTime DHIS_HORASGDR_ATE { get; set; }
        public DateTime DHIS_FECASGDR_ATE { get; set; }
        public string SHIS_USUASGDR_ATE { get; set; }
        public int CESP_ID { get; set; }
        public DateTime DHIS_FEC_ATE { get; set; }
        public DateTime DHIS_HOR_ATE { get; set; }
        public string SHIS_TMP_COD_TIT { get; set; }
        public int NHIS_CM_TIEMPO { get; set; }
        public string SHIS_COD_DR_SOLICITADO { get; set; }
        public bool FHIS_FLAG_PROGRAMADA { get; set; }
        public string SHIS_F_SOLDOCT { get; set; }
        public string SHIS_F_PROG { get; set; }
        public int NHIS_MOTIVO_TIPO_PROG { get; set; }
        public int NHIS_CLASIFICACION_NEG_SOPORTE { get; set; }
        public string SHIS_CM_ESTADO { get; set; }
        public int NHIS_COD_ESTADO { get; set; }
        public int NHIS_ORDEN { get; set; }
        public string SHIS_CM_ESP_ANTERIOR { get; set; }
        public string SHIS_CM_COD_DR_ANTERIOR { get; set; }
        public string SHIS_CM_DR_ANTERIOR { get; set; }
        public bool FHIS_FLG_VALIDACION_DIRECTA { get; set; }
    }
    public class HistoriaClinicaMadAsignacionTiempoDoctorDto
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
    public class HistoriaClinicaMadAsignacionEspecialidadDto()
    {
        public int CESP_ID { get; set; }
        public string SESP_NOMBRE { get; set; }
    }
    public class HistoriaClinicaMadAsignacionMedicoDto
    {
        public int CMED_ID { get; set; }
        public string MEDICO { get; set; }
        public string SMED_TIPO_DOCTOR { get; set; }
        public int CESP_ID { get; set; }
        public string SMEP_DESCRIPCION { get; set; }
    }
    public class HistoriaClinicaMadAsignacionEspecialidadMedicoDto
    {
        public int CMED_ID { get; set; }
        public string MEDICO { get; set; }
        public string SMED_TIPO_DOCTOR { get; set; }
    }

    #endregion
    #region "Estados 3 - 5"
    public class HistoriaClinicaAuditoriaEstadoValidacionTiempoDto
    {
        public int NUMEROHISTORIA { get; set; }
        public string ESTADO { get; set; }
        public string USUARIO { get; set; }
        public string OBSERVACION { get; set; }
        public string CAMBIO { get; set; }
        public int USUARIO_CREACION { get; set; }
        public int onRespuesta { get; set; }
    }

    public class UpdateHistoriaClinicaAuditoriaEstadoValidacionTiempoDto
    {
        public int NUMERO_HISTORIA { get; set; }
        public DateTime DHIS_HRLLEDR { get; set; }
        public DateTime DHIS_FECLLEDR { get; set; }
        public bool FHIS_FLG_CM_NUEVA { get; set; }
        public string SHIS_CM_ESTADO { get; set; }
    }

    public class HistoriaClinicaMadValidacionTiempoDto
    {
        public string CM_ESTADO { get; set; }
        public int CLASIFICACION_PAC { get; set; }
        public string MEDICO { get; set; }
        public string TELEFONO_CELULAR { get; set; }
        public string BEEPER { get; set; }
        public string DIRECCION { get; set; }
        public string NRO_LOTE { get; set; }
        public string INTERIOR { get; set; }
        public string URBANIZACION { get; set; }
        public string REFERENCIA { get; set; }
        public string CONDUCTOR { get; set; }

    }

    #endregion
    #region "Estados 5 - 6"
    public class AddHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto
    {
        public int NUMERO_HISTORIA { get; set; }
        public string ESTADO { get; set; }
        public string USUARIO { get; set; }
        public string OBSERVACION { get; set; }
        public string CAMBIO { get; set; }
        public int USUARIO_CREACION { get; set; }
        public int onRespuesta { get; set; }
    }

    public class UpdateHistoriaClinicaAuditoriaEstadoRecepcionMensajeDto
    {
        public int NUMERO_HISTORIA { get; set; }
        public string SHIS_CM_ESTADO { get; set; }
        public int NHIS_CM_ORDEN { get; set; }
    }

    public class HistoriaClinicaMadConfirmarRecepcionMensajeDto
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

    public class HistoriaClinicaMadAuditoriaEstadoFinConsultaDto
    {
        public int NUMERO_HISTORIA { get; set; }
        public string? FECOPLLA_ATE { get; set; }
        public string? HOROPLLA_ATE { get; set; }
        public string FECDIA_ATE { get; set; }
        public string HORDIA_ATE { get; set; }
        public string USUDIA_ATE { get; set; }
        public string ACCIDE { get; set; }
        public bool ATENCION_REFERENCIAL { get; set; }
        public int onRespuesta { get; set; }
    }

    public class HistoriaClinicaEstadoFinConsultaDto
    {
        public int CHIS_ID { get; set; }
        public int CHCP_COD_ASO { get; set; }
        public int CPAC_ID { get; set; }
        public int CESP_ID { get; set; }
        public int CUBI_ID { get; set; }
        public int CTDO_ID { get; set; }
        public int CEMP_ID { get; set; }
        public bool FHCP_EXP { get; set; }
        public bool FHCP_SB_ATE { get; set; }
        public bool FHCP_EXI_ATE { get; set; }
        public float NHCP_TAR_ATE { get; set; }
        public float NHCP_TAR_ATEOPE { get; set; }
        public string SHCP_OBS_ATE { get; set; }
        public string SHCP_COD_TIPO_DOCTOR { get; set; }
        public bool FHCP_FLGVNR { get; set; }
        public string SHCP_ACCIDE { get; set; }
        public string SHCP_FOR_ATE { get; set; }
        public string SHCP_SIN_ATE { get; set; }
        public string SHCP_CODTAR_ATE { get; set; }
        public string SHCP_NTAR_ATE { get; set; }
        public string DHCP_FVENC_ATE { get; set; }
        public string DHCP_FECLLA { get; set; }
        public string DHCP_HORLLA { get; set; }
        public string DHCP_FECFIN { get; set; }
        public string DHCP_HORFIN { get; set; }
        public bool FHCP_YO { get; set; }
        public string SHCP_CANC_ATE { get; set; }
        public string SHCP_POLIZA_ASEGURADO { get; set; }
        public string SHCP_COD_AUT_PRESTACION { get; set; }
        public string SHCP_COD_SOLGEN { get; set; }
        public string SHCP_CODAASEG_EPS { get; set; }
        public int NHCP_COASEGURO { get; set; }
        public string SHCP_COD_DENOMINACION { get; set; }
        public string SHCP_F_SERV { get; set; }
        public string SHCP_CM_ASEG_PRODUCTO { get; set; }
        public string SHCP_TIPO_SERVICIO { get; set; }
        public int NHCP_USUARIO_CREACION { get; set; }
        public string DHCP_FECHA_CREACION { get; set; }
        public int NHCP_USUARIO_MODIFICACION { get; set; }
        public string DHCP_FECHA_MODIFICACION { get; set; }
        public int onRespuesta { get; set; }
    }

    public class HistoriaClinicaMadConfirmarLlegadaMedicoDto
    {
        public int cod_historia_clinica { get; set; }
        public string cm_estado { get; set; }
        public int clasificacion_pac { get; set; }
        public string paciente { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public string medico { get; set; }
    }

    public class HistoriaClinicaMadEstado7Dto
    {
        public int cod_conductor { get; set; }
        public string conductor { get; set; }
        public string anulada { get; set; }
        public string fecha_inicio_asignado { get; set; }
        public string hora_inicio_asignado { get; set; }
        public string fecha_fin_asignado { get; set; }
        public string hora_fin_asignado { get; set; }
    }

    public class HistoriaClinicaMadFinConsultaMedicaDto
    {
        public string Hora { get; set; }
        public int cod_historia_clinica { get; set; }
        public string cm_estado { get; set; }
        public int estado { get; set; }
        public int clasificacion_pac { get; set; }
        public string fecoplla_ate { get; set; }
        public string fecha_atencion { get; set; }
        public int contador_periodo { get; set; }
        public string paciente { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public string medico { get; set; }
        public string conductor { get; set; }
    }

}