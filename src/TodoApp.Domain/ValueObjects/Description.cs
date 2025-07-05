namespace TodoApp.Domain.ValueObjects;

/// <summary>
/// Объект-значение для описаний (задач, списков задач и т.д.)
/// </summary>
public sealed record Description
{
    public const int DefaultMaxLength = 2000;
    
    /// <summary>
    /// Значение описания
    /// </summary>
    public string? Value { get; }

    /// <summary>
    /// Максимальная длина описания
    /// </summary>
    public int MaxLength { get; }

    /// <summary>
    /// Проверить, является ли описание пустым
    /// </summary>
    public bool IsEmpty => string.IsNullOrWhiteSpace(Value);
    
    /// <summary>
    /// Создать новое описание
    /// </summary>
    /// <param name="value">Значение описания</param>
    /// <param name="maxLength">Максимальная длина (по умолчанию 2000)</param>
    /// <exception cref="ArgumentException">Некорректное значение описания</exception>
    public Description(string? value = null, int maxLength = DefaultMaxLength)
    {
        if (maxLength < 0)
            throw new ArgumentException("Максимальная длина должна быть не меньше 0", nameof(maxLength));

        MaxLength = maxLength;
        Value = value?.Trim() switch
        {
            null or "" => null,
            var trimmed when trimmed.Length > maxLength => 
                throw new ArgumentException($"Описание не может превышать {maxLength} символов", nameof(value)),
            var trimmed => trimmed
        };
    }

    /// <summary>
    /// Неявное преобразование из строки
    /// </summary>
    /// <param name="value">Строковое значение</param>
    public static implicit operator Description(string? value) =>
        new(value);
    
    /// <summary>
    /// Неявное преобразование в строку
    /// </summary>
    /// <param name="description">Описание</param>
    public static implicit operator string?(Description description) =>
        description.Value;

    /// <summary>
    /// Создать описание списка задач (максимум 2000 символов)
    /// </summary>
    /// <param name="value">Значение описания</param>
    /// <returns>Описание списка задач</returns>
    public static Description ForList(string? value = null) =>
        new(value);
    
    /// <summary>
    /// Создать описание задачи (максимум 500 символов)
    /// </summary>
    /// <param name="value">Значение описания</param>
    /// <returns>Описание задачи</returns>
    public static Description ForTask(string? value = null) =>
        new(value, 500);
    
    /// <summary>
    /// Проверить корректность значения
    /// </summary>
    /// <param name="value">Проверяемое значение</param>
    /// <param name="maxLength">Максимальная длина</param>
    /// <returns>True, если значение корректно</returns>
    public static bool IsValid(string? value, int maxLength = DefaultMaxLength) =>
        value is null || value.Trim().Length <= maxLength;

    /// <summary>
    /// Проверить, содержит ли описание указанный текст
    /// </summary>
    /// <param name="searchText">Искомый текст</param>
    /// <param name="ignoreCase">Игнорировать регистр</param>
    /// <returns>True, если содержит</returns>
    public bool Contains(string searchText, bool ignoreCase = true) =>
        !IsEmpty && Value!.Contains(searchText, ignoreCase
            ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

    /// <summary>
    /// Подсчитать количество слов в описании
    /// </summary>
    /// <returns>Количество слов</returns>
    public int GetWordCount()
    {
        if (IsEmpty)
            return 0;

        return Value!.Split([' ', '\t', '\n', '\r'],
            StringSplitOptions.RemoveEmptyEntries).Length;
    }

    /// <summary>
    /// Подсчитать количество строк в описании
    /// </summary>
    /// <returns>Количество строк</returns>
    public int GetLineCount()
    {
        if (IsEmpty)
            return 0;
        
        return Value!.Split(['\n'],
            StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
