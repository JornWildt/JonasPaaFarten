using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageGateway.BotInteraction;
using MessageGateway.Events;
using MessageGateway.Utility;
using Rebus.Handlers;

namespace MessageGateway.MessageHandlers
{
  public class MessageRecievedEventHandler : MessageHandlerBase, IHandleMessages<MessageRecievedEvent>
  {
    public async Task Handle(MessageRecievedEvent e)
    {
      BotManager.Invoke(e.SenderId, e.Text);
    }
  }
}
