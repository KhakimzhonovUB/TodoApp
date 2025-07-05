namespace TodoApp.Domain.ValueObjects;

/// <summary>
/// Объект-значение для заголовков (задач, списков задач и т.д.)
/// </summary>
public sealed record Title
{
    public const int DefaultMaxLength = 200;
    public const int DefaultMinLength = 1;
    
    /// <summary>
    /// Значение заголовка
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Максимальная длина заголовка
    /// </summary>
    public int MaxLength { get; }

    /// <summary>
    /// Создать новый заголовок
    /// </summary>
    /// <param name="value">Значение заголовка</param>
    /// <param name="maxLength">Максимальная длина (по умолчанию 200)</param>
    /// <exception cref="ArgumentException">Некорректное значение заголовка</exception>
    public Title(string value, int maxLength = DefaultMaxLength)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(maxLength, DefaultMinLength, nameof(maxLength));
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));

        var trimmedValue = value.Trim();
        if (trimmedValue.Length < DefaultMinLength || trimmedValue.Length > maxLength)
            throw new ArgumentOutOfRangeException(nameof(value), 
                $"Длина заголовка должна быть от {DefaultMinLength} до {maxLength} символов");

        Value = trimmedValue;
        MaxLength = maxLength;
    }
    
    /// <summary>
    /// Неявное преобразование из строки
    /// </summary>
    /// <param name="value">Строковое значение</param>
    public static implicit operator Title(string value) => 
        new(value);
    
    /// <summary>
    /// Неявное преобразование в строку
    /// </summary>
    /// <param name="title">Заголовок</param>
    public static implicit operator string(Title title) => 
        title.Value;

    /// <summary>
    /// Создать заголовок списка задач (максимум 200 символов)
    /// </summary>
    /// <param name="value">Значение заголовка</param>
    /// <returns>Заголовок списка задач</returns>
    public static Title ForList(string value) =>
        new(value);
    
    /// <summary>
    /// Создать заголовок задачи (максимум 100 символов)
    /// </summary>
    /// <param name="value">Значение заголовка</param>
    /// <returns>Заголовок задачи</returns>
    public static Title ForTask(string value) =>
        new(value, 100);

    /// <summary>
    /// Проверить корректность значения
    /// </summary>
    /// <param name="value">Проверяемое значение</param>
    /// <param name="maxLength">Максимальная длина</param>
    /// <returns>True, если значение корректно</returns>
    public static bool IsValid(string value, int maxLength = DefaultMaxLength)
    {
        if (maxLength < DefaultMinLength)
            return false;
        
        if (string.IsNullOrWhiteSpace(value))
            return false;
        
        var trimmedValue = value.Trim();
        var isValid = trimmedValue.Length >= DefaultMinLength && trimmedValue.Length <= maxLength;
        
        return isValid;
    }

    /// <summary>
    /// Проверить, содержит ли заголовок указанный текст
    /// </summary>
    /// <param name="searchText">Искомый текст</param>
    /// <param name="ignoreCase">Игнорировать регистр</param>
    /// <returns>True, если содержит</returns>
    public bool Contains(string searchText, bool ignoreCase = true) =>
        Value.Contains(searchText, ignoreCase 
            ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
}
