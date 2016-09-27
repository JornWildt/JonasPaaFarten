using System;
using Facebook.Interface.Messenger;
using log4net;

namespace Jonas.Utility
{
  public class FacebookMessengerStub : IFacebookMessenger
  {
    private static ILog Logger = LogManager.GetLogger(typeof(FacebookMessengerStub));


    public void Send(string recipientId, string text)
    {
      Logger.DebugFormat("Send to {0}: {1}", recipientId, text);
      Console.WriteLine($"{recipientId}: {text}");
    }
  }
}
