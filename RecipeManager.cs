using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeOrganizer
{
    internal class RecipeManager
    {

        public static List<Recipe> recipes = new List<Recipe>();

        //TODO: populate this list with bookmarked recipes saved in the sql server
        public static List<Recipe> bookmarkedRecipes = new List<Recipe>();

        public static List<RecipePage> pages = new List<RecipePage>();

        public static void addRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public static void addBookmarkedRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public static int recipeSize()
        {
            return recipes.Count; 
        }

        public static void initRecipes()
        {

            //Korean
            recipes.Add(new Recipe(1, "Bulgogi", "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2023%2F01%2F30%2F246172-Easy-Bulgogi-ddmfs-104-4x3-1.jpg&q=60&c=sc&poi=auto&orient=true&h=512", new DateTime(), "Korean", "Any", new List<String>(), new List<String>{"1/3 Cup Soy Sauce", "2 Green Onions", "1/4 Yellow Onion", "3 Tablespoons White Sugar", "3 Cloves Garlic Minced", "2 Tablespoons Toasted Seasame Seeds", "1 Tablespoon Seasame Oil", "1/4 Tablespoon Korean Red Pepper Flakes", "1/4 Teaspoon Minced Fresh Ginger", "1/8 Teaspoon Ground Black Pepper", "1 1/2 Pound Sterloin Steak", "1 Teaspoon Honey"}, new List<String> { "Korea", "Korean", "Korean Food", "Beef", "Barbeque", "Barbecue" }));
            recipes.Add(new Recipe(2, "Bibimbap", "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F08%2F26%2F228240-BibimbapKoreanRiceWithMixedVegtables-ddmfs-4X3-0667.jpg&q=60&c=sc&poi=auto&orient=true&h=512", new DateTime(), "Korean", "Any", new List<String>(), new List<String>(), new List<String> { "Korea", "Korean", "Korean Food", "Vegetables", "Rice", "Eggs", "Beef" }));
            recipes.Add(new Recipe(3, "Tteok-bokki", "https://futuredish.com/wp-content/uploads/Tteokbokki-3a.jpg", new DateTime(), "Korean", "Any", new List<String>(), new List<String>(), new List<String> { "Korea", "Korean", "Korean Food", "Spicy" }));
            
            //Chinese
            recipes.Add(new Recipe(4, "Baozi", "https://thewoksoflife.com/wp-content/uploads/2019/06/pork-baozi-11.jpg", new DateTime(), "Chinese", "Any", new List<String>(), new List<String>(), new List<String> { "China", "Chinese", "Chinese Food", "Steamed", "Pork", "Buns" }));
            recipes.Add(new Recipe(5, "Peking Duck", "https://ca-times.brightspotcdn.com/dims4/default/2e3a833/2147483647/strip/false/crop/4410x3528+0+0/resize/1486x1189!/quality/75/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2Fbf%2Fa9%2F0789235747e19dd8588df4fa9480%2Fnas-peking-duck.jpg", new DateTime(), "Chinese", "Summer", new List<String>(), new List<String>(), new List<String> { "China", "Chinese", "Chinese Food", "Duck", "Roasted" }));
            recipes.Add(new Recipe(6, "Egg Roll", "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F06%2F19%2F6406632-authentic-chinese-egg-rolls-from-a-chinese-person-moodtwofood-1x1-1.jpg&q=60&c=sc&poi=auto&orient=true&h=512", new DateTime(), "Chinese", "Summer", new List<String>(), new List<String>(), new List<String> { "China", "Chinese", "Chinese Food", "Egg", "Rolls" }));

            //Puerto Rican
            recipes.Add(new Recipe(7, "Sancocho", "https://loisa.com/cdn/shop/articles/IMG_9623.jpg?v=1698263417&width=1500", new DateTime(), "Puerto Rican", "Any", new List<String>(), new List<String>(), new List<String> { "Puerto Rico", "Puerto Rican", "Puerto Rican Food", "Vegetables", "Stew"}));
            recipes.Add(new Recipe(8, "Budin", "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F07%2F10%2F165102-budin-puerto-rican-bread-pudding-ddmfs-4x3-1.jpg&q=60&c=sc&poi=auto&orient=true&h=512", new DateTime(), "Puerto Rican", "Any", new List<String>(), new List<String>(), new List<String> { "Puerto Rico", "Puerto Rican", "Puerto Rican Food", "Pudding", "Cinnamon" }));
            recipes.Add(new Recipe(9, "Mofongo", "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2022%2F08%2F09%2F670704-mofongo-LYNNINMA-4x3-1.jpg&q=60&c=sc&poi=auto&orient=true&h=512", new DateTime(), "Puerto Rican", "Any", new List<String>(), new List<String>(), new List<String> { "Puerto Rico", "Puerto Rican", "Puerto Rican Food", "Plantains", "Mashed" }));

            //Mexican
            recipes.Add(new Recipe(10, "Birria Tacos", "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F43%2F2021%2F10%2F22%2FIMG_0319-2000.jpg&q=60&c=sc&poi=auto&orient=true&h=512", new DateTime(), "Mexican", "Any", new List<String>(), new List<String>(), new List<String> { "Mexico", "Mexican", "Mexican Food", "Beef", "Tacos" }));
            recipes.Add(new Recipe(11, "Strawberry Tres Leches Cake", "https://www.dinnerin321.com/wp-content/uploads/2023/04/3251FC5A-1293-4805-A861-1FCF452F0377-1024x1024.jpeg", new DateTime(), "Mexican", "Any", new List<String>(), new List<String>(), new List<String> { "Mexico", "Mexican", "Mexican Food", "Cake", "Strawberry" }));
            recipes.Add(new Recipe(12, "Guacamole", "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F848092.jpg&q=60&c=sc&poi=auto&orient=true&h=512", new DateTime(), "Mexican", "Any", new List<String>(), new List<String>(), new List<String> { "Mexico", "Mexican", "Mexican Food", "Avacado", "Spicy" }));

            //Italian
            recipes.Add(new Recipe(13, "Baked Chicken Marinara", "https://therecipecritic.com/wp-content/uploads/2023/08/chicken_marinara-2-1200x1799.jpg", new DateTime(), "Italian", "Any", new List<String>(), new List<String>(), new List<String> { "Italy", "Italian", "Italian Food", "Chicken", "Noodles", "Pasta" }));
            recipes.Add(new Recipe(14, "Tuscan Butter Shrimp", "https://www.lemonblossoms.com/wp-content/uploads/2023/08/Tuscan-Shrimp-Recipe-S4.jpg", new DateTime(), "Italian", "Any", new List<String>(), new List<String>(), new List<String> { "Italy", "Italian", "Italian Food", "Shrimp", "Noodles", "Pasta" }));
            recipes.Add(new Recipe(15, "Cannoli Pie", "https://www.cookiedoughandovenmitt.com/wp-content/uploads/2021/01/Cannoli-Cream-Pie-Square-500x500.jpg", new DateTime(), "Italian", "Any", new List<String>(), new List<String>(), new List<String> { "Italy", "Italian", "Italian Food", "Pie", "Cannoli", "No Bake" }));

            //Indian
            recipes.Add(new Recipe(16, "Garlin Onion Naan", "https://ik.imagekit.io/littlecook/public_images/recipes/green-onion-garlic-naan-bread.jpg", new DateTime(), "Indian", "Any", new List<String>(), new List<String>(), new List<String> { "India", "Indian", "Indian Food", "Bread", "Garlic" }));
            recipes.Add(new Recipe(17, "Tandoori Chicken", "https://www.allrecipes.com/thmb/ygY1JXP8_IkDSjPPW5VH2dTiMMU=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/50347-indian-tandoori-chicken-DDMFS-4x3-3035-205e98c80b2f4275b5bd010c396d9149.jpg", new DateTime(), "Indian", "Any", new List<String>(), new List<String>(), new List<String> { "India", "Indian", "Indian Food", "Chicken", "Yogut", "Spicy" }));
            recipes.Add(new Recipe(18, "Golden Butter Rice", "https://img.freepik.com/premium-photo/golden-butter-rice-with-new-zealand-herbs_1106454-142312.jpg", new DateTime(), "Indian", "Any", new List<String>(), new List<String>(), new List<String> { "India", "Indian", "Indian Food", "Rice", "Butter" }));

            //Greek
            recipes.Add(new Recipe(19, "Plum Cake", "https://preppykitchen.com/wp-content/uploads/2023/11/Plum-Cake-Feature.jpg", new DateTime(), "Greek", "Any", new List<String>(), new List<String>(), new List<String> { "Greece", "Greek", "Greek Food", "Sponge Cake", "Cake", "Plum" }));
            recipes.Add(new Recipe(29, "Gyro Meat", "https://tastesbetterfromscratch.com/wp-content/uploads/2023/07/Gyros-1.jpg", new DateTime(), "Greek", "Any", new List<String>(), new List<String>(), new List<String> { "Greece", "Greek", "Greek Food", "Beef", "Meatloaf" }));
            recipes.Add(new Recipe(21, "Pastitsio", "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_1:1/k%2FPhoto%2FRecipes%2F2021-04-Pastitsio-Greek-Orthodox-Easter%20%2F2021-04-29_52588", new DateTime(), "Greek", "Any", new List<String>(), new List<String>(), new List<String> { "Greece", "Greek", "Greek Food", "Pasta", "Cheese" }));


            //Jamaican
            recipes.Add(new Recipe(22, "Beef Patties", "https://gardengrubblog.com/wp-content/uploads/2021/08/Untitled-design-2021-08-08T212255.120.jpg", new DateTime(), "Jamaican", "Any", new List<String>(), new List<String>(), new List<String> { "Jamaica", "Jamaican", "Jamaican Food", "Beef", "Patty", "Patties" }));
            recipes.Add(new Recipe(23, "Brown Stew Chicken", "https://www.myforkinglife.com/wp-content/uploads/2020/09/brown-stew-chicken-cropped-2.jpg", new DateTime(), "Jamaican", "Any", new List<String>(), new List<String>(), new List<String> { "Jamaica", "Jamaican", "Jamaican Food", "Stew", "Chicken" }));
            recipes.Add(new Recipe(24, "Fried Snapper", "https://www.jcskitchen.com/Files/Bulletins%20Folders/3563_1_32_Thumb.jpg", new DateTime(), "Jamaican", "Any", new List<String>(), new List<String>(), new List<String> { "Jamaica", "Jamaican", "Jamaican Food", "Fish", "Fried" }));

            //Japanese
            recipes.Add(new Recipe(25, "Miso Soup", "https://silkroadrecipes.com/wp-content/uploads/2022/12/Miso-Soup-Recipe-square.jpg", new DateTime(), "Japanese", "Any", new List<String>(), new List<String>(), new List<String> { "Japan", "Japanese", "Japanese Food", "Soup", "Kelp" }));
            recipes.Add(new Recipe(26, "Beef Ramen", "https://peaceloveandlowcarb.com/wp-content/uploads/2020/11/Beef-Ramen-Low-Carb-Peace-Love-and-Low-Carb-.jpg", new DateTime(), "Japanese", "Any", new List<String>(), new List<String>(), new List<String> { "Japan", "Japanese", "Japanese Food", "Beef", "Meat", "Soup" }));
            recipes.Add(new Recipe(27, "Teriyaki", "https://www.onceuponachef.com/images/2024/01/chicken-teriyaki-1200x1553.jpg", new DateTime(), "Japanese", "Any", new List<String>(), new List<String>(), new List<String> { "Japan", "Japanese", "Japanese Food", "Chicken", "Soy Sauce", "Soup" }));

            //Soul Food
            recipes.Add(new Recipe(28, "Buttermilk Fried Chicken", "https://www.allrecipes.com/thmb/WSSoRAz2IygrMPkiJxHPbt9gqMg=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/8635-southern-fried-chicken-ddmfs_4x3-90736ab31a7a4bb59eb04e2380ccebe7.jpg", new DateTime(), "Soul Food", "Any", new List<String>(), new List<String>(), new List<String> { "Soul Food", "Soul", "Southern", "Chicken", "Fried", "Buttermilk" }));
            recipes.Add(new Recipe(29, "Southern Catfish", "https://houseofnasheats.com/wp-content/uploads/2022/12/Fried-Catfish-Square-1.jpg", new DateTime(), "Soul Food", "Any", new List<String>(), new List<String>(), new List<String> { "Soul Food", "Soul", "Southern", "Fish", "Fried", "Buttermilk" }));
            recipes.Add(new Recipe(30, "Fried Okra", "https://spicysouthernkitchen.com/wp-content/uploads/fried-okra-1.jpg", new DateTime(), "Soul Food", "Any", new List<String>(), new List<String>(), new List<String> { "Soul Food", "Soul", "Southern", "Vegetables", "Fried"}));
        }
    }
}
