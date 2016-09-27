namespace MessageGateway.Events
{
  public class MessageRecievedEvent
  {
    public string SenderId { get; set; }
    public string Text { get; set; }
  }
}
