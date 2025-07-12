using TodoApp.Domain.Entities;
using TodoApp.Domain.Pagination;

namespace TodoApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория задач
/// </summary>
public interface ITodoTaskRepository : IRepository<TodoTask>
{
    /// <summary>
    /// Получить задачи по заданным критериям
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат с пагинацией</returns>
    Task<PagedResult<TodoTask>> GetTasksAsync(
        TodoTaskRequest request,
        CancellationToken cancellationToken = default);
}
