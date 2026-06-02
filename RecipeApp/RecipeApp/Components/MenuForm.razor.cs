using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RecipeApp.Model;
using RecipeApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
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

  /// <summary>
  /// Добавить ингредиент.
  /// </summary>
  private void AddDish()
  {
    this.Menu.Dishes.Add(new Dish());
  }

  /// <summary>
  /// Удалить выбранный ингредиент.
  /// </summary>
  /// <param name="ingredient">Выбранный ингредиент.</param>
  private void RemoveDish(Dish dish)
  {
    this.Menu.Dishes.Remove(dish);
  }

  private int? SelectedRecipeId { get; set; }
  public List<Recipe> Recipes { get; set; } = new List<Recipe>();

  protected override async Task OnInitializedAsync()
  {
    Recipes = null; //await MenuService.GetAllRecipesAsync();
  }

  /// <summary>
  /// Сохранить рецепт.
  /// </summary>
  private async Task Save()
  {
    await this.OnSave.InvokeAsync();
  }

  /// <summary>
  /// Обработчик для выбора файла для изображения рецепта.
  /// </summary>
  /// <param name="e">Аргументы события.</param>
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