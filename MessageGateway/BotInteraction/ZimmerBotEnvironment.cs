using System;
using log4net;
using MessageGateway.Messages;
using MessageGateway.Utility;
using Rebus.Bus;
using ZimmerBot.Core;

namespace MessageGateway.BotInteraction
{
  public class ZimmerBotEnvironment : IBotEnvironment
  {
    private static ILog Logger = LogManager.GetLogger(typeof(ZimmerBotEnvironment));


    public void HandleResponse(Response response)
    {
      string[] output = response.Output;

      MessageState state = (MessageState)response.State;

      if (output.Length > 0)
      {
        foreach (string s in output)
        {
          ApplicationStarter.Container.Resolve<IBus>().Send(new SendMessageCommand
          {
            ReciverId = state.SenderId,
            Text = s
          });
        }
      }
    }


    public void Log(LogLevel level, string msg, params object[] args)
    {
      switch (level)
      {
        case LogLevel.Debug:
          Logger.DebugFormat(msg, args);
          break;
        case LogLevel.Info:
          Logger.InfoFormat(msg, args);
          break;
        case LogLevel.Warn:
          Logger.WarnFormat(msg, args);
          break;
        case LogLevel.Error:
          Console.WriteLine("Internal error");
          Logger.ErrorFormat(msg, args);
          break;
      }
    }


    public void Log(LogLevel level, string msg, Exception ex)
    {
      switch (level)
      {
        case LogLevel.Debug:
          Logger.Debug(msg, ex);
          break;
        case LogLevel.Info:
          Logger.Info(msg, ex);
          break;
        case LogLevel.Warn:
          Logger.Warn(msg, ex);
          break;
        case LogLevel.Error:
          Console.WriteLine("Internal error");
          Logger.Error(msg, ex);
          break;
      }
    }
  }
}
