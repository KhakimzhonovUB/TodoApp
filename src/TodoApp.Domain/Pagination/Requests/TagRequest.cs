namespace TodoApp.Domain.Pagination;

/// <summary>
/// Запрос для получения тегов
/// </summary>
public class TagRequest : PagedRequest
{
    /// <summary>
    /// Идентификатор владельца тегов
    /// </summary>
    public Guid OwnerId { get; set; }
    
    /// <summary>
    /// Точное название тега (для поиска конкретного тега)
    /// </summary>
    public string? ExactName { get; set; }
}
