using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.CentroMedicoDerivado
{
    public interface ICentroMedicoDerivadoService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetCentroMedicoDerivadoByTipoReferencia(int CPAR_GRUPO_ID);
    }
}

