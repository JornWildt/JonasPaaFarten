using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MessageGateway.Messages;
using Rebus.Config;
using Rebus.Handlers;
using Rebus;
using Rebus.Routing.TypeBased;
using Rebus.Log4net;
using Rebus.Logging;
using Rebus.Transport.InMem;
using Rebus.Activation;
using Rebus.Bus;
using log4net;
using ZimmerBot.Core;
using ZimmerBot.Core.Knowledge;
using MessageGateway.BotInteraction;

namespace MessageGateway
{
  public static class ApplicationStarter
  {
    private static log4net.ILog Logger = LogManager.GetLogger(typeof(ApplicationStarter));

    public static IWindsorContainer Container { get; private set; }


    public static void Start(IWindsorContainer container)
    {
      Logger.Debug("Starting message gateway");

      Container = container;

      container.Register(Classes.FromAssemblyContaining<SendMessageCommand>()
                                .BasedOn<IHandleMessages>()
                                .WithServiceAllInterfaces()
                                .LifestyleTransient());

      Configure.With(new CastleWindsorContainerAdapter(container))
        .Logging(cf => cf.Log4Net())
        .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "gateway-input"))
        .Routing(r => r.TypeBased().MapAssemblyOf<SendMessageCommand>("gateway-input"))
        .Start();

      BotManager.Start();
    }


    public static void Shutdown()
    {
      BotManager.Shutdown();
    }


    public static void Send<T>(T msg)
    {
      Logger.DebugFormat("Send {0}", msg);      
      Container.Resolve<IBus>().Send(msg);
    }
  }
}
