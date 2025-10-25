using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CookItYourself.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int RecipeID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Cuisine { get; set; }
        public string? ImagePath { get; set; }
    }
}
