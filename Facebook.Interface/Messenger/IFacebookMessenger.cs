using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Interface.Messenger
{
  public interface IFacebookMessenger
  {
    void Send(string recipientId, string text);
  }
}
