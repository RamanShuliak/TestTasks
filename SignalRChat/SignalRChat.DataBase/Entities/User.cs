using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.DataBase.Entities
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<UserChat>? UserChats { get; set; }
        public virtual List<Message>? Messages { get; set; }
    }
}
