namespace TodoApp.Domain.Enums;

/// <summary>
/// Перечисление статусов задач
/// </summary>
public enum TaskStatus
{
    /// <summary>
    /// Задача не начата
    /// </summary>
    NotStarted = 0,
    
    /// <summary>
    /// Задача в процессе выполнения
    /// </summary>
    InProgress = 1,
    
    /// <summary>
    /// Задача завершена
    /// </summary>
    Completed = 2
}
