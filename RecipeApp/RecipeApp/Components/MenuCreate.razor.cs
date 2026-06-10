using System.Threading.Tasks;
using RecipeApp.Model;

namespace RecipeApp.Components;

/// <summary>
/// Компонента для создания рецепта.
/// </summary>
public partial class MenuCreate
{
  #region Поля и свойства

  private readonly Menu _menu = new ()
  {
    Dishes = []
  };

  #endregion

  #region Методы

  private Task Save()
  {
    this.MenuService.AddMenu(this._menu);
    this.NavigationManager.NavigateTo("/");

    return Task.CompletedTask;
  }

  private void Cancel()
  {
    this.NavigationManager.NavigateTo("/");
  }

  #endregion
}