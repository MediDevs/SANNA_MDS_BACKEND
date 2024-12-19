using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Blog
{
    public interface IParametroService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetParametro(int CPAR_GRUPO_ID);
    }
}

