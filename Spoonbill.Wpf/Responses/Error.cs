namespace Spoonbill.Wpf.Responses;

public class Error : IMessageResult
{
    public Error(string message)
    {
        Message = message;
    }

    public string Message { get; init; }
}