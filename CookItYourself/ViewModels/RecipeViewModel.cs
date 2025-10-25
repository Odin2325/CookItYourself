using System.Collections.ObjectModel;
using CookItYourself.Data;
using CookItYourself.Models;

namespace CookItYourself.ViewModels
{
    public class RecipeViewModel : BindableObject
    {
        private readonly DatabaseService _db;
        public ObservableCollection<Recipe> Recipes { get; } = new();

        private string _newRecipeName = string.Empty;
        public string NewRecipeName
        {
            get => _newRecipeName;
            set
            {
                _newRecipeName = value;
                OnPropertyChanged();
            }
        }

        private string _newRecipeCuisine = string.Empty;
        public string NewRecipeCuisine
        {
            get => _newRecipeCuisine;
            set
            {
                _newRecipeCuisine = value;
                OnPropertyChanged();
            }
        }

        private string _newRecipeDescription = string.Empty;
        public string NewRecipeDescription
        {
            get => _newRecipeDescription;
            set
            {
                _newRecipeDescription = value;
                OnPropertyChanged();
            }
        }

        public RecipeViewModel(DatabaseService db)
        {
            _db = db;
        }

        public async Task LoadRecipesAsync()
        {
            Recipes.Clear();
            var recipes = await _db.GetRecipesAsync();
            foreach (var recipe in recipes)
                Recipes.Add(recipe);
        }

        public async Task AddRecipeAsync()
        {
            if (string.IsNullOrWhiteSpace(NewRecipeName)) return;

            var recipe = new Recipe
            {
                Name = NewRecipeName,
                Cuisine = NewRecipeCuisine,
                Description = NewRecipeDescription
            };

            await _db.AddRecipeAsync(recipe);
            Recipes.Add(recipe);

            NewRecipeName = string.Empty;
            NewRecipeCuisine = string.Empty;
            NewRecipeDescription = string.Empty;

        }
    }
}
