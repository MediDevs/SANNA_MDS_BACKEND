using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Motivo.Implementation
{
    public class MotivoService : IMotivoService
    {
        private readonly IUnitOfWork _uow;

        public MotivoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetMotivos()
        {
            try
            {
                List<DbContext.Entities.Motivo> Motivos = new List<DbContext.Entities.Motivo>();

                Motivos = await _uow.ExecuteStoredProcAll<DbContext.Entities.Motivo>("SPRMDS_LIST_MOTIVO");

                List<MotivoDto> listMotivos = new List<MotivoDto>();

                listMotivos = Motivos.Select(s => new MotivoDto { id_motivo = s.CMOT_ID, descripcion = s.SMOT_DESCRIPCION, tipo_atencion = s.NMOT_TIPO_ATENCION, tipo_pase = s.NMOT_TIPO_PASE, skill = s.FMOT_SKILL }).ToList();

                if (!Motivos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listMotivos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetMotivosByTipoAndPase(int NMOT_TIPO_ATENCION, int NMOT_TIPO_PASE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoTipoAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = NMOT_TIPO_ATENCION },
                    new SqlParameter("@inCodigoTipoPase", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = NMOT_TIPO_PASE },
                };

                List<DbContext.Entities.MotivoCombo> motivos = new List<DbContext.Entities.MotivoCombo>();

                motivos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.MotivoCombo>("SPRMDS_LIST_MOTIVO_BY_TIPO_AND_PASE", parameters);

                List<MotivoComboDto> listMotivos = new List<MotivoComboDto>();

                listMotivos = motivos.Select(s => new MotivoComboDto { id_motivo = s.CMOT_ID, descripcion = s.SMOT_DESCRIPCION }).ToList();

                if (!listMotivos.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listMotivos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}