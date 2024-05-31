using System;
using System.Collections.Generic;

namespace RecipeApp
{
    // Class representing the Recipe Application
    class RecipeApp
    {
        static void Main(string[] args)
        {
            // Create a list to store the recipes
            List<Recipe> recipes = new List<Recipe>();

            // Subscribe to the CaloriesExceededEvent
            Recipe.CaloriesExceededEvent += Recipe_CaloriesExceededEventHandler;

            // Start the main program loop
            while (true)
            {
                // Display the menu options
                Console.WriteLine("\x1b[93m1. Enter a new recipe\x1b[0m");
                Console.WriteLine("\x1b[93m2. Display recipes\x1b[0m");
                Console.WriteLine("\x1b[93m3. Scale a recipe\x1b[0m");
                Console.WriteLine("\x1b[93m4. Reset a recipe's quantities\x1b[0m");
                Console.WriteLine("\x1b[93m5. Clear all recipes\x1b[0m");
                Console.WriteLine("\x1b[93m6. Exit\x1b[0m");

                // Prompt the user for their choice
                Console.Write("\x1b[94mEnter your choice: \x1b[0m");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                // Handle the user's choice
                switch (choice)
                {
                    case 1:
                        // Enter a new recipe
                        Recipe newRecipe = new Recipe();
                        newRecipe.EnterRecipeDetails();
                        recipes.Add(newRecipe);
                        Console.WriteLine("\x1b[92mRecipe added successfully!\x1b[0m");
                        Console.WriteLine();
                        break;
                    case 2:
                        // Display the recipes
                        Recipe.DisplayRecipes(recipes);
                        Console.WriteLine();
                        break;
                    case 3:
                        // Scale a recipe
                        Recipe.ScaleRecipe(recipes);
                        Console.WriteLine();
                        break;
                    case 4:
                        // Reset a recipe's quantities
                        Recipe.ResetRecipeQuantities(recipes);
                        Console.WriteLine();
                        break;
                    case 5:
                        // Clear all recipes
                        Recipe.ClearAllRecipes(recipes);
                        Console.WriteLine();
                        break;
                    case 6:
                        // Exit the program
                        Environment.Exit(0);
                        break;
                    default:
                        // Handle an invalid choice
                        Console.WriteLine("\x1b[91mInvalid choice. Please try again.\x1b[0m");
                        Console.WriteLine();
                        break;
                }
            }
        }

        // Event handler for when a recipe exceeds 300 calories
        static void Recipe_CaloriesExceededEventHandler(string recipeName)
        {
            Console.WriteLine($"\x1b[91mWarning: Total calories for recipe '{recipeName}' exceed 300!\x1b[0m");
        }
    }

    // Delegate for notifying when a recipe exceeds 300 calories
    delegate void CaloriesExceededHandler(string recipeName);

    // Class representing a Recipe
    class Recipe
    {
        public string RecipeName { get; set; }
        public List<string> Ingredients { get; set; }
        public List<double> Quantities { get; set; }
        public List<string> Units { get; set; }
        public List<string> Steps { get; set; }
        public List<double> OriginalQuantities { get; set; }
        public List<double> Calories { get; set; }
        public List<string> FoodGroups { get; set; }

        // Event for when a recipe exceeds 300 calories
        public static event CaloriesExceededHandler CaloriesExceededEvent;

        // Constructor
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

        // Method to enter the recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("\x1b[94mEnter the name of the recipe: \x1b[0m");
            RecipeName = Console.ReadLine();

            Console.Write("\x1b[94mEnter the number of ingredients: \x1b[0m");
            int numIngredients = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"\x1b[94mEnter the name of ingredient {i + 1}: \x1b[0m");
                Ingredients.Add(Console.ReadLine());

                Console.Write($"\x1b[94mEnter the quantity of ingredient {i + 1}: \x1b[0m");
                Quantities.Add(Convert.ToDouble(Console.ReadLine()));

                Console.Write($"\x1b[94mEnter the unit of ingredient {i + 1}: \x1b[0m");
                Units.Add(Console.ReadLine());

                Console.Write($"\x1b[94mEnter the number of calories for ingredient {i + 1}: \x1b[0m");
                Calories.Add(Convert.ToDouble(Console.ReadLine()));

                Console.Write($"\x1b[94mEnter the food group for ingredient {i + 1}: \x1b[0m");
                FoodGroups.Add(Console.ReadLine());
            }

            Console.Write("\x1b[94mEnter the number of steps: \x1b[0m");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"\x1b[94mEnter step {i + 1}: \x1b[0m");
                Steps.Add(Console.ReadLine());
            }

            // Store the original quantities for reset functionality
            OriginalQuantities.AddRange(Quantities);
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"\x1b[1m\x1b[95m{RecipeName}\x1b[0m");
            Console.WriteLine("\x1b[1m\x1b[95mIngredients:\x1b[0m");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Console.WriteLine($"\x1b[93m{Quantities[i]} {Units[i]} of {Ingredients[i]} ({Calories[i]} calories) - Food Group: {FoodGroups[i]}\x1b[0m");
            }
            Console.WriteLine("\x1b[1m\x1b[95mSteps:\x1b[0m");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"\x1b[93m{i + 1}. {Steps[i]}\x1b[0m");
            }
            Console.WriteLine();

            // Calculate and display the total calories
            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");

            // Notify if total calories exceed 300
            if (totalCalories > 300)
            {
                CaloriesExceededEvent?.Invoke(RecipeName);
            }
        }

        // Method to calculate the total calories of the recipe
        private double CalculateTotalCalories()
        {
            double totalCalories = 0;
            for (int i = 0; i < Ingredients.Count; i++)
            {
                totalCalories += Calories[i];
            }
            return totalCalories;
        }

        // Method to scale the recipe
        public void ScaleRecipe(double scalingFactor)
        {
            for (int i = 0; i < Quantities.Count; i++)
            {
                Quantities[i] *= scalingFactor;
            }
        }

        // Method to reset the recipe to its original quantities
        public void ResetQuantities()
        {
            Quantities.Clear();
            Quantities.AddRange(OriginalQuantities);
        }

        // Method to display all recipes
        public static void DisplayRecipes(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\x1b[91mNo recipes available.\x1b[0m");
            }
            else
            {
                Console.WriteLine("\x1b[1m\x1b[95mRecipes:\x1b[0m");
                Console.WriteLine("\x1b[93m0. Display recipes in alphabetical order\x1b[0m");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"\x1b[93m{i + 1}. {recipes[i].RecipeName}\x1b[0m");
                }
                Console.Write("\x1b[94mEnter the number of the recipe you want to display: \x1b[0m");
                int recipeIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                if (recipeIndex == -1)
                {
                    SortRecipes(recipes);
                    for (int i = 0; i < recipes.Count; i++)
                    {
                        Console.WriteLine($"\x1b[93m{i + 1}. {recipes[i].RecipeName}\x1b[0m");
                    }
                    Console.Write("\x1b[94mEnter the number of the recipe you want to display: \x1b[0m");
                    recipeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                }

                if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                {
                    recipes[recipeIndex].DisplayRecipe();
                }
                else
                {
                    Console.WriteLine("\x1b[91mInvalid recipe number.\x1b[0m");
                }
            }
        }

        // Method to sort recipes alphabetically
        private static void SortRecipes(List<Recipe> recipes)
        {
            recipes.Sort((a, b) => string.Compare(a.RecipeName, b.RecipeName, StringComparison.OrdinalIgnoreCase));
        }

        // Method to scale a recipe
        public static void ScaleRecipe(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\x1b[91mNo recipes available.\x1b[0m");
            }
            else
            {
                Console.WriteLine("\x1b[1m\x1b[95mRecipes:\x1b[0m");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"\x1b[93m{i + 1}. {recipes[i].RecipeName}\x1b[0m");
                }
                Console.Write("\x1b[94mEnter the number of the recipe you want to scale: \x1b[0m");
                int recipeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                {
                    Console.Write("\x1b[94mEnter the scaling factor (0.5, 2, or 3): \x1b[0m");
                    double scalingFactor = Convert.ToDouble(Console.ReadLine());
                    recipes[recipeIndex].ScaleRecipe(scalingFactor);
                    Console.WriteLine("\x1b[92mRecipe scaled successfully!\x1b[0m");
                }
                else
                {
                    Console.WriteLine("\x1b[91mInvalid recipe number.\x1b[0m");
                }
            }
        }

        // Method to reset a recipe's quantities
        public static void ResetRecipeQuantities(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\x1b[91mNo recipes available.\x1b[0m");
            }
            else
            {
                Console.WriteLine("\x1b[1m\x1b[95mRecipes:\x1b[0m");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"\x1b[93m{i + 1}. {recipes[i].RecipeName}\x1b[0m");
                }
                Console.Write("\x1b[94mEnter the number of the recipe you want to reset: \x1b[0m");
                int recipeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                {
                    recipes[recipeIndex].ResetQuantities();
                    Console.WriteLine("\x1b[92mQuantities reset successfully!\x1b[0m");
                }
                else
                {
                    Console.WriteLine("\x1b[91mInvalid recipe number.\x1b[0m");
                }
            }
        }

        // Method to clear all recipes
        public static void ClearAllRecipes(List<Recipe> recipes)
        {
            Console.WriteLine("\x1b[93mAre you sure you want to clear all recipes? (y/n)\x1b[0m");
            string confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "y")
            {
                recipes.Clear();
                Console.WriteLine("\x1b[92mAll recipes cleared successfully!\x1b[0m");
            }
            else
            {
                Console.WriteLine("\x1b[92mRecipe clearing cancelled.\x1b[0m");
            }
        }
    }
}