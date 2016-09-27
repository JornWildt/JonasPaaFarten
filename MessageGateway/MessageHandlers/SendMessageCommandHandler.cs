using System.Threading.Tasks;
using Facebook.Interface.Messenger;
using MessageGateway.Messages;
using MessageGateway.Utility;
using Rebus.Handlers;

namespace MessageGateway.MessageHandlers
{
  public class SendMessageCommandHandler : MessageHandlerBase, IHandleMessages<SendMessageCommand>
  {
    public IFacebookMessenger FacebookMessenger { get; set; }


    public async Task Handle(SendMessageCommand cmd)
    {
      Logger.Debug("Got message");
      FacebookMessenger.Send(cmd.ReciverId, cmd.Text);
    }
  }
}
