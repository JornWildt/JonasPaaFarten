namespace Facebook.Interface.Messenger
{
  public class CallbackEntry
  {
    public string id { get; set; }

    public long time { get; set; }

    public CallbackMessageBase[] messaging { get; set; }
  }
}