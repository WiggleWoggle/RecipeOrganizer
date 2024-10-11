using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RecipeOrganizer
{

    internal class Recipe
    {
        private int recipeID;
        private String recipeName;
        private String image;
        private String prepTime;
        private String cuisine;
        private String season;
        private bool bookmarked = false;
        private List<String> instructions = new List<String>();
        private List<String> ingredients = new List<String>();
        private List<String> recipeTags = new List<String>();
        private Panel syncedRecipePanel;

        public Recipe()
        {

        }

        public Recipe(int recipeID, String recipeName, String image, String prepTime, String cuisine, String season, List<String> instructions, List<String> ingredients, List<String> recipeTags)
        {
            setRecipeID(recipeID);
            setName(recipeName);
            setImage(image);
            setPrepTime(prepTime);
            setCuisine(cuisine);
            setSeason(season);
            bookmarked = false;
            this.instructions = instructions;
            this.ingredients = ingredients;
            this.recipeTags = recipeTags;
        }

        public Recipe(String name)
        {
            setName(name);
        }

        public void setRecipeID(int id)
        {
            recipeID = id;
        }

        public int getRecipeID()
        {
            return recipeID;
        }

        public void setName(String name)
        {

            recipeName = name;
        }

        public void addInstruction(int index, String instruction)
        {

        }

        public String getInstruction(int index, String instruction)
        {
            return " ";
        }

        public void setInstruction(int index, String instruction)
        {
            instructions[index] = instruction;
        }

        public void addIngredient(int index, String ingredient)
        {

        }

        public String getIngredient(int index, String ingredient)
        {
            return " ";
        }

        public List<String> getIngredients()
        {
            return ingredients;
        }

        public List<String> getInstructions()
        {
            return instructions;
        }

        public void setInstructions(List<String> newInstructions)
        {
            instructions = newInstructions;
        }

        public void setIngredient(int index, String ingredient)
        {
            ingredients[index] = ingredient;
        }

        public void setIngredients(List<String> newIngredients)
        {
            ingredients = newIngredients;   
        }

        public void setPrepTime(String time)
        {
            prepTime = time;
        }

        public String getPrepTime()
        {
            return prepTime;
        }

        public void setImage(String link)
        {
            image = link;
        }

        public String getImage()
        {
            return image;
        }

        public void setCuisine(String inCuisine)
        {
            cuisine = inCuisine;
        }

        public String getCuisine()
        {
            return cuisine;
        }

        public void setSeason(String inSeason)
        {
            season = inSeason;
        }

        public String getSeason()
        {
            return season;
        }

        public void toggleBookmark()
        {
            if (bookmarked)
            {
                bookmarked = false;
            }
            else
            {
                bookmarked = true;
            }
        }

        public Boolean isBookmarked()
        {
            return bookmarked;
        }

        public void importRecipe()
        {

        }

        public void exportRecipe()
        {

        }

        public String getName()
        {
            return recipeName;
        }

        public void addRecipeTag(String tag)
        {

            recipeTags.Add(tag);
        }

        public void removeTag(String tag)
        {

            if (recipeTags.Contains(tag))
            {
                recipeTags.Remove(tag);
            }
        }

        public List<String> getTags()
        {

            return recipeTags;
        }

        public void setSyncedPanel(Panel panel)
        {
            syncedRecipePanel = panel; 
        }

        public Panel getSyncedPanel()
        {
            return syncedRecipePanel; 
        }
    }
}
