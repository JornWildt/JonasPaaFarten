namespace Facebook.Interface.Messenger
{
  public class Callback
  {
    public string @object { get; set; }

    public CallbackEntry[] entry { get; set; }
  }
}