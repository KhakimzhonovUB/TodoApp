using TodoApp.Domain.Entities;
using TodoApp.Domain.Pagination;

namespace TodoApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория комментариев
/// </summary>
public interface ICommentRepository : IRepository<Comment>
{
    /// <summary>
    /// Получить комментарии по заданным критериям
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат с пагинацией</returns>
    Task<PagedResult<Comment>> GetCommentsAsync(
        CommentRequest request,
        CancellationToken cancellationToken = default);
}
