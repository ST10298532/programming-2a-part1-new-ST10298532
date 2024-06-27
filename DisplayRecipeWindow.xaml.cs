using System.Windows;

namespace RecipeAppWPF
{
    public partial class DisplayRecipeWindow : Window
    {
        public Recipe Recipe { get; set; }

        public DisplayRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            DataContext = recipe; // Set data context to the recipe object

            Recipe = recipe;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
