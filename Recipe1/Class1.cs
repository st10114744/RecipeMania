using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Recipe1
{
    public class Class1
    {

       
        public delegate void RecipeCaloriesExceededEventHandler(string recipeName);
        public event RecipeCaloriesExceededEventHandler RecipeCaloriesExceeded;

        // Declare variables
        private List<string> prodNames;
        private List<List<string>> names;
        private List<List<double>> quantities;
        private List<List<string>> units;
        private List<List<double>> calories;
        private List<List<string>> foodGroups;
        private List<List<string>> steps;

        // Default constructor
        public Class1()
        {
            prodNames = new List<string>();
            names = new List<List<string>>();
            quantities = new List<List<double>>();
            units = new List<List<string>>();
            calories = new List<List<double>>();
            foodGroups = new List<List<string>>();
            steps = new List<List<string>>();
        }

        // Welcome method
        public void Intro()
        {
            Console.WriteLine("********WELCOME TO RECIPE MANIA********");
            Menu();
        }

        // Display menu options
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1) New Recipe");
                Console.WriteLine("2) View Recipes");
                Console.WriteLine("3) Quit");

                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Input();
                        break;
                    case "2":
                        if (prodNames.Count == 0)
                        {
                            Console.WriteLine("There are no recipes. Please create a new recipe.");
                            Input();
                        }
                        else
                        {
                            ViewRecipes();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        public void Input()
        {
            try
            {
                Console.WriteLine("\nENTER THE NAME OF THE PRODUCT YOU WANT TO MAKE (or 'q' to quit):");
                string prodName = Console.ReadLine();

                if (prodName.ToLower() == "q")
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }

                prodNames.Add(prodName);

                Console.Write("Number of ingredients: ");
                string numIngred = Console.ReadLine();
                int numIngredients;
                while (!int.TryParse(numIngred, out numIngredients))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.Write("Number of ingredients: ");
                    numIngred = Console.ReadLine();
                }

                List<string> ingredientNames = new List<string>();
                List<double> ingredientQuantities = new List<double>();
                List<string> ingredientUnits = new List<string>();
                List<double> ingredientCalories = new List<double>();
                List<string> ingredientFoodGroups = new List<string>();

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter the details for ingredient #{i + 1}:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    ingredientNames.Add(name);

                    Console.Write("Quantity: ");
                    string input = Console.ReadLine();
                    double quantity;
                    while (!double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out quantity))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.Write("Quantity: ");
                        input = Console.ReadLine();
                    }
                    ingredientQuantities.Add(quantity);

                    Console.Write("Unit of Measurement: ");
                    string unit = Console.ReadLine();

                    bool containsNumbers = unit.Any(char.IsDigit);
                    while (containsNumbers)
                    {
                        Console.WriteLine("Invalid input. Unit of measurement should not contain numbers.");
                        Console.Write("Unit of Measurement: ");
                        unit = Console.ReadLine();
                        containsNumbers = unit.Any(char.IsDigit);
                    }

                    ingredientUnits.Add(unit);

                    Console.Write("Calories: ");
                    string caloriesInput = Console.ReadLine();
                    double calories;
                    while (!double.TryParse(caloriesInput, NumberStyles.Number, CultureInfo.InvariantCulture, out calories))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.Write("Calories: ");
                        caloriesInput = Console.ReadLine();
                    }
                    ingredientCalories.Add(calories);

                    Console.WriteLine("\nFood Group Options:");
                    Console.WriteLine("1. Starchy foods");
                    Console.WriteLine("2. Vegetables and fruits");
                    Console.WriteLine("3. Dry beans, peas, lentils, and soya");
                    Console.WriteLine("4. Chicken, fish, meat, and eggs");
                    Console.WriteLine("5. Milk and dairy products");
                    Console.WriteLine("6. Fats and oil");
                    Console.WriteLine("7. Water");

                    Console.Write("\nFood Group (enter the corresponding number): ");
                    string foodGroupInput = Console.ReadLine();
                    int foodGroupOption;
                    while (!int.TryParse(foodGroupInput, out foodGroupOption) || foodGroupOption < 1 || foodGroupOption > 7)
                    {
                        Console.WriteLine("/Invalid input. Please enter a valid number.");
                        Console.Write("Food Group (enter the corresponding number): ");
                        foodGroupInput = Console.ReadLine();
                    }

                    string foodGroup;
                    switch (foodGroupOption)
                    {
                        case 1:
                            foodGroup = "Starchy foods";
                            break;
                        case 2:
                            foodGroup = "Vegetables and fruits";
                            break;
                        case 3:
                            foodGroup = "Dry beans, peas, lentils, and soya";
                            break;
                        case 4:
                            foodGroup = "Chicken, fish, meat, and eggs";
                            break;
                        case 5:
                            foodGroup = "Milk and dairy products";
                            break;
                        case 6:
                            foodGroup = "Fats and oil";
                            break;
                        case 7:
                            foodGroup = "Water";
                            break;
                        default:
                            foodGroup = "";
                            break;
                    }

                    ingredientFoodGroups.Add(foodGroup);
                }

                names.Add(ingredientNames);
                quantities.Add(ingredientQuantities);
                units.Add(ingredientUnits);
                calories.Add(ingredientCalories);
                foodGroups.Add(ingredientFoodGroups);

                IngredientSteps();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering the recipe details:");
                Console.WriteLine(ex.Message);
                Input();
            }
        }




        // Method for steps with ingredients
        public void IngredientSteps()
        {
            Console.Write("\n\nEnter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            List<string> recipeSteps = new List<string>();

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"\nEnter the description for step #{i + 1}: ");
                string step = Console.ReadLine();
                recipeSteps.Add(step);
            }

            steps.Add(recipeSteps);

            DisplayReport();
        }

        // 
        protected virtual void OnRecipeCaloriesExceeded(string recipeName)
        {
            RecipeCaloriesExceeded?.Invoke(recipeName);
        }

        public double CalculateTotalCalories(List<double> ingredientCalories)
        {
            double totalCalories = ingredientCalories.Sum();
            return totalCalories;
        }

        // DisplayReport method
        public void DisplayReport()
        {
            int recipeIndex = prodNames.Count - 1;

            Console.WriteLine($"\n*****{prodNames[recipeIndex].ToUpper()} RECIPE REPORT*****");
            Console.WriteLine($"\n\n\n*****{prodNames[recipeIndex].ToUpper()} Ingredients*****");

            for (int i = 0; i < names[recipeIndex].Count; i++)
            {
                Console.WriteLine($"{names[recipeIndex][i]} : {quantities[recipeIndex][i]} {units[recipeIndex][i]}");
            }

            Console.WriteLine("\n*****Recipe Steps*****");
            for (int i = 0; i < steps[recipeIndex].Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[recipeIndex][i]}");
            }

            // Calculate total calories
            List<double> ingredientCalories = calories[recipeIndex];
            double totalCalories = CalculateTotalCalories(ingredientCalories);

            // Display total calories
            Console.WriteLine($"\n----------------Total Calories: {totalCalories}\n----------------");

            Console.WriteLine("\n\n***SCALABLE CALORIE INTAKE***\"100-300: Good\n300-500: Decent\n500-700: Moderate\n700-900: High\n900-1000: Very high");


            // Check if calories exceed 300 and call the event
            if (totalCalories > 300)
            {
                Console.Beep();
                OnRecipeCaloriesExceeded(prodNames[recipeIndex]);
                Console.WriteLine("\n\nA meal with more than 300 calories often has a larger caloric content. This could indicate a" +
                                  "\n meal that is heavier or more filling. When consuming meals with higher calorie counts, it's crucial to pay attention to portion " +
                                  "\nsizes and the overall balance of nutrients. It's best to make sure the meal contains" +
                                  "\n a range of nutrient-rich foods to suit your nutritional needs. A well-rounded and balanced diet" +
                                  "\n can be maintained by watching portion sizes and including a variety of vegetables, lean proteins, whole grains, and healthy fats.\n\n");


            }

            OptionReport();
        }


        // Report displaying options
        public void OptionReport()
        {
            try
            {
                Console.WriteLine("\nWOULD YOU LIKE TO?\n1) SCALE RECIPE\n2) CLEAR DATA AND RESTART\n3) VIEW RECIPES\n4) NEW RECIPE\n5) QUIT");
                string option = Console.ReadLine();
                int option1;
                while (!int.TryParse(option, out option1))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.Write("WOULD YOU LIKE TO?\n1) SCALE RECIPE\n2) CLEAR DATA AND RESTART\n3) VIEW RECIPES\n4) NEW RECIPE\n5) QUIT");
                    option = Console.ReadLine();
                }

                switch (option1)
                {
                    case 1:
                        ScaleReport();
                        break;
                    case 2:
                        ClearData();
                        break;
                    case 3:
                        if (prodNames.Count == 0)
                        {
                            Console.WriteLine("There are no recipes. Please create a new recipe.");
                            Input();
                        }
                        else
                        {
                            ViewRecipes();
                        }
                        break;
                    case 4:
                        Input();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT!");
                        OptionReport();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



        // Report showing the new scaled results
        public void ScaleReport()
        {
            int recipeIndex = prodNames.Count - 1;

            Console.Write("Scale quantities by: ");
            string scaleInput = Console.ReadLine();
            double scale;
            while (!double.TryParse(scaleInput, out scale))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Scale quantities by: ");
                scaleInput = Console.ReadLine();
            }

            Console.WriteLine("\n\n*****SCALED REPORT*****");
            for (int i = 0; i < quantities[recipeIndex].Count; i++)
            {
                double scaledQuantity = quantities[recipeIndex][i] * scale;
                Console.WriteLine($"{names[recipeIndex][i]} : {scaledQuantity} {units[recipeIndex][i]}");
            }

            Console.WriteLine("Do you wish to go back to the original values?\n1) Yes\n2) No");
            string option = Console.ReadLine();
            int option1;
            while (!int.TryParse(option, out option1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Do you wish to go back to the original values?\n1) Yes\n2) No");
                option = Console.ReadLine();
            }

            if (option1 == 1)
            {
                DisplayReport();
            }
            else if (option1 == 2)
            {
                OptionReport();
            }
            else
            {
                Console.WriteLine("Invalid choice. Going back to the original values.");
                DisplayReport();
            }
        }

           // Method for clearing data of the current recipe
            public void ClearData()
            {
                int recipeIndex = prodNames.Count - 1;

                prodNames.RemoveAt(recipeIndex);
                names.RemoveAt(recipeIndex);
                quantities.RemoveAt(recipeIndex);
                units.RemoveAt(recipeIndex);
                steps.RemoveAt(recipeIndex);

                Console.WriteLine("Recipe data cleared successfully.");
                Input();
            }
        

        // View all the recipes
        public void ViewRecipes()
        {
            Console.WriteLine("\n*****RECIPE LIST*****");
            List<string> sortedProdNames = prodNames.OrderBy(name => name).ToList();
            for (int i = 0; i < sortedProdNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {sortedProdNames[i]}");
            }


            Console.Write("Enter the recipe number to view details (or 'q' to quit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
            {
                Console.WriteLine("Going back to the menu...");
                Menu();
            }
            else
            {
                int recipeNumber;
                while (!int.TryParse(input, out recipeNumber) || recipeNumber < 1 || recipeNumber > prodNames.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a valid recipe number.");
                    Console.Write("Enter the recipe number to view details (or 'q' to quit): ");
                    input = Console.ReadLine();

                    if (input.ToLower() == "q")
                    {
                        Console.WriteLine("Going back to the menu...");
                        Menu();
                    }
                }

                int recipeIndex = recipeNumber - 1;

                Console.WriteLine($"\n\n\n*****{prodNames[recipeIndex].ToUpper()} INGREDIENTS*****");
                for (int i = 0; i < names[recipeIndex].Count; i++)
                {
                    Console.WriteLine($"{names[recipeIndex][i]} : {quantities[recipeIndex][i]} {units[recipeIndex][i]}");
                }

                Console.WriteLine("\n*****Steps*****");
                for (int i = 0; i < steps[recipeIndex].Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {steps[recipeIndex][i]}");
                }

                double totalCalories = calories[recipeIndex].Sum();
                if (totalCalories > 300)
                {
                    OnRecipeCaloriesExceeded(prodNames[recipeIndex]);
                }

                OptionReport();
            }
        }

        


    }
}
