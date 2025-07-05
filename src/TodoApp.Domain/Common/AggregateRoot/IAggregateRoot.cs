namespace TodoApp.Domain.Common;

/// <summary>
/// Маркерный интерфейс для корневых агрегатов в DDD
/// </summary>
/// <remarks>
/// Корневой агрегат - это единственная точка входа для доступа к объектам внутри агрегата.
/// Все операции с объектами агрегата должны проходить через корневой агрегат.
/// </remarks>
public interface IAggregateRoot
{
    /// <summary>
    /// Коллекция доменных событий, которые должны быть опубликованы
    /// </summary>
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Добавляет доменное событие к агрегату
    /// </summary>
    /// <param name="domainEvent">Доменное событие</param>
    void AddDomainEvent(IDomainEvent domainEvent);

    /// <summary>
    /// Удаляет доменное событие из агрегата
    /// </summary>
    /// <param name="domainEvent">Доменное событие</param>
    void RemoveDomainEvent(IDomainEvent domainEvent);

    /// <summary>
    /// Очищает все доменные события агрегата
    /// </summary>
    void ClearDomainEvents();
}
