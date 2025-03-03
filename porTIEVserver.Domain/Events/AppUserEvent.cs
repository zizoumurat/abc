using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MediatR;

namespace porTIEVserver.Domain.Events
{
    public sealed class AppUserEvent : INotification
    {
        public Guid UserRef { get; set; }

        public AppUserEvent(Guid userRef)
        {
            UserRef = userRef;
        }
    }
}
