using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.MedicoParticular
{
    public interface IMedicoParticularService : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetMedicoParticulares();

        //By William Vilca
        Task<ServiceResponse> GetMedicoParticular(long medicoId);

        //By William Vilca
        Task<ServiceResponse> AddMedicoParticular(MantenimientoMedicoParticularDto dto);
    }
}
