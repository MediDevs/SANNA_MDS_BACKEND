using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDS.Services.Paciente
{
    public interface IPacienteService : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetPacientes();

        //By Henrry Torres
        Task<ServiceResponse> GetPacientesFiltro(string busqueda, string condicion);

        //By William Vilca
        Task<ServiceResponse> GetPaciente(string pacienteId);

        //By William Vilca
        Task<ServiceResponse> GetPaciente_By_Dni(string vBusqueda,string vValor);

        //By William Vilca
        Task<ServiceResponse> AddPaciente(MantenimientoPacienteDto dto);
    }
}
