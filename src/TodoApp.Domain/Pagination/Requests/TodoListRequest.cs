namespace TodoApp.Domain.Pagination;

/// <summary>
/// Запрос для получения списков задач пользователя
/// </summary>
public class TodoListRequest : PagedRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Включать только собственные списки (исключить общие)
    /// </summary>
    public bool OwnedOnly { get; set; } = false;
}
