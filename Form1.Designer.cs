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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Home = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.RecipeLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ResultsLabel = new System.Windows.Forms.Label();
            this.SearchInputText = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.TextBox();
            this.Recipe1 = new System.Windows.Forms.TabPage();
            this.Recipe2 = new System.Windows.Forms.TabPage();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.tabControl1.SuspendLayout();
            this.Home.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Home);
            this.tabControl1.Controls.Add(this.Recipe1);
            this.tabControl1.Controls.Add(this.Recipe2);
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 18);
            this.tabControl1.Location = new System.Drawing.Point(-1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 688);
            this.tabControl1.TabIndex = 3;
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            // RecipeLayoutPanel
            // 
            this.RecipeLayoutPanel.AutoScroll = true;
            this.RecipeLayoutPanel.Location = new System.Drawing.Point(53, 74);
            this.RecipeLayoutPanel.Name = "RecipeLayoutPanel";
            this.RecipeLayoutPanel.Size = new System.Drawing.Size(564, 588);
            this.RecipeLayoutPanel.TabIndex = 8;
            // 
<<<<<<< HEAD
            // DefaultRecipePanel
            // 
            this.DefaultRecipePanel.BackColor = System.Drawing.Color.SlateGray;
            this.DefaultRecipePanel.Controls.Add(this.label13);
            this.DefaultRecipePanel.Controls.Add(this.RecipeDescription);
            this.DefaultRecipePanel.Controls.Add(this.label15);
            this.DefaultRecipePanel.Location = new System.Drawing.Point(3, 3);
            this.DefaultRecipePanel.Name = "DefaultRecipePanel";
            this.DefaultRecipePanel.Size = new System.Drawing.Size(502, 129);
            this.DefaultRecipePanel.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label13.Location = new System.Drawing.Point(3, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Recipe Tags";
            // 
            // RecipeDescription
            // 
            this.RecipeDescription.AutoSize = true;
            this.RecipeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.RecipeDescription.Location = new System.Drawing.Point(5, 37);
            this.RecipeDescription.Name = "RecipeDescription";
            this.RecipeDescription.Size = new System.Drawing.Size(122, 16);
            this.RecipeDescription.TabIndex = 1;
            this.RecipeDescription.Text = "Recipe Description";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label15.Location = new System.Drawing.Point(4, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 24);
            this.label15.TabIndex = 0;
            this.label15.Text = "Recipe Name";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
=======
>>>>>>> ede05476d1fc8055effc18bc9a65946dfdad5bfd
            // ResultsLabel
            // 
            this.ResultsLabel.AutoSize = true;
            this.ResultsLabel.Location = new System.Drawing.Point(54, 58);
            this.ResultsLabel.Name = "ResultsLabel";
            this.ResultsLabel.Size = new System.Drawing.Size(45, 13);
            this.ResultsLabel.TabIndex = 7;
            this.ResultsLabel.Text = "Results:";
            // 
            // SearchInputText
            // 
            this.SearchInputText.Location = new System.Drawing.Point(97, 22);
            this.SearchInputText.Name = "SearchInputText";
            this.SearchInputText.Size = new System.Drawing.Size(461, 20);
            this.SearchInputText.TabIndex = 5;
            this.SearchInputText.Text = "...";
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
            // Recipe1
            // 
            this.Recipe1.Location = new System.Drawing.Point(4, 22);
            this.Recipe1.Name = "Recipe1";
            this.Recipe1.Padding = new System.Windows.Forms.Padding(3);
            this.Recipe1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Recipe1.Size = new System.Drawing.Size(617, 662);
            this.Recipe1.TabIndex = 0;
            this.Recipe1.Text = "Recipe 1";
            this.Recipe1.UseVisualStyleBackColor = true;
            // 
            // Recipe2
            // 
            this.Recipe2.Location = new System.Drawing.Point(4, 22);
            this.Recipe2.Name = "Recipe2";
            this.Recipe2.Size = new System.Drawing.Size(617, 662);
            this.Recipe2.TabIndex = 2;
            this.Recipe2.Text = "Recipe 2";
            this.Recipe2.UseVisualStyleBackColor = true;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(644, 131);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(80, 17);
            this.hScrollBar1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(642, 686);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Recipe Organizer";
            this.tabControl1.ResumeLayout(false);
            this.Home.ResumeLayout(false);
            this.Home.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.TabPage Recipe1;
        private System.Windows.Forms.TextBox SearchInputText;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.TabPage Recipe2;
        private System.Windows.Forms.Label Test;
        private System.Windows.Forms.Label ResultsLabel;
        private System.Windows.Forms.TextBox SearchLabel;
        private System.Windows.Forms.FlowLayoutPanel RecipeLayoutPanel;
        private System.Windows.Forms.Button button1;
    }
}

