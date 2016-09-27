using System.Web;
using System.Web.Mvc;
using Jonas_paa_farten.Utility;

namespace Jonas_paa_farten
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleAndLogErrorAttribute());
    }
  }
}
