using log4net;
using Rebus.Bus;

namespace MessageGateway.Utility
{
  public abstract class MessageHandlerBase
  {
    protected static ILog Logger { get; set; }

    public IBus Bus { get; set; }


    public MessageHandlerBase()
    {
      Logger = LogManager.GetLogger(GetType());
    }
  }
}
