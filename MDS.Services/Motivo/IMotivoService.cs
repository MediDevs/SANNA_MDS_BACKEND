using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Motivo
{
    public interface IMotivoService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetMotivos();

        //By Henrry Torres
        Task<ServiceResponse> GetMotivosByTipoAndPase(int NMOT_TIPO_ATENCION, int NMOT_TIPO_PASE);
    }
}

