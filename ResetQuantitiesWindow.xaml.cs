using System.Collections.Generic;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class ResetQuantitiesWindow : Window
    {
        private List<Recipe> recipes;

        public ResetQuantitiesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;

            // Populate ComboBox with recipe names
            foreach (var recipe in recipes)
            {
                RecipeComboBox.Items.Add(recipe);
            }

            RecipeComboBox.SelectedIndex = 0; // Select the first recipe by default
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a recipe to reset quantities.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedRecipe = (Recipe)RecipeComboBox.SelectedItem;

            selectedRecipe.ResetQuantities();

            MessageBox.Show("Quantities reset successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
