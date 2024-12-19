using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.CentroMedicoDerivado
{
    public interface IEspecialidadCallMedicoService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetEspecialidadCallMedicoByCentroMedico(int id_centro_medico);
    }
}

