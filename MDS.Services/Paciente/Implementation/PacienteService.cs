using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using System;


namespace MDS.Services.Paciente.Implementation
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _uow;

        public PacienteService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetPacientes()
        {
            try
            {
                List<DbContext.Entities.Paciente> pacientes = new List<DbContext.Entities.Paciente>();

                pacientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.Paciente>("SPRMDS_LIST_PACIENTE");

                List<PacienteDto> listPaciente = new List<PacienteDto>();

                listPaciente = pacientes.Select(p => new PacienteDto { id_paciente = p.CPAC_ID, id_persona = p.CPER_ID, estado = p.FPAC_ESTADO }).ToList();

                if (!pacientes.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listPaciente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetPaciente_By_Dni(string vBusqueda, string vValor)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCriterioBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vBusqueda },
                    new SqlParameter("@isValor", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vValor },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output},
                };

                List<DbContext.Entities.PacienteDni> pacientes = new List<DbContext.Entities.PacienteDni>();

                pacientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.PacienteDni>("SPRMDS_LIST_PACIENTE_BY_DNI", parameters);

                List<PacienteDniDto> listPacientes = new List<PacienteDniDto>();

                listPacientes = pacientes.Select(p => new PacienteDniDto 
                {
                    codigo = p.CODIGO,
                    dni = p.DNI,
                    paciente = p.PACIENTE,
                }).ToList();

                PacienteDniDto dto = new PacienteDniDto();

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_LIST_PACIENTE_BY_DNI", parameters);

                dto.id_paciente = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith200(listPacientes);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetPacientesFiltro(string busqueda, string condicion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                    new SqlParameter("@isCondicion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = condicion },
                };

                List<DbContext.Entities.PacienteFiltro> pacientes = new List<DbContext.Entities.PacienteFiltro>();

                pacientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.PacienteFiltro>("SPRMDS_LIST_PACIENTE_FILTRO", parameters);

                List<PacienteDto> listPacientes = new List<PacienteDto>();

                listPacientes = pacientes.Select(s => new PacienteDto { id_paciente = s.CPAC_ID, numero_documento = s.SPER_NUMERO_DOCUMENTO, tipo_documento = s.STDO_DESCRIPCION, id_tipo_documento = s.CTDO_ID, nombres = s.SPER_NOMBRES, apellido_paterno = s.SPER_APELLIDO_PATERNO, apellido_materno = s.SPER_APELLIDO_MATERNO, sexo = s.NPER_GENERO, fecha_nacimiento = s.DPER_FECHA_NACIMIENTO, movil = s.SPER_TELEFONO_CELULAR, telefono = s.SPER_TELEFONO_CASA, correo_electronico = s.SPER_EMAIL, edad = s.NPER_EDAD }).ToList();

                /*if (!listClinicas.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listPacientes);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetPaciente(string pacienteId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = pacienteId },
                };


                List<DbContext.Entities.Paciente> pacientes = new List<DbContext.Entities.Paciente>();

                pacientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Paciente>("SPRMDS_LIST_PACIENTE_BY_PARAM", parameters);

                List<PacienteDto> listPaciente = new List<PacienteDto>();

                listPaciente = pacientes.Select(p => new PacienteDto { id_paciente = p.CPAC_ID, id_persona = p.CPER_ID, estado = p.FPAC_ESTADO }).ToList();

                if (!listPaciente.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listPaciente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddPaciente(MantenimientoPacienteDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CPER_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@DPAC_FINC", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.finc },
                    new SqlParameter("@SPAC_COD_PAR", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_par },
                    new SqlParameter("@DPAC_FCRE", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fcre },
                    new SqlParameter("@FPAC_BOL_ACT", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.bol_act },
                    new SqlParameter("@SPAC_OBS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.obs },
                    new SqlParameter("@FPAC_FLG_CORREO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_correo },
                    new SqlParameter("@SPAC_USUCRE_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usucre_email },
                    new SqlParameter("@SPAC_USUMODIF_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usumodif_email },

                    new SqlParameter("@SPAC_FLAG_FICHA", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.flag_ficha },
                    new SqlParameter("@FPAC_FLAG_BLOQ", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flag_bloq },
                    new SqlParameter("@FPAC_FLAG_VIP", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flag_vip },
                    new SqlParameter("@NPAC_CLASIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.clasificacion },
                    new SqlParameter("@SPAC_VIP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.vip },
                    new SqlParameter("@NPAC_COD_SUBCLASIF", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.cod_subclasif },
                    new SqlParameter("@DPAC_FECHA_VIGENCIA", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_vigencia },
                    new SqlParameter("@FPAC_FLG_REGISTRAR_PAC_TABLET", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_registrar_pac_tablet },
                    new SqlParameter("@FPAC_CLAVE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.clave },
                    new SqlParameter("@SPAC_TIPO_CLAVE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.tipo_clave },

                    new SqlParameter("@SPAC_OBS_CLAVE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.obs_clave },
                    new SqlParameter("@FPAC_CONSENT_INFORMADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.consent_informado },
                    new SqlParameter("@FPAC_CONSENT_RECIBIR_INFO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.consent_recibir_info },
                    new SqlParameter("@FPAC_CONSENT_FIRMA_CONST", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.consent_firma_const },
                    new SqlParameter("@FPAC_CONSMT_RI", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.consmt_ri },
                    new SqlParameter("@FPAC_FLG_CONFLICTIVO_CALLMED", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_conflictivo_callmed },
                    new SqlParameter("@FPAC_FLG_ACTIVO_FARMACIA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_activo_farmacia },
                    new SqlParameter("@NPAC_NORDEN_OBS", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.norden_obs },
                    new SqlParameter("@SPAC_GRUPO_CRONICOS", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.grupo_cronicos },
                    new SqlParameter("@FPAC_FLG_PAQUETE_SALUD", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_paquete_salud },


                    new SqlParameter("@FPAC_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@NPAC_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@DPAC_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@NPAC_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DPAC_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_PACIENTE", parameters);

                dto.Id_paciente = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

    }
}
