namespace TodoApp.Domain.Pagination;

/// <summary>
/// Базовый запрос для пагинации с поиском и сортировкой
/// </summary>
public class PagedRequest
{
    private const int MaxPageSize = 100;
    private const int DefaultPageSize = 10;
    
    private int _pageNumber = 1;
    private int _pageSize = DefaultPageSize;

    /// <summary>
    /// Номер страницы (начинается с 1)
    /// </summary>
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    /// <summary>
    /// Размер страницы (количество элементов на странице)
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value switch
        {
            < 1 => DefaultPageSize,
            > MaxPageSize => MaxPageSize,
            _ => value
        };
    }
    
    /// <summary>
    /// Строка поиска
    /// </summary>
    public string? SearchTerm { get; set; }
    
    /// <summary>
    /// Поле для сортировки
    /// </summary>
    public string? SortBy { get; set; }
    
    /// <summary>
    /// Направление сортировки
    /// </summary>
    public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    
    /// <summary>
    /// Вычисляет количество записей для пропуска
    /// </summary>
    public int Skip 
        => (PageNumber - 1) * PageSize;
    
    /// <summary>
    /// Проверяет, задан ли поиск
    /// </summary>
    public bool HasSearch =>
        !string.IsNullOrWhiteSpace(SearchTerm);
    
    /// <summary>
    /// Проверяет, задана ли сортировка
    /// </summary>
    public bool HasSorting =>
        !string.IsNullOrWhiteSpace(SortBy);

    /// <summary>
    /// Нормализует строку поиска (обрезает пробелы)
    /// </summary>
    public string? GetNormalizedSearchTerm() =>
        SearchTerm?.Trim();
}
