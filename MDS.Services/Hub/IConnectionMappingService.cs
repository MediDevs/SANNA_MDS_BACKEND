using MDS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Hub
{
    public interface IConnectionMappingService
    {
        bool AddUpdate(UsuarioEnLineaDto tempUserInfo, string connectionId);
        void Remove(UsuarioEnLineaDto tempUserInfo);
        IEnumerable<UsuarioEnLineaDto> GetAllUsersExceptThis(UsuarioEnLineaDto tempUserInfo);
        UsuarioEnLineaDto GetUserInfo(UsuarioEnLineaDto tempUserInfo);
        UsuarioEnLineaDto GetUserInfoByName(string id);
        UsuarioEnLineaDto GetUserInfoByConnectionId(string connectionId);
    }
}
