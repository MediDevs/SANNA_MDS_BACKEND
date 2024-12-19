using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Alerta
{
    public interface IAlertaService : IService
    {
        Task<ServiceResponse> GetAlertas();
    }
}
