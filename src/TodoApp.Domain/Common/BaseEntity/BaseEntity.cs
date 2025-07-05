namespace TodoApp.Domain.Common;

/// <summary>
/// Базовая сущность со свойством Id
/// </summary>
/// <typeparam name="TId">Тип идентификатора</typeparam>
public abstract class BaseEntity<TId> : IEquatable<BaseEntity<TId>>
    where TId : IEquatable<TId>
{
    /// <summary>
    /// Уникальный идентификатор сущности
    /// </summary>
    public TId? Id { get; set; }

    /// <summary>
    /// Проверяет, является ли сущность транзиентной (не сохранена в БД)
    /// </summary>
    public virtual bool IsTransient => Id is null;

    /// <summary>
    /// Переопределение равенства для сущностей
    /// </summary>
    public virtual bool Equals(BaseEntity<TId>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (IsTransient || other.IsTransient)
            return false;
        
        return Id!.Equals(other.Id);
    }

    /// <summary>
    /// Переопределение равенства для объектов
    /// </summary>
    public override bool Equals(object? obj) =>
        Equals(obj as BaseEntity<TId>);

    /// <summary>
    /// Переопределение получения хеш-кода
    /// </summary>
    public override int GetHashCode()
    {
        if (IsTransient)
            return base.GetHashCode();

        return Id!.GetHashCode();
    }

    /// <summary>
    /// Оператор равенства
    /// </summary>
    public static bool operator ==(BaseEntity<TId>? left, BaseEntity<TId>? right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;
        
        return left.Equals(right);
    }

    /// <summary>
    /// Оператор неравенства
    /// </summary>
    public static bool operator !=(BaseEntity<TId>? left, BaseEntity<TId>? right) =>
        !(left == right);
    
    /// <summary>
    /// Строковое представление сущности
    /// </summary>
    public override string ToString() =>
        $"{GetType().Name} [Id={Id?.ToString() ?? "null"}]";
}
