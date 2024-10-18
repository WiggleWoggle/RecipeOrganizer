using Google.Protobuf.WellKnownTypes;
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
        public int recipeID;
        public String recipeName;
        public String image;
        public String prepTime;
        public String cuisine;
        public String season;
        public bool bookmarked = false;
        public List<String> instructions = new List<String>();
        public List<String> ingredients = new List<String>();
        public List<String> recipeTags = new List<String>();
        public Panel syncedRecipePanel;

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

        public String getInstruction(int index)
        {
            return instructions[index];
        }

        public void setInstruction(int index, String instruction)
        {
            instructions[index] = instruction;
        }

        public String getIngredient(int index)
        {
            return ingredients[index];
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

        public void setTags(List<String> tags)
        {
            recipeTags = tags;
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

    internal class RecipeBuilder
    {

        private Recipe recipe = new Recipe();

        public RecipeBuilder addRecipeID(int id)
        {
            recipe.recipeID = id;
            return this;
        }

        public RecipeBuilder addRecipeName(String value)
        {
            recipe.recipeName = value;
            return this;
        }

        public RecipeBuilder addImage(String value)
        {
            recipe.image = value;
            return this;
        }

        public RecipeBuilder addPrepTime(String value)
        {
            recipe.prepTime = value;
            return this;
        }

        public RecipeBuilder addCuisine(String value)
        {
            recipe.cuisine = value;
            return this;
        }

        public RecipeBuilder addSeason(String season)
        {
            recipe.season = season;
            return this;
        }

        public RecipeBuilder addBookmarked(bool value)
        {
            recipe.bookmarked = value;
            return this;
        }

        public RecipeBuilder addInstructions(List<String> value)
        {
            recipe.instructions = value;
            return this;
        }

        public RecipeBuilder addIngredients(List<String> value)
        {
            recipe.ingredients = value;
            return this;
        }

        public RecipeBuilder addTags(List<String> value)
        {
            recipe.recipeTags = value;
            return this;
        }

        public Recipe Build()
        {
            return recipe;
        }
    }
}
