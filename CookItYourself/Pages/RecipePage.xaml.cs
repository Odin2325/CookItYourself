using CookItYourself.Data;
using CookItYourself.ViewModels;

namespace CookItYourself.Pages;

public partial class RecipePage : ContentPage
{
    private readonly RecipeViewModel _viewModel;

    public RecipePage(DatabaseService db)
    {
        InitializeComponent();
        _viewModel = new RecipeViewModel(db);
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadRecipesAsync();
    }

    private async void OnAddRecipeClicked(object sender, EventArgs e)
    {
        await _viewModel.AddRecipeAsync();
    }
}
