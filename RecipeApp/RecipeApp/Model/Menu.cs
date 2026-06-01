using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RecipeApp.Model;

/// <summary>
/// Рецепт.
/// </summary>
public class Menu
{
  /// <summary>
  /// ИД рецепта.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Название рецепта.
  /// </summary>
  [Required(ErrorMessage = "Название обязательно")]
  public string Title { get; set; } = string.Empty;

  /// <summary>
  /// Содержимое рецепта.
  /// </summary>
  public string Content { get; set; } = string.Empty;

  /// <summary>
  /// Содержимое рецепта в HTML.
  /// </summary>
  [NotMapped]
  public string ContentHtml => Markdig.Markdown.ToHtml(this.Content);

  /// <summary>
  /// Путь к изображению рецепта.
  /// </summary>
  public string? ImagePath { get; set; }

  /// <summary>
  /// Ингредиенты меню.
  /// </summary>
  public List<Dish> Dish { get; set; } = [];
}