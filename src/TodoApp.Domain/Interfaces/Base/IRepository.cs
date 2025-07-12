using TodoApp.Domain.Common;
using TodoApp.Domain.Pagination;

namespace TodoApp.Domain.Interfaces;

/// <summary>
/// Базовый интерфейс репозитория
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IRepository<TEntity>
    where TEntity : BaseEntity<Guid>
{
    /// <summary>
    /// Получить сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Сущность или null, если не найдена</returns>
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    /// <param name="entity">Сущность для добавления</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор добавленной сущности</returns>
    Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Обновить существующую сущность
    /// </summary>
    /// <param name="entity">Сущность для обновления</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор обновленной сущности</returns>
    Task<Guid> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="entity">Сущность для удаления</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор удаленной сущности</returns>
    Task<Guid> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Удалить сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>True, если сущность была удалена; False, если сущность не найдена</returns>
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверить существование сущности по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>True, если сущность существует</returns>
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
