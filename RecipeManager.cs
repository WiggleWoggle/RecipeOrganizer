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

        public static void initRecipes()
        {
            recipes.Add(new RecipeBuilder()
                .addRecipeID(1)
                .addRecipeName("Bulgogi")
                .addImage("https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2023%2F01%2F30%2F246172-Easy-Bulgogi-ddmfs-104-4x3-1.jpg&q=60&c=sc&poi=auto&orient=true&h=512\"")
                .addPrepTime("1 Hour")
                .addCuisine("Korean")
                .addInstructions(RecipeInstructions.bulgogi())
                .addIngredients(RecipeIngredients.bulgogi())
                .addSeason("Any")
                .addBookmarked(false)
                .addTags(new List<String> { "Korea", "Korean", "Korean Food", "Beef", "Barbeque", "Barbecue" })
                .Build());

            recipes.Add(new RecipeBuilder()
                .addRecipeID(2)
                .addRecipeName("Bibimbap")
                .addImage("https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F08%2F26%2F228240-BibimbapKoreanRiceWithMixedVegtables-ddmfs-4X3-0667.jpg&q=60&c=sc&poi=auto&orient=true&h=512")
                .addPrepTime("1 Hour")
                .addCuisine("Korean")
                .addInstructions(RecipeInstructions.bibimbap())
                .addIngredients(RecipeIngredients.bibimbap())
                .addSeason("Any")
                .addBookmarked(false)
                .addTags(new List<String> { "Korea", "Korean", "Korean Food", "Vegetables", "Rice", "Eggs", "Beef" })
                .Build());

            recipes.Add(new RecipeBuilder()
                .addRecipeID(3)
                .addRecipeName("Tteok-bokki")
                .addImage("https://futuredish.com/wp-content/uploads/Tteokbokki-3a.jpg")
                .addPrepTime("1 Hour")
                .addCuisine("Korean")
                .addInstructions(RecipeInstructions.tteokbokki())
                .addIngredients(RecipeIngredients.tteokbokki())
                .addSeason("Any")
                .addBookmarked(false)
                .addTags(new List<String> { "Korea", "Korean", "Korean Food", "Spicy" })
                .Build());

            recipes.Add(new RecipeBuilder()
                .addRecipeID(4)
                .addRecipeName("Baozi")
                .addImage("https://thewoksoflife.com/wp-content/uploads/2019/06/pork-baozi-11.jpg")
                .addPrepTime("1 Hour")
                .addCuisine("Chinese")
                .addInstructions(RecipeInstructions.baozi())
                .addIngredients(RecipeIngredients.baozi())
                .addSeason("Any")
                .addBookmarked(false)
                .addTags(new List<String> { "China", "Chinese", "Chinese Food", "Steamed", "Pork", "Buns" })
                .Build());
        }
    }
}
