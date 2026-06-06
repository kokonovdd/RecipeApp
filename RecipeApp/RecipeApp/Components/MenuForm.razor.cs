using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RecipeApp.Model;
using RecipeApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Components;

/// <summary>
/// Компонент для отображения карточки рецепта.
/// </summary>
public partial class MenuForm
{
  #region Поля и свойства

  /// <summary>
  /// URL превью изображения рецепта.
  /// </summary>
  private string? imagePreviewUrl;

  /// <summary>
  /// Выбранный для изображения файл.
  /// </summary>
  private IBrowserFile? selectedFile;

  /// <summary>
  /// Отображаемый рецепт.
  /// </summary>
  [Parameter]
  public Menu Menu { get; set; } = new ();

  /// <summary>
  /// Обработчик события на сохранение.
  /// </summary>
  [Parameter]
  public EventCallback OnSave { get; set; }

  /// <summary>
  /// Обработчик события отмены.
  /// </summary>
  [Parameter]
  public EventCallback OnCancel { get; set; }

  /// <summary>
  /// Признак того, что рецепт открыт на редактирование.
  /// </summary>
  [Parameter]
  public bool IsEditMode { get; set; }

  #endregion

  #region Базовый класс

  /// <inheritdoc/>
  protected override void OnInitialized()
  {
    this.imagePreviewUrl = this.Menu.ImagePath;
  }

  #endregion

  #region Методы

  private static void HandleInvalidSubmit()
  {
  }

  private void AddDish()
  {
    this.NavigationManager.NavigateTo("/recipes/create");
  }

  private void AddDishes()
  {
    
  }

  private void RemoveDish(Dish dish)
  {
    this.Menu.Dishes.Remove(dish);
  }

  private int? SelectedRecipeId { get; set; }

  private void AddSelectedRecipe()
  {
    if (SelectedRecipeId.HasValue)
    {
      // Получите рецепт по ID
      var recipe = RecipeService.GetRecipes().FirstOrDefault(r => r.Id == SelectedRecipeId.Value);
      if (recipe != null)
      {
        var dish = new Dish { Name = recipe.Title};
        Menu.Dishes.Add(dish);
      }
    }
  }

  private async Task Save()
  {
    await this.OnSave.InvokeAsync();
  }

  private async Task HandleFileSelected(InputFileChangeEventArgs e)
  {
    const string UploadsFolder = "uploads";
    this.selectedFile = e.File;

    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(this.selectedFile.Name)}";
    var savePath = Path.Combine(this.Env.WebRootPath, UploadsFolder, fileName);

    await using var stream = File.Create(savePath);
    await this.selectedFile.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(stream);

    this.Menu.ImagePath = $"{UploadsFolder}/{fileName}";
    this.imagePreviewUrl = this.Menu.ImagePath;
  }

  #endregion
}