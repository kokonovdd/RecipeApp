using Microsoft.EntityFrameworkCore;
using RecipeApp.Model;

namespace RecipeApp.Services;

/// <summary>
/// DBContext для рецептов.
/// </summary>
/// <param name="options">Настройка контекста.</param>
public class MenuDbContext(DbContextOptions<MenuDbContext> options)
  : DbContext(options)
{

  /// <summary>
  /// меню
  /// </summary>
  public DbSet<Menu> Dish { get; set; }

}