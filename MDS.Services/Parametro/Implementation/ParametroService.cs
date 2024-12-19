using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.Blog.Implementation
{
    public class ParametroService : IParametroService
    {
        private readonly IUnitOfWork _uow;

        public ParametroService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetParametro(int CPAR_GRUPO_ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoParametro", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = CPAR_GRUPO_ID },
                };

                List<DbContext.Entities.Parametro> ubigeos = new List<DbContext.Entities.Parametro>();

                ubigeos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Parametro>("SPRMDS_LIST_PARAMETRO", parameters);

                List<ParametroDto> listParametro = new List<ParametroDto>();

                listParametro = ubigeos.Select(s => new ParametroDto { id = s.CPAR_ID, descripcion = s.SPAR_NOMBRE }).ToList();

                if (!listParametro.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listParametro);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}