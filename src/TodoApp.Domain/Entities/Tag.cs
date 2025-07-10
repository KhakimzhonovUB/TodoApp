using TodoApp.Domain.Common;

namespace TodoApp.Domain.Entities;

/// <summary>
/// Сущность тега для категоризации задач
/// </summary>
public sealed class Tag : AuditableEntityGuid
{
    private const int NameMaxLength = 50;
    
    /// <summary>
    /// Название тега
    /// </summary>
    public string Name { get; private set; } = null!;

    /// <summary>
    /// Идентификатор пользователя-владельца тега
    /// </summary>
    public Guid OwnerId { get; private set; }
    
    /// <summary>
    /// Коллекция задач, связанных с тегом
    /// </summary>
    public ICollection<TodoTask> Tasks { get; private set; } = [];
    
    // Конструктор для EF Core
    private Tag() { }

    /// <summary>
    /// Создать новый тег
    /// </summary>
    /// <param name="name">Название тега</param>
    /// <param name="ownerId">Идентификатор владельца</param>
    public Tag(string name, Guid ownerId)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        if (name.Trim().Length > NameMaxLength)
            throw new ArgumentException("Название тега не может превышать 50 символов", nameof(name));
        
        Name = name.Trim();
        OwnerId = ownerId;
        
        SetCreatedInfo(ownerId);
    }

    /// <summary>
    /// Обновить название тега
    /// </summary>
    /// <param name="name">Новое название</param>
    /// <param name="updatedBy">Идентификатор пользователя</param>
    public void UpdateName(string name, Guid updatedBy)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        if (name.Trim().Length > NameMaxLength)
            throw new ArgumentException("Название тега не может превышать 50 символов", nameof(name));
        
        Name = name.Trim();
        SetUpdatedInfo(updatedBy);
    }
}
