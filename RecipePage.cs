using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeOrganizer
{

    internal class RecipePage
    {

        private Recipe recipe;
        private PictureBox bookmarkPicture;
        private Label recipeTitle;
        private Label recipeTags;
        private PictureBox recipeImagePreview;
        private Label recipeImagePreviewBackground;

        public RecipePage()
        {

        }

        public RecipePage(Recipe associatedRecipe, PictureBox bookmark, Label title, Label tags, PictureBox imagePreview, Label imageBackground)
        {
            recipe = associatedRecipe;
            bookmarkPicture = bookmark;
            recipeTitle = title;
            recipeTags = tags;
            recipeImagePreview = imagePreview;
            recipeImagePreviewBackground = imageBackground;
        }

        public Recipe getRecipe()
        {
            return recipe;
        }

        public PictureBox getBookmarkPicture()
        {
            return bookmarkPicture; 
        }

        public Label getTitle() {
            return recipeTitle;
        }

        public Label getTags()
        {
            return recipeTags;
        }

        public PictureBox getImagePreview()
        {
            return recipeImagePreview;
        }

        public Label getImagePreviewBackground()
        {
            return recipeImagePreviewBackground;
        }
    }
}
