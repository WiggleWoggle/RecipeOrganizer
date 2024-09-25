using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Console.Write("TEST");

            RecipeLayoutPanel.Controls.Add(createPanel());
        }

        private Panel createPanel()
        {

            Panel newPanel = new Panel();
            newPanel.BackColor = Color.SlateGray;
            newPanel.Size = new Size(502, 129);
            newPanel.Name = "Recipe-";

            Label label = new Label();
            label.Text = "TEST";

            return newPanel;
        }
    }       
}
