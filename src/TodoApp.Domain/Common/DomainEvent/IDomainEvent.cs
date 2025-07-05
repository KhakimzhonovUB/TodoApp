namespace TodoApp.Domain.Common;

/// <summary>
/// Интерфейс доменного события
/// </summary>
/// <remarks>
/// Доменные события представляют важные бизнес-события, которые произошли в домене.
/// Они используются для уведомления других частей системы о произошедших изменениях.
/// </remarks>
public interface IDomainEvent
{
    /// <summary>
    /// Уникальный идентификатор события
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Дата и время возникновения события
    /// </summary>
    DateTime OccurredAt { get; }
}
