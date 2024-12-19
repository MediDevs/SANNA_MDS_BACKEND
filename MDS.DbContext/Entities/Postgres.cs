using System.ComponentModel.DataAnnotations;

namespace MDS.DbContext.Entities
{
    public class ModelBase
    {
        public long PrimaryKey_SQL { get; set; }
        public string? PrimaryKey_PG { get; set; }
        public string? Codigo_Usuario_PG { get; set; }
    }

    //SCTR
    public class h_sctr_mae_empresa : ModelBase
    {
        public string nombre_empresa { get; set; }
        public string ruc_empresa { get; set; }
        public Boolean flg_activo { get; set; }
    }

    public class mae_sctr_clinica : ModelBase
    {
        public string? cod_ipress { get; set; }
        public string descripcion_ipress { get; set; }
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public Boolean flg_afiliado { get; set; }
        public Boolean flg_plan_huerfano_ilimitado { get; set; }
        public Boolean activo { get; set; }
    }

    public class h_sctr_atencion : ModelBase
    {
        public long? cod_atencion { get; set; } = null;
        public string? cod_paciente { get; set; } = "";
        public string? cod_cliente { get; set; } = "";
        public string? cod_ipress { get; set; } = "";
        public string? ipress_persona_reporta { get; set; } = "";
        public string? horario_trabajo { get; set; } = "";
        public string? puesto_cargo { get; set; } = "";
        public string? relato { get; set; } = "";
        public string? fecha_accidente { get; set; } = "";
        public string? hora_accidente { get; set; } = "";
        public int? id_tipo_atencion { get; set; } = null;
        public int? tipo_pase_atencion { get; set; } = null;
        public long? id_motivo { get; set; } = null;
        public string? observacion { get; set; } = "";
        public string? ipress_primera_ate { get; set; } = "";
        public string? fecha_creacion { get; set; } = "";
        public string? hora_creacion { get; set; } = "";
        public string? ubigeo_accidente { get; set; } = "";
        public string? metodo_validacion { get; set; } = "";
        public int? id_plan { get; set; } = null;
        public Boolean? hoja_atencion { get; set; } = null;
        public int? id_skill { get; set; } = null;
        public int? id_motivo_skill { get; set; } = null;
        public string? estado { get; set; } = null;

        //OTRO MOTIVO SCTR
        public string? persona_reporta_empresa { get; set; } = "";
        public string? persona_reporta_corredor_seguro { get; set; } = "";
        public string? persona_reporta_asegurado { get; set; } = "";
        public Boolean? flg_centro_clinico { get; set; } = null;
        public Boolean? flg_empresa { get; set; } = null;
        public Boolean? flg_corredor_seguro { get; set; } = null;
        public Boolean? flg_paciente_asegurado { get; set; } = null;
    }

    public class m_segatenciones : ModelBase
    {
        public long cod_ate { get; set; }
        public string? cod_ped { get; set; } = "";
        public string? cod_caso { get; set; } = "";
        public string? id_tip_serv { get; set; } = "";
        public string obs_ser { get; set; }
        public string? cod_snc { get; set; } = "";
        public string des_ser { get; set; } = "";
    }

    public class m_pacientesdrmas : ModelBase
    {
        public string nom_pac { get; set; }
        public string appat_pac { get; set; }
        public string apmat_pac { get; set; }
        public bool sex_pac { get; set; }
        public DateTime fnac_pac { get; set; }
        public long id_doc_id { get; set; }
        public string num_doc_id { get; set; }
        public string cel_pac { get; set; }
    }
}