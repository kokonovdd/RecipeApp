
using Microsoft.EntityFrameworkCore;
using RecipeApp.Model;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RecipeApp.Services;

public class DishService(MenuDbContext db)
{
  public List<Dish> GetDishes() => (List<Dish>)db.Dishes
      .Include(r => r.Name)
      .ToList();
}
