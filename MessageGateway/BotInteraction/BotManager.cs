using System;
using log4net;
using MessageGateway.Utility;
using ZimmerBot.Core;
using ZimmerBot.Core.Knowledge;

namespace MessageGateway.BotInteraction
{
  public static class BotManager
  {
    private static ILog Logger = LogManager.GetLogger(typeof(BotManager));


    private static KnowledgeBase KnowledgeBase { get; set; }

    private static Bot Bot { get; set; }

    private static BotHandle BotHandle { get; set; }


    public static void Start()
    {
      Logger.Debug("Starting bot interaction");

      try
      {
        ZimmerBotConfiguration.Initialize();
        KnowledgeBase.InitializationMode initMode = KnowledgeBase.InitializationMode.Clear;

        string configDirectory = BotAppSettings.ConfigDirectory;
        Logger.DebugFormat("configDirectory = {0}", configDirectory);
        configDirectory = AppSettings.MapServerPath(configDirectory);
        Logger.DebugFormat("Mapped configDirectory = {0}", configDirectory);

        KnowledgeBase = new KnowledgeBase();
        KnowledgeBase.Initialize(initMode);
        KnowledgeBase.LoadFromFiles(configDirectory);
        KnowledgeBase.Run();
        Bot = new Bot(KnowledgeBase);

        BotHandle = Bot.Run(new ZimmerBotEnvironment());
      }
      catch (Exception ex)
      {
        Logger.Error(ex);
      }
    }

    public static void Invoke(string senderId, string text)
    {
      if (BotHandle == null)
      {
        Logger.Warn("Bot not initialized!");
        return;
      }

      Request request = new Request(senderId, senderId)
      {
        Input = text,
        State = new MessageState { SenderId = senderId }
      };

      BotHandle.Invoke(request);
    }


    public static void Shutdown()
    {
      ZimmerBotConfiguration.Shutdown();
    }
  }
}
