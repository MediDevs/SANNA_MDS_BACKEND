using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Direccion
{
    public interface IDireccionService : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetListaDirecciones(long vIdPersona);

        //By Henrry Torres
        Task<ServiceResponse> GetDirecciones(long CPER_ID);

        //By Henrry Torres
        Task<ServiceResponse> GetDireccion(long CPER_ID, long CDIR_ID);

        //By Henrry Torres
        Task<ServiceResponse> AddDireccion(DireccionDto dto);

        //By Henrry Torres
        Task<ServiceResponse> UpdateDireccion(DireccionDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteDireccion(DireccionDto dto);
    }
}