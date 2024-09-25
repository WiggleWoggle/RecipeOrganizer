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
            SQLserver();
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

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
