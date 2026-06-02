using Microsoft.EntityFrameworkCore;
using RecipeApp.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeApp.Services;

/// <summary>
/// Сервис для работы с меню.
/// </summary>
/// <param name="db">Контекст БД.</param>
public class MenuService(MenuDbContext db)
{
  //private readonly IDbConnection _dbConnection;

  /// <summary>
  /// Получить все меню.
  /// </summary>
  /// <returns>Все меню.</returns>
  public List<Menu> GetMenu()
  {
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

  public async Task<List<Recipe>> GetAllRecipesAsync()
  {
    return null;
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