using System.Collections.Generic;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic to add a new recipe
            var newRecipeWindow = new AddRecipeWindow(recipes);
            newRecipeWindow.ShowDialog();
            UpdateRecipeList();
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Logic to display all recipes
            UpdateRecipeList();
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic to scale a recipe
            var scaleRecipeWindow = new ScaleRecipeWindow(recipes);
            scaleRecipeWindow.ShowDialog();
            UpdateRecipeList();
        }

        private void ResetRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic to reset recipe quantities
            var resetRecipeWindow = new ResetQuantitiesWindow(recipes);
            resetRecipeWindow.ShowDialog();
            UpdateRecipeList();
        }

        private void ClearRecipes_Click(object sender, RoutedEventArgs e)
        {
            recipes.Clear();
            UpdateRecipeList();
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            var filterRecipesWindow = new FilterRecipesWindow(recipes);
            if (filterRecipesWindow.ShowDialog() == true)
            {
                RecipesListBox.Items.Clear();
                foreach (var recipe in filterRecipesWindow.FilteredRecipes)
                {
                    RecipesListBox.Items.Add(recipe.RecipeName);
                }
            }
        }

        private void UpdateRecipeList()
        {
            RecipesListBox.Items.Clear();
            foreach (var recipe in recipes)
            {
                RecipesListBox.Items.Add(recipe.RecipeName);
            }
        }
    }
}
