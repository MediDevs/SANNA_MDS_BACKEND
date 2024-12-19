using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.TipoDocumento
{
    public interface ITipoDocumentoService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetTipoDocumentos();

        //By Henrry Torres
        Task<ServiceResponse> GetTipoDocumentosSusalud();
    }
}

