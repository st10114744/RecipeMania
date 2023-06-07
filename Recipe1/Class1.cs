using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
//***************************************************************************oooo0000----BEGIN CLASS----0000OOOO*****************************************************************************
namespace Recipe1
{
    // Delegate to handle recipe calories over 300
    public delegate void RecipeCaloriesExceededEventHandler(string recipeName);
    public class Class1
    {
        // Event to be raised when recipe calories are over 300
        public event RecipeCaloriesExceededEventHandler RecipeCaloriesExceeded;

        //--------------------------------------------------------------------------------------------------------------//
        // Declare variables
        private List<string> prodNames;
        private List<List<string>> names;
        private List<List<double>> quantities;
        private List<List<string>> units;
        private List<List<double>> calories;
        private List<List<string>> foodGroups;
        private List<List<string>> steps;

        //--------------------------------------------------------------------------------------------------------------//

        // Default constructor
        //--------------------------------------------------------------------------------------------------------------//
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
        //--------------------------------------------------------------------------------------------------------------//

        // Welcome method
        //--------------------------------------------------------------------------------------------------------------//
        public void Intro()
        {
            Console.WriteLine("********WELCOME TO RECIPE MANIA********");
            Menu();
        }
        //--------------------------------------------------------------------------------------------------------------//



        // Display menu options
        //--------------------------------------------------------------------------------------------------------------//
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nMENU:");

                // Display menu options
                Console.WriteLine("1) New Recipe");
                Console.WriteLine("2) View Recipes");
                Console.WriteLine("3) Quit");

                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Input(); // Call the Input() method to create a new recipe
                        break;
                    case "2":
                        if (prodNames.Count == 0)
                        {
                            Console.WriteLine("There are no recipes. Please create a new recipe.");
                            Input(); // If there are no recipes, prompt the user to create a new recipe
                        }
                        else
                        {
                            ViewRecipes(); // Call the ViewRecipes() method to display the existing recipes
                        }
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0); // Exit the application
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------//


        //mehod to retreive user input
        //--------------------------------------------------------------------------------------------------------------//
        public void Input()
        {
            //try catch statements
            try
            {
                // Prompt the user to enter the name of the product they want to make
                Console.WriteLine("\nENTER THE NAME OF THE PRODUCT YOU WANT TO MAKE (or 'q' to quit):");
                string prodName = Console.ReadLine();

                if (prodName.ToLower() == "q")// if user enters q the application quits
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }

                // Add the product name to the list of product names
                prodNames.Add(prodName);

                // Prompt the user to enter the number of ingredients
                Console.Write("Number of ingredients: ");
                string numIngred = Console.ReadLine();
                int numIngredients;

                // Validate that the input is a valid integer
                while (!int.TryParse(numIngred, out numIngredients))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.Write("Number of ingredients: ");
                    numIngred = Console.ReadLine();
                }

                // Create lists to store the details of each ingredient
                List<string> ingredientNames = new List<string>();
                List<double> ingredientQuantities = new List<double>();
                List<string> ingredientUnits = new List<string>();
                List<double> ingredientCalories = new List<double>();
                List<string> ingredientFoodGroups = new List<string>();

                // Loop through each ingredient
                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter the details for ingredient #{i + 1}:");

                    // Prompt the user to enter the name of the ingredient
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    ingredientNames.Add(name);

                    // Prompt the user to enter the quantity of the ingredient
                    Console.Write("Quantity: ");
                    string input = Console.ReadLine();
                    double quantity;

                    // Validate that the input is a valid number
                    while (!double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out quantity))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.Write("Quantity: ");
                        input = Console.ReadLine();
                    }
                    ingredientQuantities.Add(quantity);

                    // Prompt the user to enter the unit of measurement for the ingredient
                    Console.Write("Unit of Measurement: ");
                    string unit = Console.ReadLine();

                    // make sure that the unit of measurement does not contain numbers
                    bool containsNumbers = unit.Any(char.IsDigit);
                    while (containsNumbers)
                    {
                        Console.WriteLine("Invalid input. Unit of measurement should not contain numbers.");
                        Console.Write("Unit of Measurement: ");
                        unit = Console.ReadLine();
                        containsNumbers = unit.Any(char.IsDigit);
                    }

                    ingredientUnits.Add(unit);

                    // ask the user to enter the number of calories for the ingredient
                    Console.Write("Calories: ");
                    string caloriesInput = Console.ReadLine();
                    double calories;

                    // make sure that the input is a valid number
                    while (!double.TryParse(caloriesInput, NumberStyles.Number, CultureInfo.InvariantCulture, out calories))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.Write("Calories: ");
                        caloriesInput = Console.ReadLine();
                    }
                    ingredientCalories.Add(calories);

                    // Display the food group options
                    Console.WriteLine("\nFood Group Options:");
                    Console.WriteLine("1. Starchy foods");
                    Console.WriteLine("2. Vegetables and fruits");
                    Console.WriteLine("3. Dry beans, peas, lentils, and soya");
                    Console.WriteLine("4. Chicken, fish, meat, and eggs");
                    Console.WriteLine("5. Milk and dairy products");
                    Console.WriteLine("6. Fats and oil");
                    Console.WriteLine("7. Water");

                    // ask the user to enter the food group for the ingredient
                    Console.Write("\nFood Group (enter the corresponding number): ");
                    string foodGroupInput = Console.ReadLine();
                    int foodGroupOption;

                    // Validate that the input is a valid number within the range 1-7
                    while (!int.TryParse(foodGroupInput, out foodGroupOption) || foodGroupOption < 1 || foodGroupOption > 7)
                    {
                        Console.WriteLine("/Invalid input. Please enter a valid number.");
                        Console.Write("Food Group (enter the corresponding number): ");
                        foodGroupInput = Console.ReadLine();
                    }

                    // case switch with diffferent food options for user to choose from
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

                    // Add the food group to the list of food groups
                    ingredientFoodGroups.Add(foodGroup);
                }

                // Add the ingredient details to their lists
                names.Add(ingredientNames);
                quantities.Add(ingredientQuantities);
                units.Add(ingredientUnits);
                calories.Add(ingredientCalories);
                foodGroups.Add(ingredientFoodGroups);

                // Call the IngredientSteps method to continue with the next step
                IngredientSteps();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering the recipe details:");
                Console.WriteLine(ex.Message);
                Input();
            }
        }
        //--------------------------------------------------------------------------------------------------------------//




        // Method for steps with ingredients
        //--------------------------------------------------------------------------------------------------------------//
        public void IngredientSteps()
        {
            // Prompt the user to enter the number of steps
            Console.Write("\n\nEnter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            // Create a list to store the recipe steps
            List<string> recipeSteps = new List<string>();

            for (int i = 0; i < numSteps; i++)
            {
                // Prompt the user to enter the description for each step
                Console.Write($"\nEnter the description for step #{i + 1}: ");
                string step = Console.ReadLine();

                // Add the step description to the list of recipe steps
                recipeSteps.Add(step);
            }

            // Add the recipe steps to the list of steps for the current recipe
            steps.Add(recipeSteps);

            // Call the DisplayReport() method to display the recipe report
            DisplayReport();
        }
        //--------------------------------------------------------------------------------------------------------------//


        // Invoke the RecipeCaloriesExceeded event by calling the delegate
        //--------------------------------------------------------------------------------------------------------------//
        protected virtual void OnRecipeCaloriesExceeded(string recipeName)
        {
            RecipeCaloriesExceeded?.Invoke(recipeName);
        }
        //--------------------------------------------------------------------------------------------------------------//


        //method to calculate calories
        //--------------------------------------------------------------------------------------------------------------//
        public double CalculateTotalCalories(List<double> ingredientCalories)
        {
            double totalCalories = ingredientCalories.Sum();
            return totalCalories;
        }
        //--------------------------------------------------------------------------------------------------------------//



        // method displaying the user input
        //--------------------------------------------------------------------------------------------------------------//
        public void DisplayReport()
        {
            // Get the index of the current recipe
            int recipeIndex = prodNames.Count - 1;

            // Display recipe name in uppercase
            Console.WriteLine($"\n*****{prodNames[recipeIndex].ToUpper()} RECIPE REPORT*****");
            Console.WriteLine($"\n\n\n*****{prodNames[recipeIndex].ToUpper()} Ingredients*****");

            // Display the ingredients of the recipe
            for (int i = 0; i < names[recipeIndex].Count; i++)
            {
                Console.WriteLine($"{names[recipeIndex][i]} : {quantities[recipeIndex][i]} {units[recipeIndex][i]}");
            }

            // Display recipe steps
            Console.WriteLine("\n*****Recipe Steps*****");
            for (int i = 0; i < steps[recipeIndex].Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[recipeIndex][i]}");
            }

            // Display food groups
            Console.WriteLine("\n*****FoodGroup*****");
            for (int i = 0; i < foodGroups[recipeIndex].Count; i++)
            {
                Console.WriteLine($"{i + 1}. {foodGroups[recipeIndex][i]}\n");
            }

            // Calculate total calories of the recipe
            List<double> ingredientCalories = calories[recipeIndex];
            double totalCalories = CalculateTotalCalories(ingredientCalories);

            // Display total calories
            Console.WriteLine($"\n------------------\nTotal Calories: {totalCalories}\n------------------");

            // Display scalable calorie intake guidelines
            Console.WriteLine("\n\n***SCALABLE CALORIE INTAKE***\n100-300: Good\n300-500: Decent\n500-700: Moderate\n700-900: High\n900-1000: Very high\n\n");

            // Check if calories exceed 300 and call the event
            if (totalCalories > 300)
            {
                // Sound an alert
                Console.Beep();

                // Invoke the RecipeCaloriesExceeded event
                OnRecipeCaloriesExceeded(prodNames[recipeIndex]);

                // Display a message about higher calorie content
                Console.WriteLine("\n\nA meal with more than 300 calories often has a larger caloric content. This could indicate a" +
                                  "\n meal that is heavier or more filling. When consuming meals with higher calorie counts, it's " +
                                  "\ncrucial to pay attention to portion sizes and the overall balance of nutrients. It's best to make " +
                                  "\nsure the meal contains a range of nutrient-rich foods to suit your nutritional needs. A well-rounded" +
                                  "\nand balanced diet can be maintained by watching portion sizes and including a variety of " +
                                  "\nvegetables, lean proteins, whole grains, and healthy fats.\n\n");
            }

            OptionReport();//calls the options menu method
        }
        //--------------------------------------------------------------------------------------------------------------//



        // Report displaying options for user to choose from
        //--------------------------------------------------------------------------------------------------------------//
        public void OptionReport()
        {
            //try ctach statement
            try
            {
                // Prompt the user to select an option
                Console.WriteLine("\nWOULD YOU LIKE TO?\n1) SCALE RECIPE\n2) CLEAR DATA AND RESTART\n3) VIEW RECIPES\n4) NEW RECIPE\n5) QUIT");
                string option = Console.ReadLine();
                int option1;

                // Validate the user's input
                while (!int.TryParse(option, out option1))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.Write("WOULD YOU LIKE TO?\n1) SCALE RECIPE\n2) CLEAR DATA AND RESTART\n3) VIEW RECIPES\n4) NEW RECIPE\n5) QUIT");
                    option = Console.ReadLine();
                }

                // Perform an action based on the selected option
                switch (option1)
                {
                    case 1:
                        ScaleReport();
                        break;
                    case 2:
                        ClearData();
                        break;
                    case 3:
                        // Check if there are any recipes available
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
                        // Exit the program
                        Environment.Exit(0);
                        break;
                    default:
                        // Handle invalid input
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

        //--------------------------------------------------------------------------------------------------------------//



        // Report showing the new scaled results
        //--------------------------------------------------------------------------------------------------------------//
        public void ScaleReport()
        {
            // Get the index of the latest recipe
            int recipeIndex = prodNames.Count - 1;

            // Prompt the user to enter the scale factor
            Console.Write("Scale quantities by: ");
            string scaleInput = Console.ReadLine();
            double scale;

            // Validate the user's input
            while (!double.TryParse(scaleInput, out scale))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Scale quantities by: ");
                scaleInput = Console.ReadLine();
            }

            // Display the scaled report header
            Console.WriteLine("\n\n*****SCALED REPORT*****");

            // Iterate through the ingredient quantities and scale them
            for (int i = 0; i < quantities[recipeIndex].Count; i++)
            {
                double scaledQuantity = quantities[recipeIndex][i] * scale;
                Console.WriteLine($"{names[recipeIndex][i]} : {scaledQuantity} {units[recipeIndex][i]}");
            }

            // Prompt the user to choose whether to revert to the original values or return to the option menu
            Console.WriteLine("Do you wish to go back to the original values?\n1) Yes\n2) No");
            string option = Console.ReadLine();
            int option1;

            // Validate the user's input
            while (!int.TryParse(option, out option1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Do you wish to go back to the original values?\n1) Yes\n2) No");
                option = Console.ReadLine();
            }

            // Perform the selected action
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
                // Handle invalid choice and return to the original values
                Console.WriteLine("Invalid choice. Going back to the original values.");
                DisplayReport();
            }
        }

        //--------------------------------------------------------------------------------------------------------------//



        // Method for clearing data of the current recipe
        //--------------------------------------------------------------------------------------------------------------//
        public void ClearData()
        {
            // Get the index of the latest recipe
            int recipeIndex = prodNames.Count - 1;

            // Remove the recipe data from the corresponding lists
            prodNames.RemoveAt(recipeIndex);
            names.RemoveAt(recipeIndex);
            quantities.RemoveAt(recipeIndex);
            units.RemoveAt(recipeIndex);
            steps.RemoveAt(recipeIndex);

            // Display a success message
            Console.WriteLine("Recipe data cleared successfully.");

            // Prompt the user to enter a new recipe
            Input();
        }

        //--------------------------------------------------------------------------------------------------------------//


        // method to view all the recipes
        //--------------------------------------------------------------------------------------------------------------//
        public void ViewRecipes()
        {
            // Display the heading for the recipe list
            Console.WriteLine("\n*****RECIPE LIST*****");

            // Sort the recipe names in alphabetical order
            List<string> sortedProdNames = prodNames.OrderBy(name => name).ToList();

            // Display the sorted recipe names with corresponding numbers
            for (int i = 0; i < sortedProdNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {sortedProdNames[i]}");
            }

            // Prompt the user to enter a recipe number or 'q' to quit
            Console.Write("Enter the recipe number to view details (or 'q' to quit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
            {
                // Quit option chosen, go back to the menu
                Console.WriteLine("Going back to the menu...");
                Menu();
            }
            else
            {
                // Parse the input as the recipe number
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

                // Get the index of the selected recipe
                int recipeIndex = recipeNumber - 1;

                // Display the details of the selected recipe
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

                Console.WriteLine("\n*****FoodGroup*****");
                for (int i = 0; i < foodGroups[recipeIndex].Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {foodGroups[recipeIndex][i]}\n");
                }

                // Calculate the total calories of the recipe
                double totalCalories = calories[recipeIndex].Sum();

                // Check if the total calories exceed 300 and call the event
                if (totalCalories > 300)
                {
                    OnRecipeCaloriesExceeded(prodNames[recipeIndex]);
                }

                // Display the options menu
                OptionReport();
            }
        }

        //--------------------------------------------------------------------------------------------------------------//




    }
}
//***************************************************************************oooo0000----END CLASS----0000OOOO*****************************************************************************

