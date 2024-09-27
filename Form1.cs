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
    public partial class Form1 : Form
    {

        private List<Recipe> displayedRecipes = new List<Recipe>();

        public Form1()
        {
            InitializeComponent();
            SQLserver();
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

            createPanel(recipe);
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

        private Label createDescription(Recipe recipe)
        {

            Label label = new Label();
            label.Text = recipe.getDescription();
            label.Font = new Font("Microsoft Sans Serif", 9);
            label.Size = new Size(300, 24);
            label.Location = new Point(2, 25);

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
    }       
}
