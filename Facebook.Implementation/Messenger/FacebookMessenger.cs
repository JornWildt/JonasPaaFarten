using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Interface.Messenger;
using log4net;
using Ramone;

namespace Facebook.Implementation.Messenger
{
  public class FacebookMessenger : IFacebookMessenger
  {
    private static ILog Logger = LogManager.GetLogger(typeof(FacebookMessenger));

    private string MessagesUrl = "https://graph.facebook.com/v2.6/me/messages?access_token=" + Utility.PageAccessToken;


    public void Send(string recipientId, string text)
    {
      SendMessage sm = new SendMessage
      {
        recipient = new User { id = recipientId },
        message = new SendMessageText { text = text }
      };

      Logger.Debug("Send message back");
      try
      {
        Ramone.Request request = new Ramone.Request(MessagesUrl);
        using (var response = request.AsJson().Post(sm))
        {
        }
      }
      catch (Exception ex)
      {
        Logger.Debug(ex);
      }

      Logger.Debug("Done!");
    }
  }
}
