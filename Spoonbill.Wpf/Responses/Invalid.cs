namespace Spoonbill.Wpf.Responses;

public class Invalid : IMessageResult
{
    public Invalid(string message)
    {
        Message = message;
    }

    public string Message { get; init; }
}