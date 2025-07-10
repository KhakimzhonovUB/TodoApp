using TodoApp.Domain.Common;
using TodoApp.Domain.ValueObjects;

namespace TodoApp.Domain.Entities;

/// <summary>
/// Сущность списка задач - корневой агрегат
/// </summary>
public sealed class TodoList : AggregateRoot
{
    /// <summary>
    /// Заголовок списка задач
    /// </summary>
    public Title Title { get; private set; } = null!;
    
    /// <summary>
    /// Описание списка задач
    /// </summary>
    public Description? Description { get; private set; }
    
    /// <summary>
    /// Идентификатор владельца списка
    /// </summary>
    public Guid OwnerId { get; private set; }
    
    /// <summary>
    /// Коллекция задач в списке
    /// </summary>
    public ICollection<TodoTask> Tasks { get; private set; } = [];

    /// <summary>
    /// Коллекция пользователей, имеющих доступ к списку
    /// </summary>
    public ICollection<TodoListShare> Shares { get; private set; } = [];
    
    // Конструктор для EF Core
    private TodoList() { }
    
    /// <summary>
    /// Создать новый список задач
    /// </summary>
    /// <param name="ownerId">Идентификатор владельца</param>
    /// <param name="title">Заголовок списка</param>
    /// <param name="description">Описание списка</param>
    public TodoList(
        Guid ownerId,
        Title title,
        Description? description = null)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description;
        OwnerId = ownerId;
    }

    /// <summary>
    /// Обновить заголовок списка
    /// </summary>
    /// <param name="title">Новый заголовок</param>
    /// <param name="updatedBy">Идентификатор пользователя, выполняющего изменение</param>
    public void UpdateTitle(Title title, Guid updatedBy)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        SetUpdatedInfo(updatedBy);
    }

    /// <summary>
    /// Обновить описание списка
    /// </summary>
    /// <param name="description">Новое описание</param>
    /// <param name="updatedBy">Идентификатор пользователя, выполняющего изменение</param>
    public void UpdateDescription(Description? description, Guid updatedBy)
    {
        Description = description;
        SetUpdatedInfo(updatedBy);
    }

    /// <summary>
    /// Добавить задачу в список
    /// </summary>
    /// <param name="task">Задача для добавления</param>
    public void AddTask(TodoTask task)
    {
        ArgumentNullException.ThrowIfNull(task, nameof(task));
        Tasks.Add(task);
    }

    /// <summary>
    /// Удалить задачу из списка
    /// </summary>
    /// <param name="task">Задача для удаления</param>
    public void RemoveTask(TodoTask task)
    {
        ArgumentNullException.ThrowIfNull(task, nameof(task));
        Tasks.Remove(task);
    }
}
