using System;
using System.Configuration;

namespace Facebook.Implementation
{
  public class Utility
  {
    public static string PageAccessToken
    {
      get
      {
        if (ConfigurationManager.ConnectionStrings["FacebookAccessToken"] == null || string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["FacebookAccessToken"].ConnectionString))
          throw new ArgumentException("Missing or empty connection string 'FacebookAccessToken'");
        return ConfigurationManager.ConnectionStrings["FacebookAccessToken"].ConnectionString;
      }
    }
  }
}
