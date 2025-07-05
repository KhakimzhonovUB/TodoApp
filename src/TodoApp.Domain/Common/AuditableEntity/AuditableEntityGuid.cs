namespace TodoApp.Domain.Common;

/// <summary>
/// Базовая сущность с полями аудита для идентификаторов типа Guid
/// </summary>
public abstract class AuditableEntityGuid : AuditableEntity<Guid, Guid>
{
    /// <summary>
    /// Конструктор по умолчанию - автоматически генерирует новый Id
    /// </summary>
    protected AuditableEntityGuid()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Конструктор с заданным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    protected AuditableEntityGuid(Guid id)
    {
        Id = id;
    }
}
