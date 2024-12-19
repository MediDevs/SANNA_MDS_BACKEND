using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Cliente
{
    public interface IClienteService : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetClientes();

        //By William Vilca
        Task<ServiceResponse> GetConsultaCliente(string vCondicion,string vBusqueda);

        //By William Vilca
        Task<ServiceResponse> AddCliente(MantenimientoClienteDto dto);

        //By Henrry Torres
        Task<ServiceResponse> GetClienteByRuc(string ruc);

        //By Henrry Torres
        Task<ServiceResponse> GetClientesAmbulancia();

        //By Henrry Torres
        Task<ServiceResponse> AddClienteSctr(MantenimientoClienteDto dto);

        //By Henrry Torres
        Task<ServiceResponse> GetClientesSiteds();
    }
}

