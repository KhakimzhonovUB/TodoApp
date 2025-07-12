using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Pagination;

/// <summary>
/// Запрос для получения записей о совместном доступе к спискам задач
/// </summary>
public class TodoListShareRequest : PagedRequest
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
    /// Фильтр по уровню доступа
    /// </summary>
    public SharePermission? Permission { get; set; }
}
