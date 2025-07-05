namespace TodoApp.Domain.Enums;

/// <summary>
/// Перечисление приоритетов задач
/// </summary>
public enum TaskPriority
{
    /// <summary>
    /// Очень низкий приоритет
    /// </summary>
    VeryLow = 1,
    
    /// <summary>
    /// Низкий приоритет
    /// </summary>
    Low = 2,
    
    /// <summary>
    /// Средний приоритет (по умолчанию)
    /// </summary>
    Medium = 3,
    
    /// <summary>
    /// Высокий приоритет
    /// </summary>
    High = 4,
    
    /// <summary>
    /// Критический приоритет
    /// </summary>
    Critical = 5
}
