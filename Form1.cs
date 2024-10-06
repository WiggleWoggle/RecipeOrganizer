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

        public Form1()
        {

            RecipeManager.initRecipes();

            InitializeComponent();

            this.MaximumSize = new System.Drawing.Size(640, 729);
            this.MinimumSize = this.MaximumSize;

            SQLserver();
        }

        private void displayRecipes()
        {
            RecipeLayoutPanel.Controls.Clear();

            foreach (Recipe recipe in displayedRecipes)
            {
                buildRecipe(recipe);
            }
        }

        private void resetDisplayedToBookmarked()
        {

            displayedRecipes = RecipeManager.bookmarkedRecipes;
        }

        private void buildRecipe(Recipe recipe)
        {

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
                RecipeLayoutPanel.Controls.Clear();
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

            displayedRecipes.Clear();

            foreach (Recipe recipe in RecipeManager.recipes)
            {
                String recipeName = recipe.getName();
                if (recipeName.IndexOf(textboxString, 0, StringComparison.OrdinalIgnoreCase) != -1)
                {

                    displayedRecipes.Add(recipe);
                } else
                {
                    foreach (String tagName in recipe.getTags())
                    {
                        if (tagName.IndexOf(textboxString, 0, StringComparison.OrdinalIgnoreCase) != -1)
                        {

                            displayedRecipes.Add(recipe);
                            break;
                        }
                    }
                }
            }
        }

        //Click Handler
        private void recipe_Click(object sender, EventArgs e)
        {

            Panel panel = sender as Panel;

            if (!foundRecipe(panel))
            {
                RecipeLayoutPanel.Controls.Remove(panel);
            }
        }

        private void control_Click(object sender, EventArgs e)
        {

            Control control = sender as Control;

            foreach (Panel panel in RecipeLayoutPanel.Controls)
            {
                if (panel.Controls.Contains(control))
                {
                    if (!foundRecipe(panel))
                    {
                        RecipeLayoutPanel.Controls.Remove(panel);
                    }
                }
            }
        }

        private bool foundRecipe(Panel panel)
        {

            foreach (Recipe recipe in displayedRecipes)
            {
                if (recipe.getSyncedPanel().Name.Equals(panel.Name))
                {

                    createRecipeTab(recipe);

                    return true;
                }
            }

            return false;
        }

        private void createRecipeTab(Recipe recipe)
        {

            TabPage newTabPage = new TabPage(recipe.getName());

            if (!recipeAlreadyOpenInAnotherTab(newTabPage))
            {

                RecipeTabControl.TabPages.Add(newTabPage);
                UIBuilder.buildRecipePage(newTabPage, recipe);
                RecipeTabControl.SelectedTab = newTabPage;
            }
        }

        private bool recipeAlreadyOpenInAnotherTab(TabPage newTab)
        {

            foreach (TabPage page in RecipeTabControl.TabPages)
            {
                if (page.Text.Equals(newTab.Text))
                {

                    RecipeTabControl.SelectedTab = page;

                    return true;
                }
            }

            return false;
        }

        //UI Recipe Updating/Creation

        private Panel createPanel(Recipe recipe)
        {

            Panel panel = UIBuilder.buildHomePagePanel(recipe);

            panel.Click += recipe_Click;

            foreach (Control control in panel.Controls)
            {
                if (control is Label || control is PictureBox)
                {
                    control.Click += control_Click;
                }
            }

            return panel;
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
