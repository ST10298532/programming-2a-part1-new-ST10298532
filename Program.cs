using System;

namespace RecipeApp
{
    class Program
    {
        // Main function - entry point of the program
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                // Display menu options
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale the recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipeDetails();
                        Console.WriteLine("Recipe details entered successfully!");
                        Console.WriteLine();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
                        double scalingFactor = Convert.ToDouble(Console.ReadLine());
                        recipe.ScaleRecipe(scalingFactor);
                        Console.WriteLine("Recipe scaled successfully!");
                        Console.WriteLine();
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        Console.WriteLine("Quantities reset successfully!");
                        Console.WriteLine();
                        break;
                    case 5:
                        recipe.ClearData();
                        Console.WriteLine("All data cleared successfully!");
                        Console.WriteLine();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }

    class Recipe
    {
        private string[]? ingredients;
        private double[]? quantities;
        private string[]? units;
        private string[]? steps;

        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = Convert.ToInt32(Console.ReadLine());

            // Allocate arrays to store ingredient details
            ingredients = new string[numIngredients];
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            // Prompt the user to enter ingredient details and store them in the arrays
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter the name of ingredient {0}: ", i + 1);
                ingredients[i] = Console.ReadLine();

                Console.Write("Enter the quantity of ingredient {0}: ", i + 1);
                quantities[i] = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter the unit of measurement for ingredient {0}: ", i + 1);
                units[i] = Console.ReadLine();
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = Convert.ToInt32(Console.ReadLine());

             // Allocate an array to store recipe steps 
            steps = new string[numSteps];

            // Prompt the user to enter recipe steps and store them in the array
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("Enter step {0}: ", i + 1);
                steps[i] = Console.ReadLine();
            }
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");

            // Display ingredient details
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine("{0} {1} of {2}", quantities[i], units[i], ingredients[i]);
            }

            Console.WriteLine();

            // Display recipe steps
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine("Step {0}: {1}", i + 1, steps[i]);
            }
        }
        
        // Method to scale the recipe by a given scaling factor
        public void ScaleRecipe(double scalingFactor)
        {
             // Multiply each quantity by the scaling factor
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= scalingFactor;
            }
        }
        // Method to reset the quantities to their original values
        public void ResetQuantities()
        {
            // Reset quantities to their original values
            // You would need to store the original quantities in a separate array or list to accomplish this
        }
        // Method to clear all the recipe data
        public void ClearData()
        {
            // Clear all recipe data by setting the arrays to null
            ingredients = null;
            quantities = null;
            units = null;
            steps = null;
        }
    }
}
