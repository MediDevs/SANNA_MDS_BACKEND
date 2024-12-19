using MDS.Dto;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Hub.Implementation
{
    public class ConnectionMappingService : IConnectionMappingService
    {
        private ConcurrentDictionary<string, UsuarioEnLineaDto> _usuarioEnLinea { get; set; } = new ConcurrentDictionary<string, UsuarioEnLineaDto>();

        public bool AddUpdate(UsuarioEnLineaDto tempUserInfo, string connectionId)
        {
            var userAlreadyExists = _usuarioEnLinea.ContainsKey(tempUserInfo.id);

            var usuarioEnLineaDto = new UsuarioEnLineaDto
            {
                id = tempUserInfo.id,
                connectionId = connectionId,
                usuario = tempUserInfo.usuario
            };

            _usuarioEnLinea.AddOrUpdate(tempUserInfo.id, usuarioEnLineaDto, (key, value) => usuarioEnLineaDto);

            return userAlreadyExists;
        }

        public void Remove(UsuarioEnLineaDto tempUserInfo)
        {
            UsuarioEnLineaDto usuarioEnLineaDto;
            _usuarioEnLinea.TryRemove(tempUserInfo.id, out usuarioEnLineaDto);
        }

        public IEnumerable<UsuarioEnLineaDto> GetAllUsersExceptThis(UsuarioEnLineaDto tempUserInfo)
        {
            return _usuarioEnLinea.Values.Where(item => item.id != tempUserInfo.id);
        }

        public UsuarioEnLineaDto GetUserInfo(UsuarioEnLineaDto tempUserInfo)
        {
            UsuarioEnLineaDto usuarioEnLineaDto;
            _usuarioEnLinea.TryGetValue(tempUserInfo.id, out usuarioEnLineaDto);
            return usuarioEnLineaDto;
        }

        public UsuarioEnLineaDto GetUserInfoByName(string id)
        {
            UsuarioEnLineaDto usuarioEnLineaDto;
            _usuarioEnLinea.TryGetValue(id, out usuarioEnLineaDto);
            return usuarioEnLineaDto;
        }

        public UsuarioEnLineaDto GetUserInfoByConnectionId(string connectionId)
        {
            foreach (var onlineUser in _usuarioEnLinea)
            {
                var user = onlineUser.Value;
                if (user.connectionId == connectionId)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
