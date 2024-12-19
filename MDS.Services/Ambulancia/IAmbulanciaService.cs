using MDS.Dto;
using MDS.Dto.Resources;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Ambulancia
{
    public interface IAmbulanciaService : IService
    {
        Task<ServiceResponse> GetAmbulancia(AmbulanciaResource dto);

        //By Henrry Torres
        Task<ServiceResponse> GetTipoServicioAmbulancia(string tipoServicio);

        //By Henrry Torres
        Task<ServiceResponse> GetPrioridadAmbulancia(string tipoServicio);

        //By Henrry Torres
        Task<ServiceResponse> GetTipoAmbulancia();

        //By Henrry Torres
        Task<ServiceResponse> GetTipoTrasladoAmbulancia(int tipoAmbulancia);

        //By Henrry Torres
        Task<ServiceResponse> GetTipoPoliza(int codigoCliente);

        //By Henrry Torres
        Task<ServiceResponse> GetTipoPolizaByCodigo(int codigo);

        //By Henrry Torres
        Task<ServiceResponse> GetMotivoAtencionAmbulancia(string busqueda);

        //By Henrry Torres
        Task<ServiceResponse> GetProductoAmbulancia(string busqueda, int codCliente);

        //By Henrry Torres
        Task<ServiceResponse> GetProveedorAmbulancia();

        //By Henrry Torres
        Task<ServiceResponse> GetTipoComprobante();
    }
}