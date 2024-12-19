using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Seguimiento
{
    public interface ISeguimientoService : IService
    {

        //By Henrry Torres
        Task<ServiceResponse> GetSeguimientoByHistoriaClinica(string codHistoriaClinica);

        //By Henrry Torres
        Task<ServiceResponse> AddSeguimientoSctr(SeguimientoDto dto);
    }
}

