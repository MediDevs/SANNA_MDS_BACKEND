using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.Plan.Implementation
{
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork _uow;

        public PlanService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetPlanes()
        {
            try
            {
                List<DbContext.Entities.Plan> planes = new List<DbContext.Entities.Plan>();

                planes = await _uow.ExecuteStoredProcAll<DbContext.Entities.Plan>("SPRMDS_LIST_PLAN");

                List<PlanDto> listPlanes = new List<PlanDto>();

                listPlanes = planes.Select(s => new PlanDto { id_plan = s.CPLA_ID, nombre = s.SPLA_NOMBRE, estado = s.FPLA_ESTADO }).ToList();

                if (!planes.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listPlanes);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}