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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Recipe createdRecipe = new Recipe("Recipe Name");
            createdRecipe.addRecipeTag("TEST");
            createdRecipe.addRecipeTag("TEST2");
            createdRecipe.addRecipeTag("TEST3");

            RecipeManager.addRecipe(createdRecipe);

            RecipeLayoutPanel.Controls.Add(createPanel(createdRecipe));

            TabPage createdTab = new TabPage(createdRecipe.getName());

            RecipeTabControl.TabPages.Add(createdTab);

            updateNoBookmarkLabel();
        }

        //Search Bar Functionality

        private void SearchInputText_TextChanged(object sender, EventArgs e)
        {
            Console.Write("TEST");
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
