using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MDS.Services.ServicioNegocio
{
    public interface IServicioNegocio : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetServicioNegocios();

        //By William Vilca
        Task<ServiceResponse> GetServicioNegocio(long servicioId);

        //By William Vilca
        Task<ServiceResponse> AddServicioNegocio(MantenimientoServicioNegocioDto dto);

    }
}
