using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.DetalleServicioNegocio
{
    public interface IDetalleServicioNegocio : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetDetalleServicioNegocios();

        //By William Vilca
        Task<ServiceResponse> GetDetalleServicioNegocio(long detservicioId);

        //By William Vilca
        Task<ServiceResponse> AddDetalleServicioNegocio(MantenimientoDetalleServicioNegocioDto dto);
    }
}
