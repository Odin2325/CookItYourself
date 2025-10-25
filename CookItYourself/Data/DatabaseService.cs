using CookItYourself.Models;
using SQLite;

namespace CookItYourself.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>().Wait();
        }

        // CREATE
        public Task<int> AddRecipeAsync(Recipe recipe)
        {
            return _database.InsertAsync(recipe);
        }

        // READ
        public Task<List<Recipe>> GetRecipesAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }
    }
}
