using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Persona
{
    public interface IPersonaService : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetPersonas();

        //By William Vilca
        Task<ServiceResponse> GetPersona(long personaId);

        //By William Vilca
        Task<ServiceResponse> GetPersona_x_Dni(string vDni);

        //By William Vilca
        Task<ServiceResponse> GetPersonaCodigo();
        //By Henrry Torres
        Task<ServiceResponse> AddPersonaSctr(MantenimientoPersonaDto dto);
        
        //By William Vilca
        Task<ServiceResponse> AddPersonaMad(MantenimientoPersonaMadDto dto);

        //By William Vilca
        Task<ServiceResponse> ActualizarPersonaMad(MantenimientoPersonaMadActualizarDto dto);

    }
}
