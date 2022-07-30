using MediatR;
using System;

namespace NerdStore.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime criadoEm { get; private set; }

        public Event()
        {
            criadoEm = DateTime.Now;
        }
    }
}
