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
            this.CenterToScreen();

            SQLserver();
        }

        private void displayRecipes()
        {
            RecipeLayoutPanel.Controls.Clear();

            int displayCount = 0;

            foreach (Recipe recipe in displayedRecipes)
            {

                displayCount++;

                buildRecipe(recipe);
            }

            NoResultsLabel.Text = displayCount.ToString() + " Results";
        }

        private void resetDisplayedToBookmarked()
        {

            RecipeManager.bookmarkedRecipes.Clear();

            foreach (Recipe recipe in RecipeManager.recipes)
            {
                if (recipe.isBookmarked())
                {
                    RecipeManager.bookmarkedRecipes.Add(recipe);
                }
            }

            displayedRecipes = RecipeManager.bookmarkedRecipes;

            if (!(displayedRecipes.Count > 0))
            {
                NoBookmarksLabel.Text = "You have no bookmarked recipes.";
            } else
            {
                if (displayedRecipes.Count == 1)
                {
                    NoBookmarksLabel.Text = "You have " + RecipeManager.bookmarkedRecipes.Count + " bookmarked recipe.";
                } else
                {
                    NoBookmarksLabel.Text = "You have " + RecipeManager.bookmarkedRecipes.Count + " bookmarked recipes.";
                }
            }
        }

        private void buildRecipe(Recipe recipe)
        {

            RecipeLayoutPanel.Controls.Add(createPanel(recipe));

            createPanel(recipe);

            //updateNoBookmarkLabel();
        }

        //Search Bar Functionality

        private void SearchInputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            searchMode(true);

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
                displayRecipes();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            searchMode(false);

            displayedRecipes.Clear();
            RecipeLayoutPanel.Controls.Clear();

            resetDisplayedToBookmarked();

            displayRecipes();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            displayedRecipes.Clear();
            RecipeLayoutPanel.Controls.Clear();
            resetDisplayedToBookmarked();
            displayRecipes();
        }

        private void searchMode(bool searchMode)
        {
            if (searchMode)
            {
                returnToHomeButton.Visible = true;
                NoBookmarksLabel.Visible = false;
                importButton.Visible = false;
                ResultsLabel.Visible = true;
                NoResultsLabel.Visible = true;
                refreshButton.Visible = false;
                TabPage page = RecipeTabControl.TabPages[0];
                page.Text = "Home (Search)";
            } else
            {
                SearchInputText.Text = "";
                returnToHomeButton.Visible = false;
                importButton.Visible = true;
                NoBookmarksLabel.Visible = true;
                ResultsLabel.Visible = false;
                NoResultsLabel.Visible = false;
                refreshButton.Visible = true;
                TabPage page = RecipeTabControl.TabPages[0];
                page.Text = "Home (Bookmarks)";
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

        //Recipe Display
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
                }
                else
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

        //Recipe Page Bookmark Button Functionality
        private void bookmark_Toggle_Click(object sender, EventArgs e)
        {
            PictureBox control = sender as PictureBox;

            foreach (Recipe recipe in RecipeManager.recipes)
            {
                if ((control.Name.Contains(recipe.getName())))
                {

                    if (recipe.isBookmarked())
                    {
                        recipe.toggleBookmark();
                        control.Image = Resources.bookmarkiconempty;
                        RecipeManager.bookmarkedRecipes.Remove(recipe);
                    }
                    else
                    {
                        recipe.toggleBookmark();
                        control.Image = Resources.bookmark_icon;
                        RecipeManager.bookmarkedRecipes.Add(recipe);
                    }
                }
            }
        }

        //Recipe Page Done Button Functionality
        private void doneButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            foreach (RecipePage page in RecipeManager.pages)
            {
                if (page.getDoneButton().Equals(button))
                {

                    button.Visible = false;

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

        //Recipe Page Edit Button Functionality
        private void editButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            foreach (RecipePage page in RecipeManager.pages)
            {
                if (page.getEditButton().Equals(button))
                {

                    button.Visible = false;

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
            }
        }

        //Recipe Page Exit Button Functionality
        private void exitButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            List<RecipePage> temp = RecipeManager.pages;

            foreach (RecipePage page in RecipeManager.pages)
            {
                if (page.getExitButton().Equals(button))
                {
                    if (page.getPageInEditing() == false)
                    {
                        RecipeTabControl.TabPages.Remove(RecipeTabControl.SelectedTab);
                        temp.Remove(page);
                    } else
                    {
                        DialogResult error = MessageBox.Show("Save your changes before exiting.", "Cannot Exit Recipe Page", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    break;
                }
            }

            RecipeManager.pages = temp;
        }

        //Export Button Functionality
        private void exportButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            List<RecipePage> temp = RecipeManager.pages;

            foreach (RecipePage page in RecipeManager.pages)
            {
                if (page.getExportButton().Equals(button))
                {
                    if (page.getPageInEditing() == false)
                    {
                        TextRecipeReader.exportRecipeToFile(page.getRecipe());
                    }
                    else
                    {
                        DialogResult error = MessageBox.Show("Cannot export recipe while being edited.", "Cannot Export Recipe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    break;
                }
            }
        }

        //Import Recipe
        private void button1_Click_1(object sender, EventArgs e)
        {
            Recipe builtRecipe = TextRecipeReader.importRecipeFromFile();

            if (builtRecipe != null)
            {
                DialogResult informDelete = MessageBox.Show("Successfully imported recipe " + "\"" + builtRecipe.getName() + "\"" + ".", "Imported Recipe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RecipeManager.addRecipe(builtRecipe);
            }
        }


        //Delete Button Functionality
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            List<RecipePage> temp = RecipeManager.pages;

            foreach (RecipePage page in RecipeManager.pages)
            {
                if (page.getDeleteButton().Equals(button))
                {
                    if (page.getPageInEditing() == false)
                    {

                        DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this recipe?", "Deleting Recipe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmDelete == DialogResult.Yes)
                        {
                            RecipeTabControl.TabPages.Remove(RecipeTabControl.SelectedTab);
                            RecipeManager.recipes.Remove(page.getRecipe());
                            temp.Remove(page);

                            RecipeLayoutPanel.Controls.Clear();
                            updateDisplayedRecipes("");
                            displayRecipes();

                            DialogResult informDelete = MessageBox.Show("Successfully deleted recipe " + "\"" + page.getRecipe().getName() + "\"" + ".", "Deleted Recipe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } else
                    {
                        DialogResult error = MessageBox.Show("Cannot delete recipe while being edited.", "Cannot Delete Recipe Page", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    break;
                }
            }

            RecipeManager.pages = temp;
        }

        private void addIngredientsButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            List<RecipePage> temp = RecipeManager.pages;
            Recipe recipeToBuild = null;

            foreach (RecipePage page in RecipeManager.pages)
            {
                if (page.getAddIngredientButton().Equals(button))
                {
                    Recipe cloned = page.getRecipe();
                    List<String> ingredients = cloned.getIngredients();
                    ingredients.Add("New Ingredient");

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
                    RecipeManager.recipes.Add(cloned);

                    recipeToBuild = cloned;

                    RecipeTabControl.TabPages.Remove(page.getTabPage());
                }
            }

            if (recipeToBuild != null)
            {
                createRecipeTab(recipeToBuild);
            }
        }

        private void addInstructionsButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            List<RecipePage> temp = RecipeManager.pages;
            Recipe recipeToBuild = null;

            foreach (RecipePage page in RecipeManager.pages)
            {
                if (page.getAddInstructionButton().Equals(button))
                {
                    Recipe cloned = page.getRecipe();
                    List<String> instructions = cloned.getInstructions();
                    instructions.Add("New Instruction");

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
                    RecipeManager.recipes.Add(cloned);

                    recipeToBuild = cloned;

                    RecipeTabControl.TabPages.Remove(page.getTabPage());
                }
            }

            if (recipeToBuild != null)
            {
                createRecipeTab(recipeToBuild);
            }
        }

        private void createRecipeTab(Recipe recipe)
        {
            TabPage newTabPage = new TabPage(recipe.getName());

            if (!recipeAlreadyOpenInAnotherTab(newTabPage))
            {

                RecipeTabControl.TabPages.Add(newTabPage);
                RecipePage recipePage = UIBuilder.buildRecipePage(newTabPage, recipe);

                PictureBox bookmarkLabel = recipePage.getBookmarkPicture();

                bookmarkLabel.Click += bookmark_Toggle_Click;
                recipePage.getEditButton().Click += editButton_Click;
                recipePage.getDoneButton().Click += doneButton_Click;
                recipePage.getExitButton().Click += exitButton_Click;
                recipePage.getDeleteButton().Click += deleteButton_Click;
                recipePage.getExportButton().Click += exportButton_Click;
                recipePage.getAddIngredientButton().Click += addIngredientsButton_Click;
                recipePage.getAddInstructionButton().Click += addInstructionsButton_Click;

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
