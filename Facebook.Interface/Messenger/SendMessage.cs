namespace Facebook.Interface.Messenger
{
  public class SendMessage
  {
    public User recipient { get; set; }

    public SendMessageText message { get; set; }
  }
}