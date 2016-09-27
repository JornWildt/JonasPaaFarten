using ZimmerBot.Core.Utilities;

namespace MessageGateway.Utility
{
  public static class BotAppSettings
  {
    public static readonly AppSetting<string> ConfigDirectory = new AppSetting<string>("Bot.ConfigDirectory");
  }
}
