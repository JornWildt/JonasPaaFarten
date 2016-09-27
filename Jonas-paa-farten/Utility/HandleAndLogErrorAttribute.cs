using System.Web.Mvc;
using log4net;

namespace Jonas_paa_farten.Utility
{
  public class HandleAndLogErrorAttribute : HandleErrorAttribute
  {
    private static ILog Logger = LogManager.GetLogger(typeof(HandleAndLogErrorAttribute));

    public override void OnException(ExceptionContext filterContext)
    {
      base.OnException(filterContext);

      if (filterContext.Exception != null)
      {
        Logger.Error(filterContext.Exception.Message, filterContext.Exception);
      }
      else
        Logger.Error("Unknown error occured");
    }
  }
}