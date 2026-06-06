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
  public List<Menu> GetMenu()
  {
    return null;/*db.Menu
      .Include(d => d.Name)
      .ToList();*/
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

  public void AddMenu(Menu MenuInfo)
  {
    db.Menu.Add(MenuInfo);
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