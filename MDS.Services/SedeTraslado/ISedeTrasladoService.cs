using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.SedeTraslado
{
    public interface ISedeTrasladoService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetSedeTraslado();

        //By Henrry Torres
        Task<ServiceResponse> GetSedesTrasladoFiltro(string busqueda, string condicion);

        //By Henrry Torres
        Task<ServiceResponse> AddSedeTraslado(SedeTrasladoMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> UpdateSedeTraslado(SedeTrasladoMtoDto dto);
    }
}