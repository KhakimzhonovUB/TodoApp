using TodoApp.Domain.Entities;
using TodoApp.Domain.Pagination;

namespace TodoApp.Domain.Interfaces;

/// <summary>
/// Интерфейс репозитория тегов
/// </summary>
public interface ITagRepository : IRepository<Tag>
{
    /// <summary>
    /// Получить теги по заданным критериям
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат с пагинацией или единственный тег при точном поиске</returns>
    Task<PagedResult<Tag>> GetTagsAsync(
        TagRequest request,
        CancellationToken cancellationToken = default);
}
