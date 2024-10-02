using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOrganizer
{
    internal class RecipeManager
    {

        public static List<Recipe> recipes = new List<Recipe>();

        //TODO: populate this list with bookmarked recipes saved in the sql server
        public static List<Recipe> bookmarkedRecipes = new List<Recipe>();

        public static void addRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public static void addBookmarkedRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public static int recipeSize()
        {
            return recipes.Count; 
        }
    }
}
