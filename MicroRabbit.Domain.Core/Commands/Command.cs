using MicroRabbit.Domain.Core.Events;

namespace MicroRabbit.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeStamp { get; set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}