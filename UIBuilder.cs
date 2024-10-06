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
            
            if (!recipe.isBookmarked())
            {
                newPanel.Controls.Add(bookmarkLabel(recipe));
            }

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

            String tags = "";

            if (recipe.getTags() != null)
            {
                foreach (String tag in recipe.getTags())
                {

                    tags += tag + ", ";
                }
            }

            label.Text = tags;

            label.Font = new Font("Microsoft Sans Serif", 7);
            label.Size = new Size(300, 24);
            label.Location = new Point(2, 30);

            return label;
        }

        private static PictureBox bookmarkLabel(Recipe recipe)
        {

            PictureBox image = new PictureBox();
            image.Image = Resources.bookmark_icon;
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Size = new Size(20, 18);
            image.Location = new Point(475, 5);

            return image;
        }

        //Recipe Tabs

        public static void buildRecipePage(TabPage page, Recipe recipe)
        {
            page.Controls.Add(recipeImagePreview(recipe));
            page.Controls.Add(interactableBookmarkLabel(recipe));

            page.BackColor = SystemColors.ActiveCaption;
        }

        private static PictureBox recipeImagePreview(Recipe recipe)
        {

            PictureBox image = new PictureBox();

            //unsafe image call, needs to be fixed later
            image.ImageLocation = recipe.getImage();
            //
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Location = new Point(20, 60);
            image.Size = new Size(200, 200);

            return image;
        }

        private static PictureBox interactableBookmarkLabel(Recipe recipe)
        {

            PictureBox image = new PictureBox();
            image.Image = Resources.bookmark_icon;
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Size = new Size(40, 38);
            image.Location = new Point(560, 10);

            return image;
        }
    }
}
