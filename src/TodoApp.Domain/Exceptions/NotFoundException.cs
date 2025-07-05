namespace TodoApp.Domain.Exceptions;

/// <summary>
/// Исключение, возникающее, когда сущность не найдена
/// </summary>
public class NotFoundException : DomainException
{
    /// <summary>
    /// Тип сущности
    /// </summary>
    public string EntityType { get; }
    
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid EntityId { get; }

    /// <summary>
    /// Создать исключение для ненайденной сущности
    /// </summary>
    /// <param name="entityType">Тип сущности</param>
    /// <param name="entityId">Идентификатор сущности</param>
    public NotFoundException(string entityType, Guid entityId)
        : base($"{entityType} с идентификатором '{entityId}' не найдена", "ENTITY_NOT_FOUND")
    {
        EntityType = entityType;
        EntityId = entityId;
    }

    /// <summary>
    /// Создать исключение для ненайденной сущности с внутренним исключением
    /// </summary>
    /// <param name="entityType">Тип сущности</param>
    /// <param name="entityId">Идентификатор сущности</param>
    /// <param name="innerException">Внутреннее исключение</param>
    public NotFoundException(string entityType, Guid entityId, Exception innerException)
        : base($"{entityType} с идентификатором '{entityId}' не найдена", innerException, "ENTITY_NOT_FOUND")
    {
        EntityType = entityType;
        EntityId = entityId;
    }
}
