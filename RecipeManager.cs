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

        public static void initRecipes()
        {

            recipes.Add(new Recipe(1, "Tteok-bokki", "https://futuredish.com/wp-content/uploads/Tteokbokki-3a.jpg", new DateTime(), "Korean", "Any", new List<String>(), new List<String>(), new List<String>()));
            recipes.Add(new Recipe(2, "Peking duck", "https://ca-times.brightspotcdn.com/dims4/default/2e3a833/2147483647/strip/false/crop/4410x3528+0+0/resize/1486x1189!/quality/75/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2Fbf%2Fa9%2F0789235747e19dd8588df4fa9480%2Fnas-peking-duck.jpg", new DateTime(), "Chinese", "Summer", new List<String>(), new List<String>(), new List<String>()));
            recipes.Add(new Recipe(3, "Baozi", "https://thewoksoflife.com/wp-content/uploads/2019/06/pork-baozi-11.jpg", new DateTime(), "Chinese", "Any", new List<String>(), new List<String>(), new List<String>()));

        }
    }
}
