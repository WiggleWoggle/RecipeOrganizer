using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOrganizer
{

    internal class Recipe
    {

        private String recipeName = " ";
        private String recipeDescription = " ";
        private List<String> recipeTags = new List<String>();

        public Recipe()
        {

        }

        public Recipe(String name, String description)
        {
            setRecipeName(name);
            setRecipeDescription(description);

        }

        public String getRecipeName()
        {
            return recipeName;
        }

        public String getDescription()
        {
            return recipeDescription;
        }

        public void setRecipeName(String name)
        {

            recipeName = name;
        }

        public void setRecipeDescription(String description)
        {

            recipeDescription = description;
        }

        public void addRecipeTag(String tag)
        {

            if (!recipeTags.Contains(tag))
            {
                recipeTags.Add(tag);
            }
        }

        public void setTags(List<String> tags)
        {

            recipeTags = tags;
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
    }
}
