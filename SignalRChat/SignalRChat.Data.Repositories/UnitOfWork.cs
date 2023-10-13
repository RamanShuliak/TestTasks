using SignalRChat.Data.Abstractions;
using SignalRChat.DataBase;
using SignalRChat.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SignalRChatDbContext _dbContext;

        public IRepository<User> Users { get; }
        public IRepository<Chat> Chats { get; }
        public IRepository<UserChat> UserChats { get; }
        public IRepository<Message> Messages { get; }

        public UnitOfWork(IRepository<User> users, IRepository<Chat> chats,
                IRepository<UserChat> userChats, SignalRChatDbContext dbContext, 
                IRepository<Message> messages)
        {
            Users = users;
            Chats = chats;
            UserChats = userChats;
            _dbContext = dbContext;
            Messages = messages;
        }


        public async Task<int> CommitAsync()
        {
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
