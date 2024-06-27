using System;
using System.Collections.Generic;
using System.Windows;

namespace RecipeAppWPF
{
    public partial class ScaleRecipeWindow : Window
    {
        private List<Recipe> recipes;

        public ScaleRecipeWindow(List<Recipe> recipes)
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

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a recipe to scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedRecipe = (Recipe)RecipeComboBox.SelectedItem;

            if (!double.TryParse(ScalingFactorTextBox.Text, out double scalingFactor))
            {
                MessageBox.Show("Please enter a valid scaling factor (e.g., 0.5, 2).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            selectedRecipe.ScaleRecipe(scalingFactor);

            MessageBox.Show("Recipe scaled successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
