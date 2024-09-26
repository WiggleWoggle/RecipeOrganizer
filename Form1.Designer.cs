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
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.Home = new System.Windows.Forms.TabPage();
            this.SearchLabel = new System.Windows.Forms.TextBox();
            this.SearchInputText = new System.Windows.Forms.TextBox();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.RecipeLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.RecipeTabControl = new System.Windows.Forms.TabControl();
            this.NoBookmarksLabel = new System.Windows.Forms.Label();
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
            this.Home.Controls.Add(this.NoBookmarksLabel);
            this.Home.Controls.Add(this.button1);
            this.Home.Controls.Add(this.RecipeLayoutPanel);
            this.Home.Controls.Add(this.ResultsLabel);
            this.Home.Controls.Add(this.SearchInputText);
            this.Home.Controls.Add(this.SearchLabel);
            this.Home.Location = new System.Drawing.Point(4, 22);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(617, 662);
            this.Home.TabIndex = 1;
            this.Home.Text = "Home";
            // 
            // SearchLabel
            // 
            this.SearchLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SearchLabel.Location = new System.Drawing.Point(57, 22);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.ReadOnly = true;
            this.SearchLabel.Size = new System.Drawing.Size(41, 20);
            this.SearchLabel.TabIndex = 4;
            this.SearchLabel.Text = "Search";
            // 
            // SearchInputText
            // 
            this.SearchInputText.Location = new System.Drawing.Point(97, 22);
            this.SearchInputText.Name = "SearchInputText";
            this.SearchInputText.Size = new System.Drawing.Size(461, 20);
            this.SearchInputText.TabIndex = 5;
            this.SearchInputText.Text = "...";
            this.SearchInputText.TextChanged += new System.EventHandler(this.SearchInputText_TextChanged);
            // 
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Location = new System.Drawing.Point(54, 58);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(45, 13);
            this.ResultsLabel.TabIndex = 7;
            this.ResultsLabel.Text = "Results:";
            // 
            // RecipeLayoutPanel
            // 
            this.RecipeLayoutPanel.AutoScroll = true;
            this.RecipeLayoutPanel.Location = new System.Drawing.Point(53, 74);
            this.RecipeLayoutPanel.Name = "RecipeLayoutPanel";
            this.RecipeLayoutPanel.Size = new System.Drawing.Size(564, 588);
            this.RecipeLayoutPanel.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(483, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add Recipe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // NoBookmarksLabel
            // 
            this.NoBookmarksLabel.AutoSize = true;
            this.NoBookmarksLabel.Location = new System.Drawing.Point(228, 58);
            this.NoBookmarksLabel.Name = "NoBookmarksLabel";
            this.NoBookmarksLabel.Size = new System.Drawing.Size(170, 13);
            this.NoBookmarksLabel.TabIndex = 10;
            this.NoBookmarksLabel.Text = "You have no bookmarked recipes.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(642, 686);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.RecipeTabControl);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel RecipeLayoutPanel;
        private System.Windows.Forms.Label ResultsLabel;
        private System.Windows.Forms.TextBox SearchInputText;
        private System.Windows.Forms.TextBox SearchLabel;
        private System.Windows.Forms.TabControl RecipeTabControl;
        private System.Windows.Forms.Label NoBookmarksLabel;
    }
}

