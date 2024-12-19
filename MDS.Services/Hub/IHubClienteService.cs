using MDS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Hub
{
    public interface IHubClienteService
    {
        Task UserLeft(string id);

        Task NewOnlineUser(UsuarioEnLineaDto userInfo);

        Task Joined(UsuarioEnLineaDto userInfo);

        Task OnlineUsers(IEnumerable<UsuarioEnLineaDto> userInfo);

        Task Logout(UsuarioEnLineaDto userInfo);

        Task ForceLogout(UsuarioEnLineaDto userInfo);

        Task SendDM(string message, UsuarioEnLineaDto userInfo);
    }
}
