namespace TodoApp.Domain.Enums;

/// <summary>
/// Методы расширения для работы с TaskStatus
/// </summary>
public static class TaskStatusExtensions
{
    /// <summary>
    /// Получить отображаемое имя статуса
    /// </summary>
    /// <param name="status">Статус задачи</param>
    /// <returns>Отображаемое имя статуса</returns>
    public static string GetDisplayName(this TaskStatus status) =>
        status switch
        {
            TaskStatus.NotStarted => "Not Started",
            TaskStatus.InProgress => "In Progress",
            TaskStatus.Completed => "Completed",
            _ => throw new ArgumentOutOfRangeException(
                nameof(status), status, "Неизвестный статус задачи")
        };
    
    /// <summary>
    /// Получить описание статуса
    /// </summary>
    /// <param name="status">Статус задачи</param>
    /// <returns>Описание статуса</returns>
    public static string GetDescription(this TaskStatus status) =>
        status switch
        {
            TaskStatus.NotStarted => "Задача создана, но работа над ней еще не начата",
            TaskStatus.InProgress => "Задача находится в процессе выполнения",
            TaskStatus.Completed => "Задача полностью завершена",
            _ => throw new ArgumentOutOfRangeException(
                nameof(status), status, "Неизвестный статус задачи")
        };
    
    /// <summary>
    /// Проверить, может ли задача быть переведена в указанный статус
    /// </summary>
    /// <param name="currentStatus">Текущий статус</param>
    /// <param name="targetStatus">Целевой статус</param>
    /// <returns>True, если переход возможен</returns>
    public static bool CanTransitionTo(this TaskStatus currentStatus, TaskStatus targetStatus) =>
        currentStatus switch
        {
            TaskStatus.NotStarted => targetStatus is TaskStatus.InProgress or TaskStatus.Completed,
            TaskStatus.InProgress => targetStatus is TaskStatus.NotStarted or TaskStatus.Completed,
            TaskStatus.Completed => targetStatus is TaskStatus.InProgress,
            _ => false
        };

    /// <summary>
    /// Получить все возможные следующие статусы
    /// </summary>
    /// <param name="currentStatus">Текущий статус</param>
    /// <returns>Коллекция возможных следующих статусов</returns>
    public static IEnumerable<TaskStatus> GetPossibleTransitions(this TaskStatus currentStatus) =>
        currentStatus switch
        {
            TaskStatus.NotStarted => [TaskStatus.InProgress, TaskStatus.Completed],
            TaskStatus.InProgress => [TaskStatus.NotStarted, TaskStatus.Completed],
            TaskStatus.Completed => [TaskStatus.InProgress],
            _ => []
        };
}
