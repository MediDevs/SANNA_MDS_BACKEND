using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.DobleFactor
{
    public interface IDobleFactorService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GenerarDobleFactor(DobleFactorDto dto);

        //By Henrry Torres
        Task<ServiceResponse> ValidateDobleFactor(DobleFactorDto dto);
    }
}
