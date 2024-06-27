using System.Windows;

namespace RecipeApp
{
    public partial class EnterRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }

        public EnterRecipeWindow()
        {
            InitializeComponent();
            NewRecipe = new Recipe();
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Example: Save entered recipe details to NewRecipe
            NewRecipe.RecipeName = RecipeNameTextBox.Text;
            // Add more logic to save ingredients, steps, etc.

            DialogResult = true;
            Close();
        }
    }
}
