using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Periodo
{
    public interface IPeriodoService : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetPeriodos();

        //By William Vilca
        Task<ServiceResponse> GetPeriodo(long PeriodoId);

        //By William Vilca
        Task<ServiceResponse> AddPeriodo(PeriodoDto dto);

    }
}
