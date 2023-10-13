using Microsoft.AspNetCore.SignalR;
using SignalRChat.Core.Abstractions;
using SignalRChat.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Business.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToChat(string chatName, string userName, string message) 
            => await Clients.Group(chatName).SendAsync("ReceiveMessage", userName, message);

        public async Task JoinChat(string chatName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatName);

            await Clients.Group(chatName)
                .SendAsync("ReceiveMessage", "System", $"{userName} joined the chat.");
        }

        public async Task DeleteChat(string chatName)
            => await Clients.Caller.SendAsync("ReceiveMessage", "System", $"Chat {chatName} was deleted.");

        public async Task CreateChat(string chatName, string userName)
        {
            await Clients.Group(chatName)
                .SendAsync("ReceiveMessage", "System", $"User {userName} create a new chat \"{chatName}\".");
        }
    }
}
