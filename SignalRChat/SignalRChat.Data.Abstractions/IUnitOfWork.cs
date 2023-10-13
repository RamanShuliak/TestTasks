using SignalRChat.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Abstractions
{
    public interface IUnitOfWork
    {
        public IRepository<User> Users { get; }
        public IRepository<Chat> Chats { get; }
        public IRepository<UserChat> UserChats { get; }
        public IRepository<Message> Messages { get; }

        Task<int> CommitAsync();
    }
}
