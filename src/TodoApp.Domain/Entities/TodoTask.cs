using TodoApp.Domain.Common;
using TodoApp.Domain.Enums;
using TodoApp.Domain.ValueObjects;
using TaskStatus = TodoApp.Domain.Enums.TaskStatus;

namespace TodoApp.Domain.Entities;

/// <summary>
/// Сущность задачи
/// </summary>
public sealed class TodoTask : AuditableEntityGuid
{
    /// <summary>
    /// Заголовок задачи
    /// </summary>
    public Title Title { get; private set; } = null!;
    
    /// <summary>
    /// Описание задачи
    /// </summary>
    public Description? Description { get; private set; }
    
    /// <summary>
    /// Статус задачи
    /// </summary>
    public TaskStatus Status { get; private set; }
    
    /// <summary>
    /// Приоритет задачи
    /// </summary>
    public TaskPriority Priority { get; private set; }
    
    /// <summary>
    /// Дата выполнения задачи
    /// </summary>
    public DateTime? DueDate { get; private set; }
    
    /// <summary>
    /// Дата завершения задачи
    /// </summary>
    public DateTime? CompletedAt { get; private set; }
    
    /// <summary>
    /// Идентификатор пользователя, назначенного на задачу
    /// </summary>
    public Guid? AssignedUserId { private get; set; }
    
    /// <summary>
    /// Идентификатор списка задач, к которому принадлежит задача
    /// </summary>
    public Guid TodoListId { private get; set; }
    
    /// <summary>
    /// Навигационное свойство к списку задач
    /// </summary>
    public TodoList TodoList { get; private set; } = null!;
    
    /// <summary>
    /// Коллекция тегов задачи
    /// </summary>
    public ICollection<Tag> Tags { get; private set; } = [];
    
    /// <summary>
    /// Коллекция комментариев к задаче
    /// </summary>
    public ICollection<Comment> Comments { get; private set; } = [];
    
    // Конструктор для EF Core
    private TodoTask() { }

    /// <summary>
    /// Создать новую задачу
    /// </summary>
    /// <param name="todoListId">Идентификатор списка задач</param>
    /// <param name="createdBy">Идентификатор создателя</param>
    /// <param name="title">Заголовок задачи</param>
    /// <param name="description">Описание задачи</param>
    /// <param name="priority">Приоритет задачи</param>
    /// <param name="dueDate">Дата выполнения</param>
    public TodoTask(
        Guid todoListId,
        Guid createdBy,
        Title title,
        Description? description = null,
        TaskPriority priority = TaskPriority.Medium,
        DateTime? dueDate = null)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description;
        Priority = priority;
        DueDate = dueDate;
        TodoListId = todoListId;
        
        SetCreatedInfo(createdBy);
    }
    
    /// <summary>
    /// Обновить заголовок задачи
    /// </summary>
    /// <param name="title">Новый заголовок</param>
    /// <param name="updatedBy">Идентификатор пользователя</param>
    public void UpdateTitle(Title title, Guid updatedBy)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));   
        SetUpdatedInfo(updatedBy);
    }

    /// <summary>
    /// Обновить описание задачи
    /// </summary>
    /// <param name="description">Новое описание</param>
    /// <param name="updatedBy">Идентификатор пользователя</param>
    public void UpdateDescription(Description description, Guid updatedBy)
    {
        Description = description;
        SetUpdatedInfo(updatedBy);
    }

    /// <summary>
    /// Изменить статус задачи
    /// </summary>
    /// <param name="status">Новый статус</param>
    /// <param name="updatedBy">Идентификатор пользователя</param>
    public void ChangeStatus(TaskStatus status, Guid updatedBy)
    {
        if (!Status.CanTransitionTo(status))
            throw new InvalidOperationException($"Невозможно изменить статус с '{Status}' на '{status}'");
        
        Status = status;
        if (status == TaskStatus.Completed)
            CompletedAt = DateTime.UtcNow;
        else if (CompletedAt.HasValue)
            CompletedAt = null;
        
        SetUpdatedInfo(updatedBy);
    }

    /// <summary>
    /// Установить приоритет задачи
    /// </summary>
    /// <param name="priority">Новый приоритет</param>
    /// <param name="updatedBy">Идентификатор пользователя</param>
    public void SetPriority(TaskPriority priority, Guid updatedBy)
    {
        Priority = priority;
        SetUpdatedInfo(updatedBy);
    }

    /// <summary>
    /// Установить дату выполнения
    /// </summary>
    /// <param name="dueDate">Дата выполнения</param>
    /// <param name="updatedBy">Идентификатор пользователя</param>
    public void SetDueDate(DateTime dueDate, Guid updatedBy)
    {
        DueDate = dueDate;
        SetUpdatedInfo(updatedBy);
    }

    /// <summary>
    /// Назначить задачу пользователю
    /// </summary>
    /// <param name="assignedUserId">Идентификатор назначаемого пользователя</param>
    /// <param name="updatedBy">Идентификатор пользователя, выполняющего назначение</param>
    public void AssignTo(Guid? assignedUserId, Guid updatedBy)
    {
        AssignedUserId = assignedUserId;
        SetUpdatedInfo(updatedBy);
    }
    
    /// <summary>
    /// Проверить, просрочена ли задача
    /// </summary>
    /// <returns>True, если задача просрочена</returns>
    public bool IsOverdue =>
        DueDate.HasValue && DueDate.Value < DateTime.UtcNow && IsCompleted;
    
    /// <summary>
    /// Проверить, завершена ли задача
    /// </summary>
    /// <returns>True, если задача завершена</returns>
    public bool IsCompleted => Status == TaskStatus.Completed;
}
