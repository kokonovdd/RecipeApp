using Microsoft.EntityFrameworkCore;
using RecipeApp.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
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
  public List<Menu> GetMenu()
  {
    // Проверяем, есть ли вообще меню в базе данных
    if (!db.Menu.Any())
      return new List<Menu>();
   else
      return db.Menu
        .Include(m => m.Dishes)
        .ToList();
  }

  public Menu? GetMenu(int id)
  {
    return db.Menu
      .FirstOrDefault(d => d.Id == id);
  }

  public void SaveDbContext()
  {
    db.SaveChanges();
  }

  public void AddMenu(Menu menu)
  {
    db.Menu.Add(menu);
    db.SaveChanges();
  }

  public void DeleteMenu(int id)
  {
    var entity = this.GetMenu(id);
    if (entity != null)
    {
      db.Menu.Remove(entity);
      db.SaveChanges();
    }
  }
}