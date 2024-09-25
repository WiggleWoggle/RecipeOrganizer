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

        public static void addRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public static int recipeSize()
        {
            return recipes.Count; 
        }
    }
}
