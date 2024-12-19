using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.PaginaAccion.Implementation
{
    public class PaginaAccionService : IPaginaAccionService
    {
        private readonly IUnitOfWork _uow;

        public PaginaAccionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetPaginaAccion()
        {
            try
            {
                List<DbContext.Entities.PaginaAccion> lstPaginaAccion = new List<DbContext.Entities.PaginaAccion>();

                lstPaginaAccion = await _uow.ExecuteStoredProcAll<DbContext.Entities.PaginaAccion>("SPRMDS_LIST_PAGINA_ACCION");

                List<PaginaAccionDto> lstPaginaAccionDto = new List<PaginaAccionDto>();

                if (!lstPaginaAccion.Any())
                    return ServiceResponse.ReturnResultWith204();

                lstPaginaAccionDto = lstPaginaAccion.Select
                (
                    s => new PaginaAccionDto 
                    { 
                        codigoPaginaAccion = s.CPAC_ID, 
                        nombreSeccion = s.SSEC_NOMBRE, 
                        codigoPagina = s.CPAG_ID, 
                        nombrePaginaMenu = s.SPAG_NOMBRE_MENU,
                        nombreIcono = s.SPAG_ICONO,
                        nombreSubSeccion = s.SPAG_NOMBRE_SUB_SECCION,
                        nombreIconoSubSeccion = s.SPAG_ICONO_SUB_SECCION,
                        nombrePagina = s.SPAG_NOMBRE, 
                        urlPagina = s.SPAG_URL,
                        codigoAccion = s.CACC_ID, 
                        nombreAccion = s.SACC_NOMBRE 
                    }
                ).ToList();

                return ServiceResponse.ReturnResultWith200(lstPaginaAccionDto);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
    }
}
