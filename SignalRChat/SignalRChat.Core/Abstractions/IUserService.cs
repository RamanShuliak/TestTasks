using SignalRChat.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Core.Abstractions
{
    public interface IUserService
    {
        Task<int> SendMessageToChat(Guid chatId, Guid userId, string messageText);
        Task<int> JoinChat(Guid chatId, Guid userId);
        Task<int> DeleteChat(Guid chatId, Guid userId);
        Task<int> CreateNewChat(Guid userId, string chatName, List<string> usersNamesForAdding);
        Task<List<Chat>?> FindChats();
        Task<Guid> CreateNewUser(string userName);
    }
}
