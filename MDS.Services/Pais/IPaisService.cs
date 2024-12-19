using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Pais
{
    public interface IPaisService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetPais();
    }
}

