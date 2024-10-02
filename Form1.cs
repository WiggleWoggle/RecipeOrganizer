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

        private List<Recipe> displayedRecipes = new List<Recipe>();
        private Random random;

        public Form1()
        {

            random = new Random();

            InitializeComponent();
            SQLserver();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Recipe createdRecipe = new Recipe("Recipe Name " + random.Next(1, 101));
            createdRecipe.addRecipeTag("TEST");
            createdRecipe.addRecipeTag("TEST2");
            createdRecipe.addRecipeTag("TEST3");

            RecipeManager.bookmarkedRecipes.Add(createdRecipe);
            displayedRecipes.Add(createdRecipe);

            displayRecipes();
        }

        private void displayRecipes()
        {
            clearRecipes();

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

            displayedRecipes = RecipeManager.bookmarkedRecipes;
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
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            TextBox textBox = SearchInputText;
            if (textBox != null)
            {
                clearRecipes();
                updateDisplayedRecipes(textBox.Text);
                displayRecipes();
            }
            else
            {
                resetDisplayedToBookmarked();
            }
        }

        private void updateDisplayedRecipes(String textboxString)
        {

            List<Recipe> temp = new List<Recipe>();

            foreach (Recipe recipe in RecipeManager.bookmarkedRecipes)
            {

                if (recipe.getName().Contains(textboxString)) {

                    temp.Add(recipe);
                }
            }

            displayedRecipes = temp;
        }

        //Click Handler
        private void recipe_Click(object sender, EventArgs e)
        {

            Panel panel = sender as Panel;
            panel.BackColor = Color.White;

            if (!foundRecipe(panel))
            {
                RecipeLayoutPanel.Controls.Remove(panel);
            }
        }

        private bool foundRecipe(Panel panel)
        {

            foreach (Recipe recipe in displayedRecipes)
            {
                if (recipe.getSyncedPanel().Name.Equals(panel.Name))
                {
                    TabPage newTabPage = new TabPage(recipe.getName());

                    RecipeTabControl.TabPages.Add(newTabPage);

                    return true;
                }
            }

            return false;
        }

        //UI Recipe Updating/Creation

        private Panel createPanel(Recipe recipe)
        {

            Panel newPanel = new Panel();
            newPanel.BackColor = Color.SlateGray;
            newPanel.Size = new Size(502, 50);

            newPanel.Name = "Recipe-" + recipe.getName();

            newPanel.Click += recipe_Click;

            newPanel.Controls.Add(createTitle(recipe));
            newPanel.Controls.Add(createTags(recipe));
            newPanel.Controls.Add(bookmarkLabel(recipe));

            recipe.setSyncedPanel(newPanel);

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
