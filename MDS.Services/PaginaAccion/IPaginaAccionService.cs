using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.PaginaAccion
{
    public interface IPaginaAccionService : IService
    {
        Task<ServiceResponse> GetPaginaAccion();
    }
}
