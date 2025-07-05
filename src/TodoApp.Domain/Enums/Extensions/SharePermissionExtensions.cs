namespace TodoApp.Domain.Enums;

/// <summary>
/// Методы расширения для работы с SharePermission
/// </summary>
public static class SharePermissionExtensions
{
    /// <summary>
    /// Получить отображаемое имя права доступа
    /// </summary>
    /// <param name="permission">Право доступа</param>
    /// <returns>Отображаемое имя права доступа</returns>
    public static string GetDisplayName(this SharePermission permission) =>
        permission switch
        {
            SharePermission.ReadOnly => "Read Only",
            SharePermission.FullAccess => "Full Access",
            _ => throw new ArgumentOutOfRangeException(
                nameof(permission), permission, "Неизвестное право доступа")
        };
    
    /// <summary>
    /// Получить описание права доступа
    /// </summary>
    /// <param name="permission">Право доступа</param>
    /// <returns>Описание права доступа</returns>
    public static string GetDescription(this SharePermission permission) =>
        permission switch
        {
            SharePermission.ReadOnly => "Пользователь может только просматривать список задач и их содержимое",
            SharePermission.FullAccess => "Пользователь может просматривать, создавать, редактировать и удалять задачи",
            _ => throw new ArgumentOutOfRangeException(
                nameof(permission), permission, "Неизвестное право доступа")
        };
}
