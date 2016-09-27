namespace MessageGateway.Messages
{
  public class SendMessageCommand
  {
    public string ReciverId { get; set; }
    public string Text { get; set; }
  }
}
