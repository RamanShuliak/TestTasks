using Microsoft.EntityFrameworkCore;
using SignalRChat.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.DataBase
{
    public class SignalRChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<Message> Messages { get; set; }

        public SignalRChatDbContext(DbContextOptions<SignalRChatDbContext> options) : base(options)
        {

        }
    }
}
