using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Responses;

public class Error : IMessageResult
{
    private readonly Exception m_exception;

    public Error(Exception exception)
    {
        if (exception is DbUpdateException)
        {
            m_exception = exception.InnerException ?? exception;
        }
        else
            m_exception = exception;
    }

    public string Message => m_exception.Message;
}