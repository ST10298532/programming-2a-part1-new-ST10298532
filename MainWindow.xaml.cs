using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handlers for menu options
        private void EnterNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            EnterRecipeWindow enterRecipeWindow = new EnterRecipeWindow();
            enterRecipeWindow.Owner = this;
            enterRecipeWindow.ShowDialog();
            if (enterRecipeWindow.DialogResult == true)
            {
                recipes.Add(enterRecipeWindow.NewRecipe);
            }
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DisplayRecipesPage(recipes);
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ScaleRecipePage(recipes);
        }

        private void ResetRecipeQuantities_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ResetRecipeQuantitiesPage(recipes);
        }

        private void ClearAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            recipes.Clear();
            MessageBox.Show("All recipes cleared successfully!", "Recipe App", MessageBoxButton.OK, MessageBoxImage.Information);
            MainContent.Content = null;
        }

        private void GenerateMenuPieChart_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a method to select multiple recipes and calculate food group percentages
            var selectedRecipes = recipes.Where(r => r.IsSelectedForMenu).ToList();
            if (selectedRecipes.Count > 0)
            {
                // Calculate percentages and display pie chart
                List<(string FoodGroup, double Percentage)> percentages = CalculateFoodGroupPercentages(selectedRecipes);
                MainContent.Content = new MenuPieChartPage(percentages);
            }
            else
            {
                MessageBox.Show("No recipes selected for menu.", "Recipe App", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private List<(string, double)> CalculateFoodGroupPercentages(List<Recipe> selectedRecipes)
        {
            // Calculate percentages here based on selected recipes
            // Example calculation, adjust as per your actual logic
            Dictionary<string, double> groupTotals = new Dictionary<string, double>();
            double totalCalories = 0;

            foreach (var recipe in selectedRecipes)
            {
                foreach (var foodGroup in recipe.FoodGroups)
                {
                    if (groupTotals.ContainsKey(foodGroup))
                    {
                        groupTotals[foodGroup] += recipe.CalculateTotalCalories();
                    }
                    else
                    {
                        groupTotals[foodGroup] = recipe.CalculateTotalCalories();
                    }
                    totalCalories += recipe.CalculateTotalCalories();
                }
            }

            List<(string, double)> percentages = new List<(string, double)>();
            foreach (var group in groupTotals)
            {
                double percentage = (group.Value / totalCalories) * 100;
                percentages.Add((group.Key, percentage));
            }

            return percentages;
        }
    }
}
