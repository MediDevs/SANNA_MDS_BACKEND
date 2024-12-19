using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using System;

namespace MDS.Services.Medico.Implementation
{
    public class MedicoService : IMedicoService
    {

        private readonly IUnitOfWork _uow;

        public MedicoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetMedicos()
        {
            try
            {
                List<DbContext.Entities.Medico> medicos = new List<DbContext.Entities.Medico>();

                medicos = await _uow.ExecuteStoredProcAll<DbContext.Entities.Medico>("SPRMDS_LIST_MEDICOS");

                List<MedicoDto> listMedico = new List<MedicoDto>();

                listMedico = medicos.Select(m => new MedicoDto { id_medico = m.CMED_ID, id_persona = m.CPER_ID, id_especialidad = m.CESP_IDESPECIALIDAD, estado = m.FMED_ESTADO }).ToList();

                if (!medicos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listMedico);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetMedico(long medicoId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = medicoId },
                };


                List<DbContext.Entities.Medico> medicos = new List<DbContext.Entities.Medico>();

                medicos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Medico>("SPRMDS_LIST_MEDICO_BY_PARAM", parameters);

                List<MedicoDto> listMedico = new List<MedicoDto>();

                listMedico = medicos.Select(m => new MedicoDto { id_medico = m.CMED_ID, id_persona = m.CPER_ID, id_especialidad = m.CESP_IDESPECIALIDAD, estado = m.FMED_ESTADO }).ToList();

                if (!medicos.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listMedico);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddMedico(MantenimientoMedicoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CPER_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@CSER_IDSERVICIO_NEGOCIO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_servicionegocio },
                    new SqlParameter("@CPAR_IDMEDICO_PARTICULAR", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_medicoparticular },
                    new SqlParameter("@CESP_IDESPECIALIDAD", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_especialiadad },
                    new SqlParameter("@CBAN_IDBANCO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_banco },
                    new SqlParameter("@SMED_BEEPER", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.beeper },
                    new SqlParameter("@SMED_ZONA", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.zona },
                    new SqlParameter("@FMED_YO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.yo },
                    new SqlParameter("@SMED_COD_USE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cod_use },
                    new SqlParameter("@SMED_FACTURA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.factura },

                    new SqlParameter("@NMED_PAGO", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.pago },
                    new SqlParameter("@SMED_CMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cmp },
                    new SqlParameter("@NMED_TURNO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.turno },
                    new SqlParameter("@NMED_PAGO_NOCHE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.pago_noche },
                    new SqlParameter("@DMED_INICIO_GUARDIA_NOCHE", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.inicio_guardia_noche },
                    new SqlParameter("@DMED_FIN_GUARDIA_NOCHE", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fin_guardia_noche },
                    new SqlParameter("@FMED_MENSAJE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.mensaje },
                    new SqlParameter("@FMED_MAXISALUD", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.maxisalud },
                    new SqlParameter("@SMED_NUMERO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numero },
                    new SqlParameter("@SMED_LOGIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.login },

                    new SqlParameter("@SMED_RUC", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ruc },
                    new SqlParameter("@SMED_CUENTA_BANCARIA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cuenta_bancaria },
                    new SqlParameter("@FMED_SAP_GLF_REGISTRADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.sap_glf_registrado },
                    new SqlParameter("@NMED_ID_DOC_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_doc_id },
                    new SqlParameter("@FMED_PAGO_HHMM", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.pago_hhmm },
                    new SqlParameter("@FMED_REGISTRADO_HHMM", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.registrado_hhmm },
                    new SqlParameter("@FMED_ENCARGADO_EKG", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.encargado_ekg },
                    new SqlParameter("@FMED_LECTOR_EKG", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.lector_ekg},
                    new SqlParameter("@FMED_DRONLINE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.dronline },
                    new SqlParameter("@FMED_MELCHORITA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.melchorita },

                    new SqlParameter("@NMED_LAST_LOGIN", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.login },
                    new SqlParameter("@FMED_ENVIO_DISPONIBILIDAD", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.envio_disponibilidad },
                    new SqlParameter("@FMED_TELECONSULTA_COVID", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.teleconsulta_covid },
                    new SqlParameter("@FMED_TELEMEDICINA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.telemedicina },
                    new SqlParameter("@FMED_ALICORP", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.alicorp },
                    new SqlParameter("@SMED_CODUCTOR_ASOCIADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.conductor_asociado },
                    new SqlParameter("@FMED_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@NMED_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@DMED_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@NMED_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DMED_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion },

                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_MEDICO", parameters);

                dto.id_medico = Convert.ToInt64(response);

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
