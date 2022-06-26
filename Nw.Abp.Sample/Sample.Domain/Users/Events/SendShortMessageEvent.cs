using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Users.Events
{
    public record SendShortMessageEvent : IntegrationEvent
    {
        public int UserId { get; }

        public SendShortMessageEvent(int userId) => UserId = userId;
    }
}
