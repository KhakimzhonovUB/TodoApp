namespace TodoApp.Domain.ValueObjects;

/// <summary>
/// Объект-значение для заголовка задачи
/// </summary>
public sealed record TaskTitle
{
    public const int MaxLength = 200;
    public const int MinLength = 1;
    
    /// <summary>
    /// Значение заголовка
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Создать новый заголовок задачи
    /// </summary>
    /// <param name="value">Значение заголовка</param>
    /// <exception cref="ArgumentException">Некорректное значение заголовка</exception>
    public TaskTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Заголовок задачи не может быть пустым", nameof(value));

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MinLength)
            throw new ArgumentException(
                $"Заголовок задачи должен содержать минимум {MinLength} символ", nameof(value));

        if (trimmedValue.Length > MaxLength)
            throw new ArgumentException(
                $"Заголовок задачи не может превышать {MaxLength} символов", nameof(value));

        Value = trimmedValue;
    }
    
    /// <summary>
    /// Неявное преобразование из строки
    /// </summary>
    /// <param name="value">Строковое значение</param>
    public static implicit operator TaskTitle(string value) => 
        new(value);
    
    /// <summary>
    /// Неявное преобразование в строку
    /// </summary>
    /// <param name="title">Заголовок задачи</param>
    public static implicit operator string(TaskTitle title) => 
        title.Value;

    /// <summary>
    /// Проверить корректность значения
    /// </summary>
    /// <param name="value">Проверяемое значение</param>
    /// <returns>True, если значение корректно</returns>
    public static bool IsValid(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;
        
        var trimmedValue = value.Trim();
        var isValid = trimmedValue.Length is >= MinLength and <= MaxLength;
        
        return isValid;
    }
}
