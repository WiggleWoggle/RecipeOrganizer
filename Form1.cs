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
    public partial class Form1 : Form
    {

        private List<Recipe> bookmarkedRecipes = new List<Recipe>();
        private List<Recipe> displayedRecipes = new List<Recipe>();

        public Form1()
        {
            InitializeComponent();
            SQLserver();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Random random = new Random();

            Recipe createdRecipe = new Recipe("Recipe Name " + random.Next(1, 101));
            createdRecipe.addRecipeTag("TEST");
            createdRecipe.addRecipeTag("TEST2");
            createdRecipe.addRecipeTag("TEST3");

            bookmarkedRecipes.Add(createdRecipe);
            displayedRecipes.Add(createdRecipe);

            displayRecipes();
        }

        private void displayRecipes()
        {

            foreach (Recipe recipe in displayedRecipes)
            {
                buildRecipe(recipe);
            }
        }

        private void clearRecipes()
        {

            RecipeLayoutPanel.Controls.Clear();
        }

        private void resetDisplayedToBookmarked()
        {

            displayedRecipes = bookmarkedRecipes;
        }

        private void buildRecipe(Recipe recipe)
        {

            RecipeManager.addRecipe(recipe);

            RecipeLayoutPanel.Controls.Add(createPanel(recipe));


            createPanel(recipe);

            updateNoBookmarkLabel();
        }

        //Search Bar Functionality

        private void SearchInputText_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                clearRecipes();
                updateDisplayedRecipes(textBox.Text);
                displayRecipes();
            } else
            {
                resetDisplayedToBookmarked();
            }
        }

        private void updateDisplayedRecipes(String textboxString)
        {

            List<Recipe> temp = new List<Recipe>();

            foreach (Recipe recipe in bookmarkedRecipes)
            {

                if (recipe.getName().Contains(textboxString)) {

                    temp.Add(recipe);
                }
            }

            displayedRecipes = temp;
        }

        //UI Recipe Updating/Creation

        private Panel createPanel(Recipe recipe)
        {

            Panel newPanel = new Panel();
            newPanel.BackColor = Color.SlateGray;
            newPanel.Size = new Size(502, 50);

            newPanel.Name = "Recipe-";

            newPanel.Controls.Add(createTitle(recipe));
            newPanel.Controls.Add(createTags(recipe));
            newPanel.Controls.Add(bookmarkLabel(recipe));

            return newPanel;
        }

        private Label createTitle(Recipe recipe)
        {

            Label label = new Label();
            label.Text = recipe.getName();
            label.Font = new Font("Microsoft Sans Serif", 14);
            label.Size = new Size(300, 24);

            return label;
        }

        private Label createTags(Recipe recipe)
        {

            Label label = new Label();

            String tags = "";

            foreach (String tag in recipe.getTags())
            {

                tags += tag + ", ";
            }

            label.Text = tags;

            label.Font = new Font("Microsoft Sans Serif", 7);
            label.Size = new Size(300, 24);
            label.Location = new Point(2, 30);

            return label;
        }

        private PictureBox bookmarkLabel(Recipe recipe)
        {

            PictureBox image = new PictureBox();
            image.Image = Resources.bookmark_icon;
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Size = new Size(20, 18);
            image.Location = new Point(475, 5);

            return image;
        }

        private void updateNoBookmarkLabel()
        {

            if (RecipeManager.recipeSize() > 0)
            {
                NoBookmarksLabel.Visible = false;
            }
            else
            {
                NoBookmarksLabel.Visible = true;
            }
        }

        //SQL Server Methods

        private void SQLserver()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true";

            string createDbQuery = "CREATE DATABASE recipies";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(createDbQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine("LocalDB database 'recipie' created successfully");

                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
