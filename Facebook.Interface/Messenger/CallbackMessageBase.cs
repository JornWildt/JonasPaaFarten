namespace Facebook.Interface.Messenger
{
  public class CallbackMessageBase
  {
    public User sender { get; set; }

    public User recipient { get; set; }

    public long timestamp { get; set; }

    public CallbackMessage message { get; set; }
  }
}