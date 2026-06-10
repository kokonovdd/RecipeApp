using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RecipeApp.Model;

/// <summary>
/// Меню.
/// </summary>
public class Menu
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int GroupId { get; set; }
  public DateTime StartDate { get; set; }
  public string Content { get; set; }
  public string ImagePath { get; set; }
  public List<Dish> Dishes { get; set; } = [];
  //public ICollection<Dish> Dishes { get; set; }
}