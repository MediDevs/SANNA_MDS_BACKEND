using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Clinica
{
    public interface IClinicaService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetClinicas();

        //By Henrry Torres
        Task<ServiceResponse> GetClinicasFiltro(string busqueda, string condicion);

        //By William Vilca
        Task<ServiceResponse> GetHistoriaClinicaFiltro_x_Dni(string busqueda, string condicion);

        //By Henrry Torres
        Task<ServiceResponse> AddClinica(ClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> UpdateClinica(ClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteClinica(ClinicaMtoDto dto);
    }
}

