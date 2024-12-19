using MDS.Dto;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Hub.Implementation
{
    public class HubClienteService : Hub<IHubClienteService>
    {
        private IConnectionMappingService _userInfoInMemory;

        public HubClienteService(IConnectionMappingService userInfoInMemory)
        {
            _userInfoInMemory = userInfoInMemory;
        }

        public async Task Leave(string id)
        {
            var userInfo = _userInfoInMemory.GetUserInfoByName(id);
            _userInfoInMemory.Remove(userInfo);
            await Clients.AllExcept(new List<string> { Context.ConnectionId })
                .UserLeft(id);
        }

        public async Task Logout(string id)
        {
            var userInfo = _userInfoInMemory.GetUserInfoByName(id);
            if (userInfo != null)
            {
                _userInfoInMemory.Remove(userInfo);
                await Clients.AllExcept(new List<string> { Context.ConnectionId })
                    .UserLeft(id);
            }
        }

        public async Task ForceLogout(string id)
        {
            var userInfo = _userInfoInMemory.GetUserInfoByName(id);
            if (userInfo != null)
            {
                _userInfoInMemory.Remove(userInfo);

                await Clients.Client(userInfo.connectionId)
                       .ForceLogout(userInfo);

                await Clients.AllExcept(new List<string> { userInfo.connectionId })
                    .UserLeft(id);
            }
        }

        public async Task Join(UsuarioEnLineaDto userInfo)
        {
            if (!_userInfoInMemory.AddUpdate(userInfo, Context.ConnectionId))
            {
                // new user
                await Clients.AllExcept(new List<string> { Context.ConnectionId })
                    .NewOnlineUser(_userInfoInMemory.GetUserInfo(userInfo));
            }
            else
            {
                // existing user joined again
            }

            await Clients.Client(Context.ConnectionId)
                .Joined(_userInfoInMemory.GetUserInfo(userInfo));

            await Clients.Client(Context.ConnectionId)
                .OnlineUsers(_userInfoInMemory.GetAllUsersExceptThis(userInfo));
        }

        public Task SendDirectMessage(string message, string targetUserName)
        {
            var userInfoSender = _userInfoInMemory.GetUserInfoByConnectionId(Context.ConnectionId);
            var userInfoReciever = _userInfoInMemory.GetUserInfoByName(targetUserName);
            return Clients.Client(userInfoReciever.connectionId).SendDM(message, userInfoSender);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userInfo = _userInfoInMemory.GetUserInfoByConnectionId(Context.ConnectionId);
            if (userInfo == null)
                return;
            _userInfoInMemory.Remove(userInfo);
            await Clients.AllExcept(new List<string> { userInfo.connectionId }).UserLeft(userInfo.id);
        }
    }
}
