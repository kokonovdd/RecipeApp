using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Model;

namespace RecipeApp.Services;

/// <summary>
/// Сервис для работы с рецептами.
/// </summary>
/// <param name="db">Контекст БД.</param>
public class MenuService(MenuDbContext db)
{
  /// <summary>
  /// Получить все меню.
  /// </summary>
  /// <returns>Все меню.</returns>
  public List<Menu> GetMenu()
  {
    /*return db.Dish
      .Include(r => r.Dish)
      .ToList();*/
    return null;
  }

  /// <summary>
  /// Получить меню.
  /// </summary>
  /// <param name="id">ИД меню.</param>
  /// <returns>Найденный меню. Иначе <c>null</c>.</returns>
  public Menu? GetMenu(int id)
  {
    return db.Dish
      .FirstOrDefault(r => r.Id == id);
  }

  /// <summary>
  /// Сохранить изменения.
  /// </summary>
  public void SaveDbContext()
  {
    db.SaveChanges();
  }

  /// <summary>
  /// Добавить меню.
  /// </summary>
  /// <param name="menuinfo">меню, которое нужно добавить.</param>
  public void AddMenu(Menu MenuInfo)
  {
    db.Dish.Add(MenuInfo);
    db.SaveChanges();
  }

  /// <summary>
  /// Удалить меню.
  /// </summary>
  /// <param name="id">ИД удаляемого меню.</param>
  public void DeleteMenu(int id)
  {
    var entity = this.GetMenu(id);
    if (entity != null)
    {
      db.Dish.Remove(entity);
      db.SaveChanges();
    }
  }
}