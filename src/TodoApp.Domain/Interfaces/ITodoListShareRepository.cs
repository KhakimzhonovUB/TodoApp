using TodoApp.Domain.Entities;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Pagination;

namespace TodoApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория совместного доступа к спискам задач
/// </summary>
public interface ITodoListShareRepository : IRepository<TodoListShare>
{
    /// <summary>
    /// Получить записи о совместном доступе по заданным критериям
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат с пагинацией</returns>
    Task<PagedResult<TodoListShare>> GetSharesAsync(
        TodoListShareRequest request,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверить доступ пользователя к списку
    /// </summary>
    /// <param name="todoListId">Идентификатор списка</param>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="requiredPermission">Требуемый уровень доступа</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>True, если доступ разрешен</returns>
    Task<bool> HasAccessAsync(
        Guid todoListId,
        Guid userId,
        SharePermission requiredPermission,
        CancellationToken cancellationToken = default);
}
