using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp.Model;

/// <summary>
/// Блюда.
/// </summary>
public class Dish
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int recipe_id { get; set; }
  public int group_id { get; set; }
  //public int menu_id { get; set; }
  public int? menu_id { get; set; }

  [ForeignKey(nameof(menu_id))]
  public Menu Menu { get; set; }
}