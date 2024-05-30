using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store the recipes
            List<Recipe> recipes = new List<Recipe>();

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
                        Console.WriteLine();
                        break;
                    case 3:
                        // Scale a recipe
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
                        Console.WriteLine();
                        break;
                    case 4:
                        // Reset a recipe's quantities
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
                        Console.WriteLine();
                        break;
                    case 5:
                        // Clear all recipes
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

        private static void SortRecipes(List<Recipe> recipes)
        {
           
            recipes.Sort((RSAPKCS1KeyExchangeDeformatter, Rfc2898DeriveBytes) => string.Compare(RSAPKCS1KeyExchangeDeformatter.RecipeName, Rfc2898DeriveBytes.RecipeName, StringComparison.
                OrdinalIgnoreCase));
        }
    }


    class Recipe
    {
        public string? RecipeName { get; set; }
        private string[]? Ingredients;
        private double[]? Quantities;
        private string[]? Units;
        private string[]? Steps;
        private double[]? OriginalQuantities;

        // Method to enter the recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("\x1b[94mEnter the name of the recipe: \x1b[0m");
            RecipeName = Console.ReadLine();

            Console.Write("\x1b[94mEnter the number of ingredients: \x1b[0m");
            int numIngredients = Convert.ToInt32(Console.ReadLine());

            Ingredients = new string[numIngredients]!;
            Quantities = new double[numIngredients]!;
            Units = new string[numIngredients]!;

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("\x1b[94mEnter the name of ingredient {0}: \x1b[0m", i + 1);
                Ingredients[i] = Console.ReadLine()!;

                Console.Write("\x1b[94mEnter the quantity of ingredient {0}: \x1b[0m", i + 1);
                Quantities[i] = Convert.ToDouble(Console.ReadLine());

                Console.Write("\x1b[94mEnter the unit of ingredient {0}: \x1b[0m", i + 1);
                Units[i] = Console.ReadLine()!;
            }

            Console.Write("\x1b[94mEnter the number of steps: \x1b[0m");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            Steps = new string[numSteps]!;

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("\x1b[94mEnter step {0}: \x1b[0m", i + 1);
                Steps[i] = Console.ReadLine()!;
            }

            // Store the original quantities for reset functionality
            OriginalQuantities = new double[Quantities.Length];
            Array.Copy(Quantities, OriginalQuantities, Quantities.Length);
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("\x1b[1m\x1b[95m{0}\x1b[0m", RecipeName);
            Console.WriteLine("\x1b[1m\x1b[95mIngredients:\x1b[0m");
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Console.WriteLine($"\x1b[93m{Quantities[i]} {Units[i]} of {Ingredients[i]}\x1b[0m");
            }
            Console.WriteLine("\x1b[1m\x1b[95mSteps:\x1b[0m");
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine($"\x1b[93m{i + 1}. {Steps[i]}\x1b[0m");
            }
            Console.WriteLine();
        }

        // Method to scale the recipe
        public void ScaleRecipe(double scalingFactor)
        {
            for (int i = 0; i < Quantities.Length; i++)
            {
                Quantities[i] *= scalingFactor;
            }
        }

        // Method to reset the quantities to the original values
        public void ResetQuantities()
        {
            Array.Copy(OriginalQuantities, Quantities, Quantities.Length);
        }
    }
}
