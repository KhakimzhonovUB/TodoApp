namespace TodoApp.Domain.Exceptions;

/// <summary>
/// Базовое доменное исключение
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Код ошибки
    /// </summary>
    public string ErrorCode { get; }

    /// <summary>
    /// Создать новое доменное исключение
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <param name="errorCode">Код ошибки</param>
    public DomainException(string message, string errorCode = "DOMAIN_ERROR")
        : base(message)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// Создать новое доменное исключение с внутренним исключением
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <param name="innerException">Внутреннее исключение</param>
    /// <param name="errorCode">Код ошибки</param>
    public DomainException(string message, Exception innerException, string errorCode = "DOMAIN_ERROR") 
        : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}
