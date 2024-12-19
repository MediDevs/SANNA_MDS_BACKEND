using MDS.Dto;
using MDS.Dto.Resources;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Usuario
{
    public interface IUsuarioService : IService
    {
        Task<ServiceResponse> LoginUsuario(UsuarioDto dto);

        //By Henrry Torres
        Task<ServiceResponse> GetAllUsuario(UsuarioResource dto);

        //By Henrry Torres
        Task<ServiceResponse> GetUsuario(int vBusqueda);

        Task<ServiceResponse> GetUsuarios();

        //By Henrry Torres
        Task<ServiceResponse> GetPersonasSinUsuario(string vBusqueda);

        //By Henrry Torres
        Task<ServiceResponse> AddUsuario(UsuarioDto dto);

        //By Henrry Torres
        Task<ServiceResponse> AddUsuarioPersona(UsuarioDto dto);

        Task<ServiceResponse> UpdateUsuario(UsuarioDto dto);

        Task<ServiceResponse> DeleteUsuario();

        //By Henrry Torres
        Task<ServiceResponse> ActivarUsuario(UsuarioDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DesactivarUsuario(UsuarioDto dto);

        //By Henrry Torres
        Task<ServiceResponse> ActivarDobleFactorUsuario(UsuarioDto dto);
    }
}
