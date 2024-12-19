using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.Pais.Implementation
{
    public class PaisService : IPaisService
    {
        private readonly IUnitOfWork _uow;

        public PaisService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetPais()
        {
            try
            {
                List<DbContext.Entities.Pais> paises = new List<DbContext.Entities.Pais>();

                paises = await _uow.ExecuteStoredProcAll<DbContext.Entities.Pais>("SPRMDS_LIST_PAIS");

                List<PaisDto> listPais = new List<PaisDto>();

                listPais = paises.Select(s => new PaisDto { id_pais = s.CPAI_ID, nombre = s.SPAI_NOMBRE, prefijo = s.SPAI_PREFIJO, estado = s.FPAI_ESTADO }).ToList();

                if (!paises.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listPais);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}