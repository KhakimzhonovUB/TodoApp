namespace TodoApp.Domain.Common;

/// <summary>
/// Базовая реализация доменного события
/// </summary>
public abstract class BaseDomainEvent : IDomainEvent
{
    /// <summary>
    /// Уникальный идентификатор события
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Дата и время возникновения события
    /// </summary>
    public DateTime OccurredAt { get; } = DateTime.UtcNow;

    /// <summary>
    /// Конструктор по умолчанию
    /// </summary>
    protected BaseDomainEvent() { }
}
