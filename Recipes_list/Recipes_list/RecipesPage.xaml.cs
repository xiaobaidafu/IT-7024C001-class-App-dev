using System.Collections.Generic;
using System.Linq;

namespace Recipes_list
{
    public partial class RecipesPage : ContentPage
    {
        public List<Recipe> Recipes { get; } = new()
        {
            new Recipe
            {
                Title = "Pancakes",
                Category = "Breakfast / American",
                PrepTime = "20 minutes",
                Description = "Fluffy and golden pancakes perfect for a cozy morning, served best with maple syrup or fresh fruit.",
                Image = "pancake.jpg",
                Ingredients = new()
                {
                    "1 cup all-purpose flour",
                    "1 tbsp sugar",
                    "1 tsp baking powder",
                    "1 cup milk",
                    "1 egg",
                    "1 tbsp melted butter"
                },
                Instructions = new()
                {
                    "Mix flour, sugar, and baking powder in a bowl.",
                    "In another bowl, whisk milk, egg, and melted butter.",
                    "Combine both mixtures until smooth.",
                    "Pour 1/4 cup of batter on a heated pan and cook each side until golden brown."
                }
            },

            new Recipe
            {
                Title = "Spaghetti",
                Category = "Main Dish / Italian",
                PrepTime = "30 minutes",
                Description = "A simple yet classic Italian pasta dish, rich in flavor and comfort, ideal for any weekday dinner.",
                Image = "spaghetti.jpg",
                Ingredients = new()
                {
                    "200g spaghetti",
                    "2 tbsp olive oil",
                    "2 cloves garlic (minced)",
                    "1 cup tomato sauce",
                    "Salt and pepper to taste",
                    "Parmesan cheese"
                },
                Instructions = new()
                {
                    "Boil spaghetti until al dente, then drain.",
                    "Heat olive oil in a pan and sauté garlic.",
                    "Add tomato sauce and simmer for 5 minutes.",
                    "Toss spaghetti in the sauce and season with salt and pepper.",
                    "Top with Parmesan cheese before serving."
                }
            },

            new Recipe
            {
                Title = "Chicken Salad",
                Category = "Lunch / Healthy",
                PrepTime = "15 minutes",
                Description = "A light and nutritious salad filled with fresh vegetables and tender chicken, perfect for a quick healthy lunch.",
                Image = "chicken.jpg",
                Ingredients = new()
                {
                    "1 cooked chicken breast (sliced)",
                    "1 cup lettuce",
                    "1/2 cup cherry tomatoes",
                    "1/4 cup cucumber (sliced)",
                    "Olive oil and lemon dressing"
                },
                Instructions = new()
                {
                    "Combine lettuce, tomatoes, and cucumber in a bowl.",
                    "Add the sliced chicken breast.",
                    "Drizzle with olive oil and lemon juice dressing, then toss well."
                }
            },

            new Recipe
            {
                Title = "Beef Stir-fry",
                Category = "Dinner / Asian",
                PrepTime = "25 minutes",
                Description = "A flavorful Asian-inspired stir-fry combining tender beef and crisp vegetables with savory sauce.",
                Image = "beef.jpg",
                Ingredients = new()
                {
                    "200g beef (thinly sliced)",
                    "1 cup mixed vegetables (bell pepper, broccoli, carrot)",
                    "2 tbsp soy sauce",
                    "1 tbsp oyster sauce",
                    "1 tbsp vegetable oil"
                },
                Instructions = new()
                {
                    "Heat oil in a wok, add beef, and stir-fry until browned.",
                    "Add vegetables and cook for 3–4 minutes.",
                    "Pour in soy and oyster sauce; stir until well coated.",
                    "Serve hot with rice or noodles."
                }
            },

            new Recipe
            {
                Title = "Cheesecake",
                Category = "Dessert / Western",
                PrepTime = "1 hour",
                Description = "A creamy and rich cheesecake with a buttery crust, perfect for dessert lovers seeking a classic treat.",
                Image = "cheesecake.jpg",
                Ingredients = new()
                {
                    "200g cream cheese",
                    "1/2 cup sugar",
                    "2 eggs",
                    "1 tsp vanilla extract",
                    "100g crushed graham crackers",
                    "50g melted butter"
                },
                Instructions = new()
                {
                    "Mix crushed crackers with melted butter and press into a pan base.",
                    "Beat cream cheese, sugar, eggs, and vanilla until smooth.",
                    "Pour over crust and bake at 170°C for 40 minutes.",
                    "Cool before serving."
                }
            }
        };

        public RecipesPage()
        {
            InitializeComponent();
            RecipesCollection.ItemsSource = Recipes;
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as Recipe;
            if (selectedItem == null) return;

            await Navigation.PushAsync(new RecipeDetailPage(selectedItem));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}