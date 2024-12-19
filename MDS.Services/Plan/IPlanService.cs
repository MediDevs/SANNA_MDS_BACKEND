using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Plan
{
    public interface IPlanService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetPlanes();
    }
}

