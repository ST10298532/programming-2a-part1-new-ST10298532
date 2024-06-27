using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class FilterRecipesWindow : Window
    {
        private List<Recipe> recipes;
        public List<Recipe> FilteredRecipes { get; private set; }

        public FilterRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientTextBox.Text.ToLower();
            string foodGroup = FoodGroupTextBox.Text.ToLower();
            double.TryParse(MaxCaloriesTextBox.Text, out double maxCalories);

            FilteredRecipes = recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.ToLower().Contains(ingredient))) &&
                (string.IsNullOrEmpty(foodGroup) || r.FoodGroups.Any(fg => fg.ToLower().Contains(foodGroup))) &&
                (maxCalories == 0 || r.CalculateTotalCalories() <= maxCalories)).ToList();

            MessageBox.Show($"Filtered {FilteredRecipes.Count} recipes.");
            this.DialogResult = true;
            this.Close();
        }
    }
}
