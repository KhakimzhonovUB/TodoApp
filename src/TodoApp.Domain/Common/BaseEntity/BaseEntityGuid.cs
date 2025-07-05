namespace TodoApp.Domain.Common;

/// <summary>
/// Базовая сущность с идентификатором типа Guid
/// </summary>
public abstract class BaseEntityGuid : BaseEntity<Guid>
{
    /// <summary>
    /// Конструктор по умолчанию - автоматически генерирует новый Id
    /// </summary>
    protected BaseEntityGuid()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Конструктор с заданным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    protected BaseEntityGuid(Guid id)
    {
        Id = id;
    }
}
