namespace RecipeApp.Model;

/// <summary>
/// Блюда.
/// </summary>
public class Dish
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int recipeid { get; set; }
  public int groupid { get; set; }
  public int menuid { get; set; }
  public Menu Menu { get; set; }
}