using TodoApp.Domain.Common;

namespace TodoApp.Domain.Entities;

/// <summary>
/// Сущность комментария к задаче
/// </summary>
public sealed class Comment : AuditableEntityGuid
{
    private const int ContentMaxLength = 1000;
    
    /// <summary>
    /// Текст комментария
    /// </summary>
    public string Content { get; private set; } = null!;
    
    /// <summary>
    /// Идентификатор автора комментария
    /// </summary>
    public Guid AuthorId { get; private set; }
    
    /// <summary>
    /// Идентификатор задачи, к которой относится комментарий
    /// </summary>
    public Guid TodoTaskId { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к задаче
    /// </summary>
    public TodoTask TodoTask { get; private set; } = null!;
    
    // Конструктор для EF Core
    private Comment() { }

    /// <summary>
    /// Создать новый комментарий
    /// </summary>
    /// <param name="content">Текст комментария</param>
    /// <param name="todoTaskId">Идентификатор задачи</param>
    /// <param name="authorId">Идентификатор автора</param>
    public Comment(string content, Guid todoTaskId, Guid authorId)
    {
        ArgumentNullException.ThrowIfNull(content, nameof(content));
        
        if (content.Trim().Length > ContentMaxLength)
            throw new ArgumentException("Комментарий не может превышать 1000 символов", nameof(content));

        Content = content.Trim();
        TodoTaskId = todoTaskId;
        AuthorId = authorId;
        
        SetCreatedInfo(authorId);
    }

    /// <summary>
    /// Обновить содержимое комментария
    /// </summary>
    /// <param name="content">Новое содержимое</param>
    /// <param name="updatedBy">Идентификатор пользователя</param>
    public void UpdateContent(string content, Guid updatedBy)
    {
        ArgumentException.ThrowIfNullOrEmpty(content, nameof(content));
        
        if (content.Trim().Length > ContentMaxLength)
            throw new ArgumentException("Комментарий не может превышать 1000 символов", nameof(content));

        Content = content.Trim();
        SetUpdatedInfo(updatedBy);
    }
}
