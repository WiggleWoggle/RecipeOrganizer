namespace RecipeOrganizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.Home = new System.Windows.Forms.TabPage();
            this.importButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.returnToHomeButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.NoResultsLabel = new System.Windows.Forms.Label();
            this.NoBookmarksLabel = new System.Windows.Forms.Label();
            this.RecipeLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.SearchInputText = new System.Windows.Forms.TextBox();
            this.RecipeTabControl = new System.Windows.Forms.TabControl();
            this.button2 = new System.Windows.Forms.Button();
            this.Home.SuspendLayout();
            this.RecipeTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(644, 131);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(80, 17);
            this.hScrollBar1.TabIndex = 4;
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Home.Controls.Add(this.importButton);
            this.Home.Controls.Add(this.refreshButton);
            this.Home.Controls.Add(this.returnToHomeButton);
            this.Home.Controls.Add(this.searchButton);
            this.Home.Controls.Add(this.NoResultsLabel);
            this.Home.Controls.Add(this.NoBookmarksLabel);
            this.Home.Controls.Add(this.RecipeLayoutPanel);
            this.Home.Controls.Add(this.ResultsLabel);
            this.Home.Controls.Add(this.SearchInputText);
            this.Home.Location = new System.Drawing.Point(4, 22);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(617, 662);
            this.Home.TabIndex = 1;
            this.Home.Text = "Home (Bookmarks)";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(594, 45);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(23, 23);
            this.importButton.TabIndex = 15;
            this.importButton.Text = "↓";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(594, 19);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 23);
            this.refreshButton.TabIndex = 14;
            this.refreshButton.Text = "↻";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // returnToHomeButton
            // 
            this.returnToHomeButton.Location = new System.Drawing.Point(594, 19);
            this.returnToHomeButton.Name = "returnToHomeButton";
            this.returnToHomeButton.Size = new System.Drawing.Size(23, 23);
            this.returnToHomeButton.TabIndex = 13;
            this.returnToHomeButton.Text = "←";
            this.returnToHomeButton.UseVisualStyleBackColor = true;
            this.returnToHomeButton.Visible = false;
            this.returnToHomeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.searchButton.Location = new System.Drawing.Point(53, 20);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(58, 23);
            this.searchButton.TabIndex = 12;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // NoResultsLabel
            // 
            this.NoResultsLabel.AutoSize = true;
            this.NoResultsLabel.Location = new System.Drawing.Point(94, 58);
            this.NoResultsLabel.Name = "NoResultsLabel";
            this.NoResultsLabel.Size = new System.Drawing.Size(57, 13);
            this.NoResultsLabel.TabIndex = 11;
            this.NoResultsLabel.Text = "No results.";
            this.NoResultsLabel.Visible = false;
            // 
            // NoBookmarksLabel
            // 
            this.NoBookmarksLabel.AutoSize = true;
            this.NoBookmarksLabel.Location = new System.Drawing.Point(228, 58);
            this.NoBookmarksLabel.Name = "NoBookmarksLabel";
            this.NoBookmarksLabel.Size = new System.Drawing.Size(170, 13);
            this.NoBookmarksLabel.TabIndex = 10;
            this.NoBookmarksLabel.Text = "You have no bookmarked recipes.";
            // 
            // RecipeLayoutPanel
            // 
            this.RecipeLayoutPanel.AutoScroll = true;
            this.RecipeLayoutPanel.Location = new System.Drawing.Point(53, 74);
            this.RecipeLayoutPanel.Name = "RecipeLayoutPanel";
            this.RecipeLayoutPanel.Size = new System.Drawing.Size(564, 588);
            this.RecipeLayoutPanel.TabIndex = 8;
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Location = new System.Drawing.Point(54, 58);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(45, 13);
            this.ResultsLabel.TabIndex = 7;
            this.ResultsLabel.Text = "Results:";
            this.ResultsLabel.Visible = false;
            // 
            // SearchInputText
            // 
            this.SearchInputText.Location = new System.Drawing.Point(108, 22);
            this.SearchInputText.Name = "SearchInputText";
            this.SearchInputText.Size = new System.Drawing.Size(450, 20);
            this.SearchInputText.TabIndex = 5;
            this.SearchInputText.TextChanged += new System.EventHandler(this.SearchInputText_TextChanged);
            // 
            // RecipeTabControl
            // 
            this.RecipeTabControl.Controls.Add(this.Home);
            this.RecipeTabControl.ItemSize = new System.Drawing.Size(58, 18);
            this.RecipeTabControl.Location = new System.Drawing.Point(-1, 1);
            this.RecipeTabControl.Name = "RecipeTabControl";
            this.RecipeTabControl.SelectedIndex = 0;
            this.RecipeTabControl.Size = new System.Drawing.Size(625, 688);
            this.RecipeTabControl.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(639, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(642, 686);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.RecipeTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Recipe Organizer";
            this.Home.ResumeLayout(false);
            this.Home.PerformLayout();
            this.RecipeTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label Test;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.FlowLayoutPanel RecipeLayoutPanel;
        private System.Windows.Forms.Label ResultsLabel;
        private System.Windows.Forms.TextBox SearchInputText;
        private System.Windows.Forms.TabControl RecipeTabControl;
        private System.Windows.Forms.Label NoBookmarksLabel;
        private System.Windows.Forms.Label NoResultsLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button returnToHomeButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button importButton;
    }
}

