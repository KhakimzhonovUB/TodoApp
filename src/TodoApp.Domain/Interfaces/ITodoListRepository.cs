using TodoApp.Domain.Entities;
using TodoApp.Domain.Pagination;

namespace TodoApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория списков задач
/// </summary>
public interface ITodoListRepository : IRepository<TodoList>
{
    /// <summary>
    /// Получить списки задач по заданным критериям
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат с пагинацией</returns>
    Task<PagedResult<TodoList>> GetTodoListsAsync(
        TodoListRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить список задач с задачами
    /// </summary>
    /// <param name="id">Идентификатор списка</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список с задачами или null</returns>
    Task<TodoList?> GetWithTasksAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}
