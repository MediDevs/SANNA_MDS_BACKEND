using MDS.DbContext.Entities;
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

namespace MDS.Services.UsuarioRol.Implementation
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly IUnitOfWork _uow;

        public UsuarioRolService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetUsuarioRol(UsuarioDto dto)
        {
            try
            {
                List<DbContext.Entities.UsuarioRol> roles = new List<DbContext.Entities.UsuarioRol>();

                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.codigoUsuario },
                };

                roles = await _uow.ExecuteStoredProcByParam<DbContext.Entities.UsuarioRol>("SPRMDS_GET_ROL_BY_USUARIO", parameters);

                List<UsuarioRolDto> listUsuarioRol = new List<UsuarioRolDto>();

                listUsuarioRol = roles.Select(s => new UsuarioRolDto { codigoUsuario = s.CUSR_ID, codigoRol = s.CROL_ID }).ToList();

                if (!listUsuarioRol.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listUsuarioRol);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
    }
}
