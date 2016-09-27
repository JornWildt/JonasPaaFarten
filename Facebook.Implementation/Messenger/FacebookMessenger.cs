using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Interface.Messenger;
using log4net;
using Ramone;

// EAAEYPrlNzjIBANlZCfhWEJxrqzZBQZC7Herlo3z1KRzmzZCvacsVJZAxonCsQxeAzZC8yGSrb82tBzAKt5ng4272GLVHKhZCv3gGZCnLX1duRmTECODHu1fmU0HyUF0iZCujgQcGdARrgZCF44pXhMy1siE3PRohWHTPirGv7GIg21jgZDZD


namespace Facebook.Implementation.Messenger
{
  public class FacebookMessenger : IFacebookMessenger
  {
    private static ILog Logger = LogManager.GetLogger(typeof(FacebookMessenger));


      //= "EAAEYPrlNzjIBAMNq53lvI8A6F2QA7TQ3FCEq5ZCG4kveMIyTUPcOTLz1nqYMRAsJu4BCxN4bm80uU6zXIcV7ZBaZCkvRcOMskLqal4YCZCTfQr0ZAzraVHz9oFvM6ZB5CbPOQ5qdxb9pHqIoreq1WrZCCYwNdKzyksIvDkVVarFoAZDZD";

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
