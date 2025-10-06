using System;
using System.Linq;

namespace Recipes_list
{
    public partial class RecipeDetailPage : ContentPage
    {
        private readonly Recipe recipe;

        public RecipeDetailPage(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;

            TitleLabel.Text = recipe.Title;
            MianImage.Source = recipe.Image;
            CategoryLabel.Text = recipe.Category;
            PrepTimeLabel.Text = recipe.PrepTime;
            DescriptionLabel.Text = recipe.Description;

            IngredientsList.ItemsSource = recipe.Ingredients;
            InstructionsList.ItemsSource = recipe.Instructions
                .Select((s, i) => new { Index = $"{i + 1}.", Step = s })
                .ToList();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}