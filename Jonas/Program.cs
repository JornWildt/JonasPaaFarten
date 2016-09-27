using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Facebook.Interface.Messenger;
using Jonas.Utility;
using log4net;
using MessageGateway;
using MessageGateway.Events;
using MessageGateway.Messages;
using ZimmerBot.Core;
using ZimmerBot.Core.Knowledge;

namespace Jonas
{
  class Program
  {
    private static ILog Logger = LogManager.GetLogger(typeof(Program));


    public static IWindsorContainer Container { get; protected set; } = new WindsorContainer();


    static void Main(string[] args)
    {
      log4net.Config.XmlConfigurator.Configure();
      Container.Register(Component.For<IFacebookMessenger>().ImplementedBy<FacebookMessengerStub>().LifestyleSingleton());
      ApplicationStarter.Start(Container);

      Console.Write("> ");
      string s;
      do
      {
        s = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(s))
          ApplicationStarter.Send(new MessageRecievedEvent { SenderId = "console", Text = s });
      }
      while (!string.IsNullOrWhiteSpace(s));

      ApplicationStarter.Shutdown();
    }
  }
}
