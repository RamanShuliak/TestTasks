using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.DataBase.Entities
{
    public class UserChat : IBaseEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
