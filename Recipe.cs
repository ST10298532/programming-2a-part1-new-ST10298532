using System;
using System.Collections.Generic;

namespace RecipeAppWPF
{
    public delegate void CaloriesExceededHandler(string recipeName);

    public class Recipe
    {
        public string RecipeName { get; set; }
        public List<string> Ingredients { get; set; }
        public List<double> Quantities { get; set; }
        public List<string> Units { get; set; }
        public List<string> Steps { get; set; }
        public List<double> OriginalQuantities { get; set; }
        public List<double> Calories { get; set; }
        public List<string> FoodGroups { get; set; }

        public static event CaloriesExceededHandler CaloriesExceededEvent;

        public Recipe()
        {
            Ingredients = new List<string>();
            Quantities = new List<double>();
            Units = new List<string>();
            Steps = new List<string>();
            OriginalQuantities = new List<double>();
            Calories = new List<double>();
            FoodGroups = new List<string>();
        }

        public void EnterRecipeDetails()
        {
            // GUI-related input handling to be implemented
        }

        public void DisplayRecipe()
        {
            // GUI-related output handling to be implemented
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            for (int i = 0; i < Ingredients.Count; i++)
            {
                totalCalories += Calories[i];
            }
            return totalCalories;
        }

        public void ScaleRecipe(double scalingFactor)
        {
            for (int i = 0; i < Quantities.Count; i++)
            {
                Quantities[i] *= scalingFactor;
            }
        }

        public void ResetQuantities()
        {
            Quantities.Clear();
            Quantities.AddRange(OriginalQuantities);
        }

        public static void DisplayRecipes(List<Recipe> recipes)
        {
            // GUI-related output handling to be implemented
        }

        public static void ScaleRecipe(List<Recipe> recipes)
        {
            // GUI-related input handling to be implemented
        }

        public static void ResetRecipeQuantities(List<Recipe> recipes)
        {
            // GUI-related input handling to be implemented
        }

        public static void ClearAllRecipes(List<Recipe> recipes)
        {
            recipes.Clear();
        }
    }
}
