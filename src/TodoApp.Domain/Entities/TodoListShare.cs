using TodoApp.Domain.Common;
using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Entities;

/// <summary>
/// Сущность для управления совместным доступом к спискам задач
/// </summary>
public sealed class TodoListShare : AuditableEntityGuid
{
    /// <summary>
    /// Идентификатор списка задач
    /// </summary>
    public Guid TodoListId { get; private set; }
    
    /// <summary>
    /// Идентификатор пользователя, которому предоставлен доступ
    /// </summary>
    public Guid UserId { get; private set; }
    
    /// <summary>
    /// Уровень доступа
    /// </summary>
    public SharePermission Permission { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к списку задач
    /// </summary>
    public TodoList TodoList { get; private set; } = null!;
    
    // Конструктор для EF Core
    private TodoListShare() { }

    /// <summary>
    /// Создать новую запись о совместном доступе
    /// </summary>
    /// <param name="todoListId">Идентификатор списка задач</param>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="permission">Уровень доступа</param>
    /// <param name="createdBy">Идентификатор создателя</param>
    public TodoListShare(
        Guid todoListId,
        Guid userId,
        SharePermission permission,
        Guid createdBy)
    {
        TodoListId = todoListId;
        UserId = userId;
        Permission = permission;
        
        SetCreatedInfo(createdBy);
    }

    /// <summary>
    /// Изменить уровень доступа
    /// </summary>
    /// <param name="permission">Новый уровень доступа</param>
    /// <param name="updatedBy">Идентификатор пользователя, изменяющего доступ</param>
    public void ChangePermission(SharePermission permission, Guid updatedBy)
    {
        Permission = permission;
        SetUpdatedInfo(updatedBy);
    }

    /// <summary>
    /// Проверить, имеет ли пользователь право только на чтение
    /// </summary>
    /// <returns>True, если пользователь может только читать</returns>
    public bool IsReadOnly =>
        Permission == SharePermission.ReadOnly;
    
    /// <summary>
    /// Проверить, имеет ли пользователь право на запись
    /// </summary>
    /// <returns>True, если пользователь может редактировать</returns>
    public bool CanWrite =>
        Permission == SharePermission.FullAccess;
}
