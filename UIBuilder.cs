using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RecipeOrganizer
{
    internal class UIBuilder
    {

        private static int pageUIAdditive = 0;

        //Homepage

        public static Panel buildHomePagePanel(Recipe recipe)
        {

            Panel newPanel = new Panel();
            newPanel.BackColor = Color.SlateGray;
            newPanel.Size = new Size(502, 50);

            newPanel.Name = "Recipe-" + recipe.getName();

            newPanel.Controls.Add(createTitle(recipe));
            newPanel.Controls.Add(createTags(recipe));

            newPanel.Controls.Add(bookmarkLabel(recipe));

            recipe.setSyncedPanel(newPanel);

            return newPanel;
        }

        private static Label createTitle(Recipe recipe)
        {

            Label label = new Label();
            label.Text = recipe.getName();
            label.Font = new Font("Microsoft Sans Serif", 14);
            label.Size = new Size(300, 24);

            return label;
        }

        private static Label createTags(Recipe recipe)
        {

            Label label = new Label();
            label.Text = "Tags: " + String.Join(", ", recipe.getTags());
            label.Font = new Font("Microsoft Sans Serif", 7);
            label.Size = new Size(500, 24);
            label.Location = new Point(2, 30);

            return label;
        }

        private static PictureBox bookmarkLabel(Recipe recipe)
        {

            PictureBox image = new PictureBox();
            
            if (recipe.isBookmarked())
            {
                image.Image = Resources.bookmark_icon;
            } else
            {
                image.Image = Resources.bookmarkiconempty;
            }

            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Size = new Size(20, 18);
            image.Location = new Point(475, 5);

            return image;
        }

        //Recipe Tabs

        public static RecipePage buildRecipePage(TabPage page, Recipe recipe)
        {

            pageUIAdditive = 0;

            page.BackColor = SystemColors.ActiveCaption;

            FlowLayoutPanel recipePagePanel = new FlowLayoutPanel();
            recipePagePanel.Size = new Size(617, 662);
            recipePagePanel.Location = new Point(0, 0);
            recipePagePanel.AutoScroll = true;

            page.Controls.Add(recipePagePanel);

            Panel newPanel = new Panel();
            newPanel.Size = new Size(590, 2000);

            recipePagePanel.Controls.Add(newPanel);

            PictureBox bookmarkLabel = interactableBookmarkLabel(recipe);
            Label title = recipeTitle(recipe);
            Label tags = recipeTags(recipe);
            PictureBox pictureBox = recipeImagePreview(recipe);
            Label pictureBackground = recipeImagePreviewBackground();
            Button edit = editButton(recipe);
            Button export = importButton(recipe);
            Button exit = exitButton(recipe);
            Button done = doneEditingButton(recipe);
            Button delete = deleteButton(recipe);

            newPanel.Controls.Add(bookmarkLabel);
            newPanel.Controls.Add(title);
            newPanel.Controls.Add(tags);

            newPanel.Controls.Add(pictureBox);
            newPanel.Controls.Add(pictureBackground);
            newPanel.Controls.Add(edit);
            newPanel.Controls.Add(export);
            newPanel.Controls.Add(done);
            newPanel.Controls.Add(exit);
            newPanel.Controls.Add(delete);

            newPanel.Controls.Add(ingredientsLabel(recipe));

            List<TextBox> ingredientsBoxes = buildInteractableIngredients(recipe);

            foreach (TextBox box in ingredientsBoxes)
            {
                newPanel.Controls.Add(box);
            }

            Button addIngredient = addIngredientButton(recipe);
            newPanel.Controls.Add(addIngredient);

            newPanel.Controls.Add(prepTimeLabel(recipe));

            TextBox editableDate = placeDateTimePicker(recipe);
            newPanel.Controls.Add(editableDate);
            newPanel.Controls.Add(instructionsLabel(recipe));

            List<TextBox> instructionsBoxes = buildInteractableInstructions(recipe);

            foreach (TextBox box in instructionsBoxes)
            {
                newPanel.Controls.Add(box);
            }

            Button addInstruction = addIngredientButton(recipe);
            newPanel.Controls.Add(addInstruction);

            RecipePage recipePage = new RecipePage(recipe, bookmarkLabel, title, tags, pictureBox, pictureBackground, ingredientsBoxes, instructionsBoxes, edit, newPanel);
            recipePage.setDoneButton(done);
            recipePage.setDeleteButton(delete);
            recipePage.setExitButton(exit);
            recipePage.setAddIngredientButton(addIngredient);
            recipePage.setAddInstructionButton(addInstruction);
            recipePage.setTabPage(page);
            recipePage.setPrepTimeBox(editableDate);
            recipePage.setExportButton(export);

            addIngredient.Visible = false;
            addInstruction.Visible = false;
            done.Visible = false;

            newPanel.Size = new Size(590, 330 + pageUIAdditive);

            RecipeManager.pages.Add(recipePage);

            return recipePage;
        }

        private static PictureBox recipeImagePreview(Recipe recipe)
        {

            PictureBox image = new PictureBox();

            try
            {
                image.ImageLocation = recipe.getImage();
            } catch (Exception e)
            {
                DialogResult error = MessageBox.Show("File not found: " + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Location = new Point(20, 82);
            image.Size = new Size(200, 200);

            return image;
        }

        private static Label recipeImagePreviewBackground()
        {

            Label label = new Label();
            label.BackColor = Color.Black;
            label.Location = new Point(17, 77);
            label.Size = new Size(206, 208);

            return label;
        }

        private static PictureBox interactableBookmarkLabel(Recipe recipe)
        {

            PictureBox image = new PictureBox();

            if (recipe.isBookmarked())
            {
                try
                {
                    image.Image = Resources.bookmark_icon;
                } catch (FileNotFoundException e)
                {
                    DialogResult error = MessageBox.Show("Bookmark picture not found: " + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                try
                {
                    image.Image = Resources.bookmarkiconempty;
                }
                catch (FileNotFoundException e)
                {
                    DialogResult error = MessageBox.Show("Bookmark picture not found: " + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            image.Name = recipe.getName() + "toggleableBookmark";
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Size = new Size(40, 38);
            image.Location = new Point(15, 10);

            return image;
        }

        private static Label recipeTitle(Recipe recipe)
        {

            Label label = new Label();
            label.Text = recipe.getName();
            label.Font = new Font("Microsoft Sans Serif", 24);
            label.Size = new Size(380, 40);
            label.Location = new Point(55, 14);

            return label;
        }

        private static Label recipeTags(Recipe recipe)
        {

            Label label = new Label();
            label.Text = "Tags: " + String.Join(", ", recipe.getTags());
            label.Font = new Font("Microsoft Sans Serif", 8);
            label.Size = new Size(400, 24);
            label.Location = new Point(13, 55);

            return label;
        }

        private static Button editButton(Recipe recipe)
        {

            Button editButton = new Button();
            editButton.Text = "Edit";
            editButton.Location = new Point(460, 20);
            editButton.Size = new Size(40, 23);
            editButton.UseVisualStyleBackColor = true;

            return editButton;
        }

        private static Button doneEditingButton(Recipe recipe)
        {

            Button doneEditingButton = new Button();
            doneEditingButton.Text = "Done";
            doneEditingButton.Location = new Point(450, 20);
            doneEditingButton.Size = new Size(50, 23);
            doneEditingButton.UseVisualStyleBackColor = true;

            return doneEditingButton;
        }

        private static Button addIngredientButton(Recipe recipe)
        {

            Button addButton = new Button();
            addButton.Text = "+";
            addButton.Location = new Point(15, (330 + pageUIAdditive));
            addButton.Size = new Size(23, 23);
            addButton.UseVisualStyleBackColor = true;
            pageUIAdditive += 30;

            return addButton;
        }

        private static Button deleteButton(Recipe recipe)
        {

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.Location = new Point(500, 20);
            deleteButton.Size = new Size(60, 23);
            deleteButton.UseVisualStyleBackColor = true;

            return deleteButton;
        }

        private static Button exitButton(Recipe recipe)
        {

            Button deleteButton = new Button();
            deleteButton.Text = "X";
            deleteButton.Location = new Point(560, 20);
            deleteButton.Size = new Size(23, 23);
            deleteButton.UseVisualStyleBackColor = true;

            return deleteButton;
        }

        private static Button importButton(Recipe recipe)
        {

            Button importButton = new Button();
            importButton.Text = "↑";
            importButton.Location = new Point(560, 50);
            importButton.Size = new Size(23, 23);
            importButton.UseVisualStyleBackColor = true;

            return importButton;
        }

        private static Label ingredientsLabel(Recipe recipe)
        {

            Label label = new Label();
            label.Text = "Ingredients";
            label.Font = new Font("Microsoft Sans Serif", 15);
            label.Size = new Size(400, 40);
            label.Location = new Point(12, 290);

            return label;
        }

        private static List<TextBox> buildInteractableIngredients(Recipe recipe)
        {
            List<TextBox> interactables = new List<TextBox>();

            foreach (String ingredient in recipe.getIngredients())
            {
                interactables.Add(placeInteractableIngredient(recipe, ingredient, pageUIAdditive));
                pageUIAdditive += 30;
            }

            return interactables;
        }

        private static List<TextBox> buildInteractableInstructions(Recipe recipe)
        {
            List<TextBox> interactables = new List<TextBox>();

            foreach (String instruction in recipe.getInstructions())
            {
                interactables.Add(placeInteractableInstruction(recipe, instruction, pageUIAdditive));
            }

            return interactables;
        }

        private static TextBox placeInteractableIngredient(Recipe recipe, String ingredient, int additive)
        {
            TextBox box = new TextBox();
            box.Location = new Point(16, (330 + additive));
            box.Size = new Size(300, 40);
            box.BackColor = SystemColors.ActiveCaption;
            box.BorderStyle = BorderStyle.None;
            box.ReadOnly = true;
            box.Enabled = false;
            box.Text = ingredient;

            return box;
        }

        private static TextBox placeInteractableInstruction(Recipe recipe, String instruction, int additive)
        {
            TextBox box = new TextBox();
            box.Location = new Point(16, (330 + additive));
            box.Size = new Size(300, 40);
            box.BackColor = SystemColors.ActiveCaption;
            box.BorderStyle = BorderStyle.None;
            box.ReadOnly = true;
            box.AutoSize = false;
            box.WordWrap = true;
            box.Enabled = false;
            box.Multiline = true;
                   
            box.Text = instruction;

            int height = box.GetLineFromCharIndex(int.MaxValue) + 1;
            
            box.Size = new Size(300, height * 18);

            pageUIAdditive += height * 18;

            return box;
        }

        private static Label prepTimeLabel(Recipe recipe)
        {

            Label label = new Label();
            label.Text = "Prep-Time";
            label.Font = new Font("Microsoft Sans Serif", 15);
            label.Size = new Size(400, 30);
            label.Location = new Point(12, 330 + pageUIAdditive);

            pageUIAdditive += 40;

            return label;
        }

        private static TextBox placeDateTimePicker(Recipe recipe)
        {
            TextBox box = new TextBox();
            box.Location = new Point(16, (330 + pageUIAdditive));
            box.ReadOnly = true;
            box.Enabled = false;
            box.Text = recipe.getPrepTime();

            pageUIAdditive += 60;

            return box;
        }

        private static Label instructionsLabel(Recipe recipe)
        {

            Label label = new Label();
            label.Text = "Instructions";
            label.Font = new Font("Microsoft Sans Serif", 15);
            label.Size = new Size(400, 30);
            label.Location = new Point(12, 330 + pageUIAdditive);

            pageUIAdditive += 40;

            return label;
        }
    }
}
