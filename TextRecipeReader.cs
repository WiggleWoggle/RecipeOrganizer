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

            //Have the user select a file directory
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                String directory = dialog.SelectedPath;

                //Have the user save the file to the location
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
                    {
                        using (var writer = new StreamWriter(file))
                        {

                            //Formatting the file
                            writer.WriteLine("# " + recipe.getName());
                            writer.WriteLine("");
                            writer.WriteLine("# Prep Time");
                            writer.WriteLine(recipe.getPrepTime());
                            writer.WriteLine("");
                            writer.WriteLine("# Tags");

                            foreach (String tag in recipe.getTags())
                            {
                                writer.WriteLine("," + tag);
                            }

                            writer.WriteLine("");
                            writer.WriteLine("# Ingredients");

                            foreach (String ingredient in recipe.getIngredients())
                            {
                                writer.WriteLine("." + ingredient);
                            }

                            writer.WriteLine("");
                            writer.WriteLine("# Instructions");

                            foreach (String instruction in recipe.getInstructions())
                            {
                                writer.WriteLine("-" + instruction);
                            }

                            writer.WriteLine("");
                            writer.WriteLine("# Image URL");
                            writer.WriteLine(recipe.getImage());

                            writer.Dispose();

                            //Success box
                            DialogResult informDelete = MessageBox.Show("Successfully exported recipe " + "\"" + recipe.getName() + "\"" + ".", "Exported Recipe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        public static Recipe importRecipeFromFile()
        {
            //Have the user select the file
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select Recipe File";
            dialog.InitialDirectory = @"C:\";
            dialog.Filter = "Text File (*.txt)|*.txt";
            dialog.FilterIndex = 1;

            DialogResult result = dialog.ShowDialog();

            Recipe builtRecipe = new Recipe();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                //Initialize line to read from
                String line;
                try
                {
                    //Initialize streamreader and move to line 1
                    StreamReader reader = new StreamReader(dialog.FileName);
                    line = reader.ReadLine();

                    //Line 1 is always the name
                    line = line.Remove(0, 2);

                    if (!recipeAlreadyExists(line))
                    {
                        builtRecipe.setName(line);

                        line = skipLines(line, reader, 3);

                        //Line 3 is always prep time
                        builtRecipe.setPrepTime(line);

                        //Skip to next known info
                        line = skipLines(line, reader, 3);

                        //Get all ingredients from the format we made on export
                        List<String> tags = new List<String>();

                        while (line.Contains(","))
                        {
                            line = line.Remove(0, 1);
                            tags.Add(line);
                            line = reader.ReadLine();
                        }

                        //Skip to next known info
                        line = skipLines(line, reader, 3);

                        //Get all ingredients from the format we made on export
                        List<String> ingredients = new List<String>();

                        while (line.Contains("."))
                        {
                            line = line.Remove(0, 1);
                            ingredients.Add(line);
                            line = reader.ReadLine();
                        }

                        //Skip to next known info
                        line = skipLines(line, reader, 3);

                        //Get all instructions from the format we made on export
                        List<String> instructions = new List<String>();

                        while (line.Contains("-"))
                        {
                            line = line.Remove(0, 1);
                            instructions.Add(line);
                            line = reader.ReadLine();
                        }

                        //Skip to next known info
                        line = skipLines(line, reader, 2);

                        String url = "";

                        //Build the url off the remaining lines since nothing should follow after
                        while (line != null)
                        {
                            url += line;
                            line = reader.ReadLine();
                        }

                        //Set the instructions, ingredient, and url of the recipe off the information we just got
                        builtRecipe.setTags(tags);
                        builtRecipe.setIngredients(ingredients);
                        builtRecipe.setInstructions(instructions);
                        builtRecipe.setImage(url);

                        reader.Close();
                    } else
                    {
                        DialogResult imformError = MessageBox.Show("Error importing recipe: " + "Recipe already exists.", "Invalid Recipe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        reader.Close();

                        return null;
                    }
                }
                catch (Exception e)
                {
                    DialogResult imformError = MessageBox.Show("Error importing recipe: " + e.Message, "Invalid Recipe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return builtRecipe;
        }

        private static String skipLines(String line, StreamReader reader, int skip)
        {
            for (int i = 0; i < skip; i++)
            {
                line = reader.ReadLine();
            }

            return line;
        }

        private static bool recipeAlreadyExists(String name)
        {
            foreach (Recipe recipe in RecipeManager.recipes)
            {
                if (recipe.getName().Equals(name))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
