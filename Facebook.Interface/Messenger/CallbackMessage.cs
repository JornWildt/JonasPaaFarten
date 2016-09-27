namespace Facebook.Interface.Messenger
{
  public class CallbackMessage
  {
    public string mid { get; set; }

    public long seq { get; set; }

    public string text { get; set; }
  }
}