using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class AddRecipeWindow : Window
    {
        private List<Recipe> recipes;
        private List<IngredientControl> ingredientControls;
        private List<TextBox> stepTextBoxes;

        public AddRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            ingredientControls = new List<IngredientControl>();
            stepTextBoxes = new List<TextBox>();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var ingredientControl = new IngredientControl();
            IngredientsPanel.Children.Add(ingredientControl);
            ingredientControls.Add(ingredientControl);
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var stepTextBox = new TextBox { Margin = new Thickness(5) };
            StepsPanel.Children.Add(stepTextBox);
            stepTextBoxes.Add(stepTextBox);
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            var recipe = new Recipe
            {
                RecipeName = RecipeNameTextBox.Text
            };

            foreach (var control in ingredientControls)
            {
                // Example assuming IngredientControl has properties like IngredientName, Quantity, Unit, etc.
                // Replace with actual properties from IngredientControl class
                recipe.Ingredients.Add(control.IngredientName); // Example property
                recipe.Quantities.Add(control.Quantity); // Example property
                recipe.Units.Add(control.Unit); // Example property
                // Add other properties as needed
            }

            foreach (var stepTextBox in stepTextBoxes)
            {
                recipe.Steps.Add(stepTextBox.Text);
            }

            recipes.Add(recipe);
            MessageBox.Show("Recipe added successfully!");
            this.Close();
        }
    }
}
