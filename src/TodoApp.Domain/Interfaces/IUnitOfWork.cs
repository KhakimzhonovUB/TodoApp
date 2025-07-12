namespace TodoApp.Domain.Interfaces;

/// <summary>
/// Интерфейс для управления транзакциями и координации работы репозиториев
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Сохранить все изменения в базе данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Количество затронутых записей</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
