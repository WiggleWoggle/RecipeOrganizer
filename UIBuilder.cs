using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RecipeOrganizer
{
    internal class UIBuilder
    {

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

            page.BackColor = SystemColors.ActiveCaption;

            FlowLayoutPanel recipePagePanel = new FlowLayoutPanel();
            recipePagePanel.Size = new Size(617, 662);
            recipePagePanel.Location = new Point(0, 0);
            recipePagePanel.AutoScroll = true;

            page.Controls.Add(recipePagePanel);

            Panel newPanel = new Panel();
            newPanel.Size = new Size(590, 900);

            recipePagePanel.Controls.Add(newPanel);

            PictureBox bookmarkLabel = interactableBookmarkLabel(recipe);
            Label title = recipeTitle(recipe);
            Label tags = recipeTags(recipe);
            PictureBox pictureBox = recipeImagePreview(recipe);
            Label pictureBackground = recipeImagePreviewBackground();
            Button edit = editButton(recipe);
            Button delete = deleteButton(recipe);

            newPanel.Controls.Add(bookmarkLabel);
            newPanel.Controls.Add(title);
            newPanel.Controls.Add(tags);

            newPanel.Controls.Add(pictureBox);
            newPanel.Controls.Add(pictureBackground);
            newPanel.Controls.Add(edit);
            newPanel.Controls.Add(delete);

            newPanel.Controls.Add(buildInteractableIngredients(recipe));

            RecipePage recipePage = new RecipePage(recipe, bookmarkLabel, title, tags, pictureBox, pictureBackground);

            return recipePage;
        }

        private static PictureBox recipeImagePreview(Recipe recipe)
        {

            PictureBox image = new PictureBox();

            //unsafe image call, needs to be fixed later
            image.ImageLocation = recipe.getImage();
            //
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Location = new Point(20, 60 + 20);
            image.Size = new Size(200, 200);

            return image;
        }

        private static Label recipeImagePreviewBackground()
        {

            Label label = new Label();
            label.BackColor = Color.Black;
            label.Location = new Point(17, 57 + 20);
            label.Size = new Size(206, 206);

            return label;
        }

        private static PictureBox interactableBookmarkLabel(Recipe recipe)
        {

            PictureBox image = new PictureBox();

            if (recipe.isBookmarked())
            {
                image.Image = Resources.bookmark_icon;
            }
            else
            {
                image.Image = Resources.bookmarkiconempty;
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
            label.Size = new Size(400, 40);
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
            editButton.Location = new Point(480, 20);
            editButton.Size = new Size(40, 23);
            editButton.UseVisualStyleBackColor = true;

            return editButton;
        }

        private static Button deleteButton(Recipe recipe)
        {

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.Location = new Point(520, 20);
            deleteButton.Size = new Size(60, 23);
            deleteButton.UseVisualStyleBackColor = true;

            return deleteButton;
        }

        private static TextBox buildInteractableIngredients(Recipe recipe)
        {
            TextBox box = new TextBox();
            box.Location = new Point(20, 400);
            box.ReadOnly = true;
            box.Enabled = false;
            box.Text = "Ingredient Ex";

            return box;
        }
    }
}
