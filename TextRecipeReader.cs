using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeOrganizer
{
    internal class TextRecipeReader
    {
        public static void exportRecipeToFile(Recipe recipe)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                String directory = dialog.SelectedPath;

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.InitialDirectory = directory;
                saveDialog.Filter = "Text File (*.txt)|*.txt";
                saveDialog.FilterIndex = 1;
                saveDialog.FileName = recipe.getName();
                result = saveDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {

                    directory = directory + "/" + recipe.getName() + ".txt";

                    using (var file = File.Open(directory, FileMode.OpenOrCreate))
                    using (var writer = new StreamWriter(file))
                    {

                        //Formatting the file
                        writer.WriteLine("# " + recipe.getName());
                        writer.WriteLine("");
                        writer.WriteLine("# Prep Time");
                        writer.WriteLine(recipe.getPrepTime());
                        writer.WriteLine("");
                        writer.WriteLine("# Ingredients");

                        foreach (String ingredients in recipe.getIngredients())
                        {
                            writer.WriteLine("- " + ingredients);
                        }

                        writer.WriteLine("");
                        writer.WriteLine("# Instructions");

                        foreach (String instruction in recipe.getInstructions())
                        {
                            writer.WriteLine("- " + instruction);
                        }

                        writer.WriteLine("");
                        writer.WriteLine("# Image URL");
                        writer.WriteLine(recipe.getImage());

                        writer.Dispose();
                    }
                }
            }
        }

            public static void importRecipeFromFile()
        {
            string path = @"C:\";

            File.Create(path).Dispose();

            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine("The very first line!");
            }
        }
    }
}
