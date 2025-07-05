namespace TodoApp.Domain.Common;

/// <summary>
/// Базовая сущность с полями аудита
/// </summary>
/// <typeparam name="TId">Тип идентификатора сущности</typeparam>
/// <typeparam name="TUserId">Тип идентификатора пользователя</typeparam>
public abstract class AuditableEntity<TId, TUserId> : BaseEntity<TId>
    where TId : IEquatable<TId>
    where TUserId : IEquatable<TUserId>
{
    /// <summary>
    /// Дата и время создания сущности
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Дата и время последнего обновления сущности (null, если сущность не была обновлена)
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя, создавшего сущность
    /// </summary>
    public TUserId? CreatedBy { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя, последним обновившего сущность
    /// </summary>
    public TUserId? UpdatedBy { get; set; }

    /// <summary>
    /// Проверяет, была ли сущность изменена после создания
    /// </summary>
    public bool IsModified => UpdatedAt is not null;

    /// <summary>
    /// Устанавливает информацию о создании сущности
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    public virtual void SetCreatedInfo(TUserId? userId = default)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedBy = userId;
    }
    
    /// <summary>
    /// Устанавливает информацию об обновлении сущности
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    public virtual void SetUpdatedInfo(TUserId? userId = default)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = userId;
    }
    
    /// <summary>
    /// Переопределение строкового представления с информацией об аудите
    /// </summary>
    public override string ToString()
    {
        var updatedInfo = UpdatedAt.HasValue ? $", Updated={UpdatedAt:yyyy-MM-dd HH:mm:ss}" : "";
        return $"{base.ToString()} [Created={CreatedAt:yyyy-MM-dd HH:mm:ss}{updatedInfo}]";
    }
}
