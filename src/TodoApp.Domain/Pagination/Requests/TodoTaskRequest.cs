using TodoApp.Domain.Enums;
using TaskStatus = TodoApp.Domain.Enums.TaskStatus;

namespace TodoApp.Domain.Pagination;

/// <summary>
/// Запрос для получения задач
/// </summary>
public class TodoTaskRequest : PagedRequest
{
    /// <summary>
    /// Идентификатор списка задач
    /// </summary>
    public Guid? TodoListId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// Фильтр по статусу
    /// </summary>
    public TaskStatus? Status { get; set; }
    
    /// <summary>
    /// Фильтр по приоритету
    /// </summary>
    public TaskPriority? Priority { get; set; }
    
    /// <summary>
    /// Фильтр по назначенному пользователю
    /// </summary>
    public Guid? AssignedUserId { get; set; }
    
    /// <summary>
    /// Показать только просроченные задачи
    /// </summary>
    public bool OverdueOnly { get; set; } = false;
    
    /// <summary>
    /// Фильтр по дате выполнения (от)
    /// </summary>
    public DateTime? DueDateFrom { get; set; }
    
    /// <summary>
    /// Фильтр по дате выполнения (до)
    /// </summary>
    public DateTime? DueDateTo { get; set; }
}
