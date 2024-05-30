using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Recipe class
            Recipe recipe = new Recipe();

            // Start the main program loop
            while (true)
            {
                // Display the menu options
                Console.WriteLine("\x1b[93m1. Enter recipe details\x1b[0m");
                Console.WriteLine("\x1b[93m2. Display recipe\x1b[0m");
                Console.WriteLine("\x1b[93m3. Scale the recipe\x1b[0m");
                Console.WriteLine("\x1b[93m4. Reset quantities\x1b[0m");
                Console.WriteLine("\x1b[93m5. Clear all data\x1b[0m");
                Console.WriteLine("\x1b[93m6. Exit\x1b[0m");

                // Prompt the user for their choice
                Console.Write("\x1b[94mEnter your choice: \x1b[0m");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                // Handle the user's choice
                switch (choice)
                {
                    case 1:
                        // Enter recipe details
                        recipe.EnterRecipeDetails();
                        Console.WriteLine("\x1b[92mRecipe details entered successfully!\x1b[0m");
                        Console.WriteLine();
                        break;
                    case 2:
                        // Display the recipe
                        recipe.DisplayRecipe();
                        Console.WriteLine();
                        break;
                    case 3:
                        // Scale the recipe
                        Console.Write("\x1b[94mEnter the scaling factor (0.5, 2, or 3): \x1b[0m");
                        double scalingFactor = Convert.ToDouble(Console.ReadLine());
                        recipe.ScaleRecipe(scalingFactor);
                        Console.WriteLine("\x1b[92mRecipe scaled successfully!\x1b[0m");
                        Console.WriteLine();
                        break;
                    case 4:
                        // Reset the quantities to their original values
                        recipe.ResetQuantities();
                        Console.WriteLine("\x1b[92mQuantities reset successfully!\x1b[0m");
                        Console.WriteLine();
                        break;
                    case 5:
                        // Clear all recipe data
                        recipe.ClearData();
                        Console.WriteLine("\x1b[92mAll data cleared successfully!\x1b[0m");
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
    }

    class Recipe
    {
        // Private fields to store the recipe details
        private string? recipeName;
        private string[]? ingredients;
        private double[]? quantities;
        private string[]? units;
        private string[]? steps;
        private double[]? originalQuantities;

        // Method to enter the recipe details
        public void EnterRecipeDetails()
        {
            // Prompt the user for the recipe name
            Console.Write("\x1b[94mEnter the name of the recipe: \x1b[0m");
            recipeName = Console.ReadLine();

            // Prompt the user for the number of ingredients
            Console.Write("\x1b[94mEnter the number of ingredients: \x1b[0m");
            int numIngredients = Convert.ToInt32(Console.ReadLine());

            // Initialize the ingredient-related arrays
            ingredients = new string[numIngredients]!;
            quantities = new double[numIngredients]!;
            units = new string[numIngredients]!;

            // Prompt the user for the ingredient details
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("\x1b[94mEnter the name of ingredient {0}: \x1b[0m", i + 1);
                ingredients[i] = Console.ReadLine()!;

                Console.Write("\x1b[94mEnter the quantity of ingredient {0}: \x1b[0m", i + 1);
                quantities[i] = Convert.ToDouble(Console.ReadLine());

                Console.Write("\x1b[94mEnter the unit of measurement for ingredient {0}: \x1b[0m", i + 1);
                units[i] = Console.ReadLine()!;
            }

            // Prompt the user for the number of steps
            Console.Write("\x1b[94mEnter the number of steps: \x1b[0m");
            int numSteps = Convert.ToInt32(Console.ReadLine());

            // Initialize the steps array
            steps = new string[numSteps]!;

            // Prompt the user for the step details
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("\x1b[94mEnter step {0}: \x1b[0m", i + 1);
                steps[i] = Console.ReadLine()!;
            }

            // Store the original quantities for resetting
            originalQuantities = new double[quantities.Length];
            Array.Copy(quantities, originalQuantities, quantities.Length);
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine();
            Console.WriteLine("\x1b[1m\x1b[95mRecipe: {0}\x1b[0m", recipeName);
            Console.WriteLine();

            // Display the ingredients and their quantities
            for (int i = 0; i < ingredients!.Length; i++)
            {
                Console.WriteLine("\x1b[92m{0} {1} of {2}\x1b[0m", quantities![i], units![i], ingredients![i]);
            }

            Console.WriteLine();

            // Display the steps
            for (int i = 0; i < steps!.Length; i++)
            {
                Console.WriteLine("\x1b[94mStep {0}: {1}\x1b[0m", i + 1, steps![i]);
            }

            Console.WriteLine();
        }

        // Method to scale the recipe
        public void ScaleRecipe(double scalingFactor)
        {
            // Multiply the quantities by the scaling factor
            for (int i = 0; i < quantities!.Length; i++)
            {
                quantities![i] *= scalingFactor;
            }
        }

        // Method to reset the quantities to their original values
        public void ResetQuantities()
        {
            // Reset quantities to their original values
            if (quantities != null && originalQuantities != null && quantities.Length == originalQuantities.Length)
            {
                for (int i = 0; i < quantities.Length; i++)
                {
                    quantities[i] = originalQuantities[i];
                }
            }
        }

        // Method to clear all recipe data
        public void ClearData()
        {
            // Prompt the user for confirmation before clearing data
            Console.WriteLine("\x1b[93mAre you sure you want to clear all recipe data? (y/n)\x1b[0m");
            string confirmation = Console.ReadLine()?.ToLower();
        
            if (confirmation == "y")
            {
                recipeName = null;
                ingredients = null;
                quantities = null;
                units = null;
                steps = null;
                Console.WriteLine("\x1b[92mAll data cleared successfully!\x1b[0m");
            }
            else
            {
                Console.WriteLine("\x1b[92mData clearing cancelled.\x1b[0m");
            }
        }
    }
}

    

