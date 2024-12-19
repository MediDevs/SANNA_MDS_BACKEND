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

namespace MDS.Services.RolClaim.Implementation
{
    public class RolClaimService : IRolClaimService
    {
        private readonly IUnitOfWork _uow;

        public RolClaimService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetRolClaim(int codigoRol)
        {
            try
            {
                List<DbContext.Entities.RolClaim> lstRolClaim = new List<DbContext.Entities.RolClaim>();

                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoRol", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = codigoRol },
                };

                lstRolClaim = await _uow.ExecuteStoredProcByParam<DbContext.Entities.RolClaim>("SPRMDS_GET_CLAIM_BY_ROL", parameters);

                List<RolClaimDto> lstRolClaimDto= new List<RolClaimDto>();

                if (!lstRolClaim.Any())
                    return ServiceResponse.ReturnResultWith204();

                lstRolClaimDto = lstRolClaim.Select(s => new RolClaimDto { codigoRolClaim = s.CRCL_ID, codigoAccion = s.CACC_ID, codigoPagina = s.CPAG_ID, codigoRol = s.CROL_ID, tipoClaim = s.SRCL_TIPO_CLAIM, valorClaim = s.SRCL_VALOR_CLAIM }).ToList();

                return ServiceResponse.ReturnResultWith200(lstRolClaimDto);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
    }
}
