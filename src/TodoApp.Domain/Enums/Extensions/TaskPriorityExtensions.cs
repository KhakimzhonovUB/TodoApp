namespace TodoApp.Domain.Enums;

/// <summary>
/// Методы расширения для работы с TaskPriority
/// </summary>
public static class TaskPriorityExtensions
{
    /// <summary>
    /// Получить отображаемое имя приоритета
    /// </summary>
    /// <param name="priority">Приоритет задачи</param>
    /// <returns>Отображаемое имя приоритета</returns>
    public static string GetDisplayName(this TaskPriority priority) =>
        priority switch
        {
            TaskPriority.VeryLow => "Very Low",
            TaskPriority.Low => "Low",
            TaskPriority.Medium => "Medium",
            TaskPriority.High => "High",
            TaskPriority.Critical => "Critical",
            _ => throw new ArgumentOutOfRangeException(
                nameof(priority), priority, "Неизвестный приоритет задачи")
        };
    
    /// <summary>
    /// Получить описание приоритета
    /// </summary>
    /// <param name="priority">Приоритет задачи</param>
    /// <returns>Описание приоритета</returns>
    public static string GetDescription(this TaskPriority priority) =>
        priority switch
        {
            TaskPriority.VeryLow => "Задача с очень низким приоритетом, может быть выполнена в последнюю очередь",
            TaskPriority.Low => "Задача с низким приоритетом, не требует срочного выполнения",
            TaskPriority.Medium => "Задача со средним приоритетом, стандартное время выполнения",
            TaskPriority.High => "Задача с высоким приоритетом, требует быстрого выполнения",
            TaskPriority.Critical => "Критическая задача, требует немедленного внимания",
            _ => throw new ArgumentOutOfRangeException(
                nameof(priority), priority, "Неизвестный приоритет задачи")
        };
    
    /// <summary>
    /// Получить все доступные приоритеты в порядке убывания важности
    /// </summary>
    /// <returns>Коллекция приоритетов</returns>
    public static IEnumerable<TaskPriority> GetPriorities() =>
        [TaskPriority.Critical, TaskPriority.High, TaskPriority.Medium, TaskPriority.Low, TaskPriority.VeryLow];
}
