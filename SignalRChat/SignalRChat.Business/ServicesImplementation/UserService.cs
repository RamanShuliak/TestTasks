using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Business.Hubs;
using SignalRChat.Core.Abstractions;
using SignalRChat.Data.Abstractions;
using SignalRChat.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalRChat.Business.ServicesImplementation
{
    public class UserService : IUserService
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IHubContext<ChatHub> hubContext, IUnitOfWork unitOfWork)
        {
            _hubContext = hubContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> SendMessageToChat(Guid chatId, Guid userId, string messageText)
        {
            var chat = await _unitOfWork.Chats
                .GetEntityByIdAsync(chatId);
            var user = await _unitOfWork.Users
                .GetEntityByIdAsync(userId);

            if (chat == null)
            {
                throw new Exception($"The are no chat's in data base with Id {chatId}.");
            }
            else if (user == null)
            {
                throw new Exception($"The are no user's in data base with Id {userId}.");
            }

            var newMessage = new Message()
            {
                Id = Guid.NewGuid(),
                Text = messageText,
                UserId = userId,
                ChatId = chatId
            };

            await _unitOfWork.Messages.AddAsync(newMessage);
            var result = await _unitOfWork.CommitAsync();

            await _hubContext.Clients.Group(chat.Name).SendAsync("ReceiveMessage", user.Name, messageText);

            return result;
        }

        public async Task<int> JoinChat(Guid chatId, Guid userId)
        {
            var chat = await _unitOfWork.Chats
                .GetEntityByIdAsync(chatId);

            var user = await _unitOfWork.Users
                .GetEntityByIdAsync(userId);

            if(chat == null)
            {
                throw new Exception($"The are no chat's in data base with Id {chatId}.");
            }
            else if(user == null)
            {
                throw new Exception($"The are no user's in data base with Id {userId}.");
            }

            var userChat = new UserChat()
            {
                UserId = userId,
                ChatId = chatId
            };

            await _unitOfWork.UserChats.AddAsync(userChat);

            var result = await _unitOfWork.CommitAsync();

            await _hubContext.Groups.AddToGroupAsync(userId.ToString(), chat.Name);

            await _hubContext.Clients.Group(chat.Name)
                .SendAsync("ReceiveMessage", "System", $"{user.Name} joined the chat.");

            return result;
        }

        public async Task<int> DeleteChat(Guid chatId, Guid userId)
        {
            var chat = await _unitOfWork.Chats
                .GetEntityByIdAsync(chatId);

            if(chat != null)
            {
                if (!chat.CreatorUserId.Equals(userId))
                {
                    throw new Exception("The are no permissions for that. Chat can be deleted only by it creator.");
                }

                var userChats = await _unitOfWork.UserChats
                    .Get()
                    .AsNoTracking()
                    .Where(uc => uc.ChatId.Equals(chatId))
                    .Select(uc => uc)
                    .ToListAsync();

                _unitOfWork.UserChats.RemoveRange(userChats);

                _unitOfWork.Chats.Remove(chat);

                var result = await _unitOfWork.CommitAsync();

                await _hubContext.Clients.Client(userId.ToString())
                    .SendAsync("ReceiveMessage", "System", $"Chat {chat.Name} was deleted.");

                return result;
            }
            else
            {
                throw new Exception("The are no chat's with this ID in data base.");
            }
        }

        public async Task<int> CreateNewChat(Guid userId, string chatName, List<string> usersNamesForAdding)
        {
            var userCreator = await _unitOfWork.Users
                .GetEntityByIdAsync(userId);

            if (userCreator == null)
            {
                throw new Exception($"The are no user's in data base with Id {userId}.");
            }

            var newChatId = Guid.NewGuid();
            var newChat = new Chat
            {
                Id = newChatId,
                Name = chatName,
                CreatorUserId = userId,
                UserChats = new List<UserChat>()
                {
                    new UserChat()
                    {
                        Id = Guid.NewGuid(),
                        ChatId = newChatId,
                        UserId = userId
                    }
                }
            };

            var newUserChats = new List<UserChat>();

            foreach (var userName in usersNamesForAdding)
            {
                var userAddedForChat = await _unitOfWork.Users
                    .Get()
                    .AsNoTracking()
                    .Where(user => user.Name.Equals(userName))
                    .Select(user => user)
                    .FirstOrDefaultAsync();

                if(userAddedForChat == null)
                {
                    throw new Exception($"The are no user's in data base with Name {userName}.");
                }

                var newUserChat = new UserChat()
                {
                    Id = Guid.NewGuid(),
                    UserId = userAddedForChat.Id,
                    ChatId = newChatId
                };

                newUserChats.Add(newUserChat);
            }

            await _unitOfWork.UserChats.AddRangeAsync(newUserChats);

            await _unitOfWork.Chats.AddAsync(newChat);

            var result = await _unitOfWork.CommitAsync();

            await _hubContext.Clients.Group(newChat.Name)
                .SendAsync("ReceiveMessage", "System", $"User {userCreator.Name} create a new chat \"{newChat.Name}\".");

            return result;
        }

        public async Task<List<Chat>?> FindChats()
        {
            var chats = await _unitOfWork.Chats
                .Get()
                .AsNoTracking()
                .ToListAsync();

            return chats;
        }

        public async Task<Guid> CreateNewUser(string userName)
        {
            if(userName != null)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = userName
                };

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CommitAsync();

                return user.Id;
            }
            else
            {
                throw new ArgumentException("User name can't be empty");
            }
        }
    }
}
