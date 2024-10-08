﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            label.Size = new Size(300, 24);
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

            FlowLayoutPanel recipePagePanel = new FlowLayoutPanel();

            page.Controls.Add(recipePagePanel);

            Panel newPanel = new Panel();
            newPanel.BackColor = SystemColors.ActiveCaption;
            newPanel.BackColor = Color.SlateGray;
            newPanel.Size = new Size(502, 500);

            recipePagePanel.Controls.Add(newPanel);

            PictureBox bookmarkLabel = interactableBookmarkLabel(recipe);
            Label title = recipeTitle(recipe);
            Label tags = recipeTags(recipe);
            PictureBox pictureBox = recipeImagePreview(recipe);
            Label pictureBackground = recipeImagePreviewBackground();
            Button edit = editButton(recipe);

            newPanel.Controls.Add(bookmarkLabel);
            newPanel.Controls.Add(title);
            newPanel.Controls.Add(tags);

            newPanel.Controls.Add(pictureBox);
            newPanel.Controls.Add(pictureBackground);
            newPanel.Controls.Add(edit);

            newPanel.BackColor = SystemColors.ActiveCaption;

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
            image.Location = new Point(560, 10);

            return image;
        }

        private static Label recipeTitle(Recipe recipe)
        {

            Label label = new Label();
            label.Text = recipe.getName();
            label.Font = new Font("Microsoft Sans Serif", 24);
            label.Size = new Size(300, 36);
            label.Location = new Point(9, 10);

            return label;
        }

        private static Label recipeTags(Recipe recipe)
        {

            Label label = new Label();
            label.Text = "Tags: " + String.Join(", ", recipe.getTags());
            label.Font = new Font("Microsoft Sans Serif", 12);
            label.Size = new Size(400, 24);
            label.Location = new Point(13, 45);

            return label;
        }

        private static Button editButton(Recipe recipe)
        {

            Button editButton = new Button();
            editButton.Text = "Edit";

            return editButton;
        }
    }
}
