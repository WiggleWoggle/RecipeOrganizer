using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeOrganizer
{
    internal class RecipeManager
    {
        public static String connectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true";

        public static String onLoadDirectory = "";
        public static String defaultFormDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static List<Recipe> recipes = new List<Recipe>();

        //TODO: populate this list with bookmarked recipes saved in the sql server
        public static List<Recipe> bookmarkedRecipes = new List<Recipe>();

        public static List<RecipePage> pages = new List<RecipePage>();

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
