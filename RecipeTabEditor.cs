using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeOrganizer
{
    internal class RecipeTabEditor
    {
        public static void setPageInEditMode(RecipePage page)
        {
            page.getEditButton().Visible = false;

            foreach (TextBox ingredientBox in page.getEditableIngredientsTextBoxes())
            {
                ingredientBox.BackColor = Color.White;
                ingredientBox.BorderStyle = BorderStyle.Fixed3D;
                ingredientBox.ReadOnly = false;
                ingredientBox.Enabled = true;
            }

            foreach (TextBox instructionBox in page.getEditableInstructionsTextBoxes())
            {
                instructionBox.BackColor = Color.White;
                instructionBox.BorderStyle = BorderStyle.Fixed3D;
                instructionBox.ReadOnly = false;
                instructionBox.Enabled = true;
            }

            page.getPrepTimeBox().BackColor = Color.White;
            page.getPrepTimeBox().BorderStyle = BorderStyle.Fixed3D;
            page.getPrepTimeBox().ReadOnly = false;
            page.getPrepTimeBox().Enabled = true;

            page.setPageInEditing(true);

            page.getAddIngredientButton().Visible = true;
            page.getAddInstructionButton().Visible = true;
            page.getDoneButton().Visible = true;

            page.getTabPage().Text = page.getRecipe().getName() + " (Editing)";
        }

        public static void setPageInViewMode(RecipePage page)
        {
            page.getDoneButton().Visible = false;

            Recipe cloned = page.getRecipe();
            List<Recipe> newRecipes = RecipeManager.recipes;

            foreach (Recipe recipe in RecipeManager.recipes)
            {
                if (recipe.Equals(cloned))
                {
                    newRecipes.Remove(cloned);
                    break;
                }
            }

            RecipeManager.recipes = newRecipes;

            cloned.getIngredients().Clear();

            List<String> newIngredients = new List<String>();
            List<String> newInstructions = new List<String>();

            foreach (TextBox ingredientBox in page.getEditableIngredientsTextBoxes())
            {
                ingredientBox.BackColor = SystemColors.ActiveCaption;
                ingredientBox.BorderStyle = BorderStyle.None;
                ingredientBox.ReadOnly = true;
                ingredientBox.Enabled = false;

                newIngredients.Add(ingredientBox.Text);
            }

            foreach (TextBox instructionBox in page.getEditableInstructionsTextBoxes())
            {
                instructionBox.BackColor = SystemColors.ActiveCaption;
                instructionBox.BorderStyle = BorderStyle.None;
                instructionBox.ReadOnly = true;
                instructionBox.Enabled = false;

                newInstructions.Add(instructionBox.Text);
            }

            page.getPrepTimeBox().ReadOnly = true;
            page.getPrepTimeBox().Enabled = false;

            cloned.setPrepTime(page.getPrepTimeBox().Text);
            cloned.setIngredients(newIngredients);
            cloned.setInstructions(newInstructions);

            RecipeManager.recipes.Add(cloned);

            page.setPageInEditing(false);

            page.getAddIngredientButton().Visible = false;
            page.getAddInstructionButton().Visible = false;
            page.getEditButton().Visible = true;

            page.getTabPage().Text = cloned.getName();
        }
    }
}
