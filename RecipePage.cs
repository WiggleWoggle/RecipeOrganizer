﻿using System;
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
        private Button editButton;
        private List<TextBox> editableIngredients = new List<TextBox>();
        private Panel pagePanel;
        private bool pageInEditing;

        public RecipePage()
        {

        }

        public RecipePage(Recipe associatedRecipe, PictureBox bookmark, Label title, Label tags, PictureBox imagePreview, Label imageBackground, List<TextBox> boxes, Button button, Panel panel)
        {
            recipe = associatedRecipe;
            bookmarkPicture = bookmark;
            recipeTitle = title;
            recipeTags = tags;
            recipeImagePreview = imagePreview;
            recipeImagePreviewBackground = imageBackground;
            editButton = button;
            editableIngredients = boxes;
            pagePanel = panel;

            pageInEditing = false;
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

        public List<TextBox> getEditableIngredientsTextBoxes() 
        {
            return editableIngredients; 
        }

        public Button getEditButton()
        {
            return editButton;
        }

        public void setPageInEditing(bool editing)
        {
            pageInEditing = editing;
        }

        public bool getPageInEditing()
        {
            return pageInEditing;
        }
    }
}