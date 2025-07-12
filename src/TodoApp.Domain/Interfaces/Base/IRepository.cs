using TodoApp.Domain.Common;
using TodoApp.Domain.Pagination;

namespace TodoApp.Domain.Interfaces;

/// <summary>
/// Базовый интерфейс репозитория
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IRepository<T>
    where T : BaseEntityGuid
{
    /// <summary>
    /// Получить сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Сущность или null, если не найдена</returns>
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить все сущности с пагинацией
    /// </summary>
    /// <param name="request">Параметры пагинации</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат с пагинацией</returns>
    Task<PagedResult<T>> GetPagedAsync(PagedRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    /// <param name="entity">Сущность для добавления</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор добавленной сущности</returns>
    Task<Guid> AddAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Обновить существующую сущность
    /// </summary>
    /// <param name="entity">Сущность для обновления</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор обновленной сущности</returns>
    Task<Guid> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="entity">Сущность для удаления</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор удаленной сущности</returns>
    Task<Guid> DeleteAsync(T entity, CancellationToken cancellationToken = default);
    
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
