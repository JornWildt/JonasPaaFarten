using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Facebook.Implementation.Messenger;
using Facebook.Interface.Messenger;
using Jonas_paa_farten.Utility;
using MessageGateway.Messages;
using ZimmerBot.Core;

namespace Jonas_paa_farten
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    public static IWindsorContainer Container { get; protected set; } = new WindsorContainer();

    protected void Application_Start()
    {
      log4net.Config.XmlConfigurator.Configure();
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      AppSettings.MapServerPath = (s) => Server.MapPath(s);
      Container.Register(Component.For<IFacebookMessenger>().ImplementedBy<FacebookMessenger>().LifestyleSingleton());

      MessageGateway.ApplicationStarter.Start(Container);

      //MessageGateway.ApplicationStarter.Send(new SendMessageCommand { ReciverId = "A", Text = "B" });
    }
  }
}
