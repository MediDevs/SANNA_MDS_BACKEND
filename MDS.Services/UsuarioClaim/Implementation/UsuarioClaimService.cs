using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.UsuarioClaim.Implementation
{
    public class UsuarioClaimService : IUsuarioClaimService
    {
        private readonly IUnitOfWork _uow;

        public UsuarioClaimService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetUsuarioClaim(int codigoUsuario)
        {
            try
            {
                List<DbContext.Entities.UsuarioClaim> lstUsuarioClaim = new List<DbContext.Entities.UsuarioClaim>();

                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoUsuario },
                };

                lstUsuarioClaim = await _uow.ExecuteStoredProcByParam<DbContext.Entities.UsuarioClaim>("SPRMDS_GET_CLAIM_BY_USUARIO", parameters);

                List<UsuarioClaimDto> lstUsuarioClaimDto = new List<UsuarioClaimDto>();

                if (!lstUsuarioClaim.Any())
                    return ServiceResponse.ReturnResultWith204();

                lstUsuarioClaimDto = lstUsuarioClaim.Select(s => new UsuarioClaimDto { codigoUsuarioClaim = s.CUCL_ID, codigoAccion = s.CACC_ID, codigoPagina = s.CPAG_ID, codigoUsuario = s.CUSR_ID, tipoClaim = s.SUCL_TIPO_CLAIM, valorClaim = s.SUCL_VALOR_CLAIM }).ToList();

                return ServiceResponse.ReturnResultWith200(lstUsuarioClaimDto);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
    }
}
