using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Facebook.Interface.Messenger;
using log4net;
using MessageGateway.Events;
using MessageGateway.Messages;
using Ramone;



namespace Jonas_paa_farten.Controllers
{
  public class MessengerController : ApiController
  {
    private static ILog Logger = LogManager.GetLogger(typeof(MessengerController));


    protected object StringContent(string s)
    {
      return new HttpResponseMessage()
      {
        Content = new StringContent(s, Encoding.UTF8, "text/html"),
        StatusCode = HttpStatusCode.OK
      };
    }


    public object Get()
    {
      Logger.Debug("GET");
      Dictionary<string, string> query = Request.GetQueryNameValuePairs().ToDictionary(p => p.Key, p => p.Value);
      if (query.ContainsKey("hub.verify_token")  &&  query.ContainsKey("hub.challenge"))
      {
        Logger.Debug($"Verify {query["hub.verify_token"]} + {query["hub.challenge"]}");
        if (query["hub.verify_token"] == "AluxBahvus")
          return StringContent(query["hub.challenge"]);
      }
      return StringContent("DONE 3");
    }


    public object Post(Callback cb)
    {
      Logger.Debug($"POST {cb}");
      Logger.Debug($"P2 {cb.@object}");
      Logger.Debug($"P3 {cb.entry}");
      Logger.Debug($"P4 {cb.entry.Length}");
      Logger.Debug($"P5 {cb.entry[0].id}");
      Logger.Debug($"P6 {cb.entry[0].messaging[0].message}");

      if (cb.entry != null)
      {
        foreach (var entry in cb.entry)
        {
          if (entry.messaging != null)
          {
            foreach (var m in entry.messaging)
            {
              if (m.message != null)
                HandleMessage(m);
            }
          }
        }
      }

      return StringContent("DONE");
    }


    private void HandleMessage(CallbackMessageBase m)
    {
      Logger.Debug($"HandleMessage {m.message.mid}");

      MessageGateway.ApplicationStarter.Send(new MessageRecievedEvent
      {
        SenderId = m.sender.id,
        Text = m.message.text
      });
    }
  }
}
