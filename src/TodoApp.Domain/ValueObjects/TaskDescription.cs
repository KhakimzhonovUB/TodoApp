namespace TodoApp.Domain.ValueObjects;

/// <summary>
/// Объект-значение для описания задачи
/// </summary>
public sealed record TaskDescription
{
    public const int MaxLength = 2000;
    
    /// <summary>
    /// Значение описания
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Проверить, является ли описание пустым
    /// </summary>
    public bool IsEmpty => string.IsNullOrWhiteSpace(Value);
    
    /// <summary>
    /// Создать новое описание задачи
    /// </summary>
    /// <param name="value">Значение описания</param>
    /// <exception cref="ArgumentException">Некорректное значение описания</exception>
    public TaskDescription(string? value = null)
    {
        if (value is null)
        {
            Value = string.Empty;
            return;
        }

        var trimmedValue = value.Trim();
        if (trimmedValue.Length > MaxLength)
            throw new ArgumentException($"Описание задачи не может превышать {MaxLength} символов", nameof(value));

        Value = trimmedValue;
    }

    /// <summary>
    /// Неявное преобразование из строки
    /// </summary>
    /// <param name="value">Строковое значение</param>
    public static implicit operator TaskDescription(string? value) =>
        new(value);
    
    /// <summary>
    /// Неявное преобразование в строку
    /// </summary>
    /// <param name="description">Описание задачи</param>
    public static implicit operator string(TaskDescription description) =>
        description.Value;
    
    /// <summary>
    /// Проверить корректность значения
    /// </summary>
    /// <param name="value">Проверяемое значение</param>
    /// <returns>True, если значение корректно</returns>
    public static bool IsValid(string? value) =>
        value is null || value.Trim().Length <= MaxLength;

    /// <summary>
    /// Проверить, содержит ли описание указанный текст
    /// </summary>
    /// <param name="searchText">Искомый текст</param>
    /// <param name="ignoreCase">Игнорировать регистр</param>
    /// <returns>True, если содержит</returns>
    public bool Contains(string searchText, bool ignoreCase = true) =>
        !IsEmpty && Value.Contains(searchText, ignoreCase
            ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

    /// <summary>
    /// Подсчитать количество слов в описании
    /// </summary>
    /// <returns>Количество слов</returns>
    public int GetWordCount()
    {
        if (IsEmpty)
            return 0;

        return Value.Split([' ', '\t', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries).Length;
    }

    /// <summary>
    /// Подсчитать количество строк в описании
    /// </summary>
    /// <returns>Количество строк</returns>
    public int GetLineCount()
    {
        if (IsEmpty)
            return 0;
        
        return Value.Split(['\n'], StringSplitOptions.RemoveEmptyEntries).Length;
    }
}