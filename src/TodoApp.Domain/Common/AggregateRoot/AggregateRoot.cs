namespace TodoApp.Domain.Common;

/// <summary>
/// Базовая реализация корневого агрегата
/// </summary>
public abstract class AggregateRoot : AuditableEntityGuid, IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Коллекция доменных событий, которые должны быть опубликованы
    /// </summary>
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Конструктор по умолчанию - автоматически генерирует новый Id
    /// </summary>
    protected AggregateRoot() { }

    /// <summary>
    /// Конструктор с заданным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор агрегата</param>
    protected AggregateRoot(Guid id) : base(id) { }

    /// <summary>
    /// Добавляет доменное событие к агрегату
    /// </summary>
    /// <param name="domainEvent">Доменное событие</param>
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (domainEvent is null)
            throw new ArgumentNullException(nameof(domainEvent));

        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Удаляет доменное событие из агрегата
    /// </summary>
    /// <param name="domainEvent">Доменное событие</param>
    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        if (domainEvent is null)
            throw new ArgumentNullException(nameof(domainEvent));

        _domainEvents.Remove(domainEvent);
    }

    /// <summary>
    /// Очищает все доменные события агрегата
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    /// Проверяет, есть ли у агрегата доменные события
    /// </summary>
    public bool HasDomainEvents => _domainEvents.Count > 0;
}
