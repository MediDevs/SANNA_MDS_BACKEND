using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.MedicoParticular.Implementation
{
    public class MedicoParticularService : IMedicoParticularService
    {

        private readonly IUnitOfWork _uow;

        public MedicoParticularService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetMedicoParticulares()
        {
            try
            {
                List<DbContext.Entities.MedicoParticular> medicos = new List<DbContext.Entities.MedicoParticular>();

                medicos = await _uow.ExecuteStoredProcAll<DbContext.Entities.MedicoParticular>("SPRMDS_LIST_MEDICO_PARTICULAR");

                List<MedicoParticularDto> listMedico = new List<MedicoParticularDto>();

                listMedico = medicos.Select(m => new MedicoParticularDto { id_medicoparticular = m.CMED_IDMEDICOPARTICULAR, descripcion = m.SMED_DESCRIPCION, email = m.SMED_EMAIL, estado = m.FMED_ESTADO }).ToList();

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
        public async Task<ServiceResponse> GetMedicoParticular(long medicoId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = medicoId },
                };


                List<DbContext.Entities.MedicoParticular> medicos = new List<DbContext.Entities.MedicoParticular>();

                medicos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.MedicoParticular>("SPRMDS_LIST_MEDICO_PARTICULAR_BY_PARAM", parameters);

                List<MedicoParticularDto> listMedico = new List<MedicoParticularDto>();

                listMedico = medicos.Select(m => new MedicoParticularDto { id_medicoparticular = m.CMED_IDMEDICOPARTICULAR, descripcion = m.SMED_DESCRIPCION, email = m.SMED_EMAIL, estado = m.FMED_ESTADO }).ToList();

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
        public async Task<ServiceResponse> AddMedicoParticular(MantenimientoMedicoParticularDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SMED_DESCRIPCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.descripcion },
                    new SqlParameter("@SMED_TELEFONO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefono },
                    new SqlParameter("@SMED_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email },
                    new SqlParameter("@SMED_EMAIL_CULMINACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email_culminacion },
                    new SqlParameter("@FMED_ENVIAR_EMAIL", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.enviar_email },
                    new SqlParameter("@FMED_FLG_PROVEEDOR_DRMAS", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_proveedor_drmas},
                    new SqlParameter("@SMED_NOM_USU", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nom_usu},
                    new SqlParameter("@FMED_FLG_VISIBLE_PROV_SEG_COVID", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.flg_visible_prov_seg_covid},
                    new SqlParameter("@FMED_ESTADO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado},
                    new SqlParameter("@NMED_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@DMED_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@NMED_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DMED_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_MEDICO_PARTICULAR", parameters);

                dto.id_medicoparticular = Convert.ToInt64(response);

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
