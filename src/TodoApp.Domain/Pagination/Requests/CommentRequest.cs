namespace TodoApp.Domain.Pagination;

/// <summary>
/// Запрос для получения комментариев
/// </summary>
public class CommentRequest : PagedRequest
{
    /// <summary>
    /// Идентификатор задачи
    /// </summary>
    public Guid TodoTaskId { get; set; }
    
    /// <summary>
    /// Идентификатор автора комментариев (опционально)
    /// </summary>
    public Guid? AuthorId { get; set; }
}
