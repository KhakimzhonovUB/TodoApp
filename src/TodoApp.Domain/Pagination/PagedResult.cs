namespace TodoApp.Domain.Pagination;

/// <summary>
/// Результат пагинации
/// </summary>
/// <typeparam name="T">Тип элементов</typeparam>
public sealed class PagedResult<T>
{
    /// <summary>
    /// Элементы текущей страницы
    /// </summary>
    public IReadOnlyList<T> Items { get; }
    
    /// <summary>
    /// Номер текущей страницы
    /// </summary>
    public int PageNumber { get; }
    
    /// <summary>
    /// Размер страницы
    /// </summary>
    public int PageSize { get; }
    
    /// <summary>
    /// Общее количество элементов
    /// </summary>
    public int TotalCount { get; }

    /// <summary>
    /// Общее количество страниц
    /// </summary>
    public int TotalPages =>
        (int)Math.Ceiling(TotalCount / (double)PageSize);
    
    /// <summary>
    /// Есть ли предыдущая страница
    /// </summary>
    public bool HasPreviousPage =>
        PageNumber > 1;
    
    /// <summary>
    /// Есть ли следующая страница
    /// </summary>
    public bool HasNextPage =>
        PageNumber < TotalPages;

    /// <summary>
    /// Создать результат пагинации
    /// </summary>
    /// <param name="items">Элементы текущей страницы</param>
    /// <param name="totalCount">Общее количество элементов</param>
    /// <param name="pageNumber">Номер текущей страницы</param>
    /// <param name="pageSize">Размер страницы</param>
    public PagedResult(
        IEnumerable<T> items,
        int totalCount,
        int pageNumber,
        int pageSize)
    {
        Items = items?.ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(items));
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    /// <summary>
    /// Создать пустой результат
    /// </summary>
    /// <param name="pageNumber">Номер страницы</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <returns>Пустой результат пагинации</returns>
    public static PagedResult<T> Empty(int pageNumber = 1, int pageSize = 10) =>
        new([], 0, pageNumber, pageSize);
}
