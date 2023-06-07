using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Recipe1
{
    internal class Class1
    {
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
            Input();
        }

        public void Input()
        {
            while (true)
            {
                Console.WriteLine("ENTER THE NAME OF THE PRODUCT YOU WANTING TO MAKE (or 'q' to quit):");
                string prodName = Console.ReadLine();

                if (prodName.ToLower() == "q")
                {
                    Console.WriteLine("Goodbye!");
                    break;
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

                    Console.Write("Food Group: ");
                    string foodGroup = Console.ReadLine();
                    ingredientFoodGroups.Add(foodGroup);
                }

                names.Add(ingredientNames);
                quantities.Add(ingredientQuantities);
                units.Add(ingredientUnits);
                calories.Add(ingredientCalories);
                foodGroups.Add(ingredientFoodGroups);

                IngredientSteps();
            }
        }

        // Method for steps with ingredients
        public void IngredientSteps()
        {
            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            List<string> recipeSteps = new List<string>();

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter the description for step #{i + 1}: ");
                string step = Console.ReadLine();
                recipeSteps.Add(step);
            }

            steps.Add(recipeSteps);

            DisplayReport();
        }

        // Method for displaying the report with ingredients and steps
        public void DisplayReport()
        {
            int recipeIndex = prodNames.Count - 1;
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

            OptionReport();
        }

        // Report displaying options
        public void OptionReport()
        {
            Console.WriteLine("\n\nWOULD YOU LIKE TO?\n1)SCALE RECIPE\n2)CLEAR DATA AND RESTART\n3)QUIT");
            string option = Console.ReadLine();
            int option1;
            while (!int.TryParse(option, out option1))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.Write("WOULD YOU LIKE TO?\n1)SCALE RECIPE\n2)CLEAR DATA AND RESTART\n3)QUIT");
                option = Console.ReadLine();
            }

            if (option1 != 1 && option1 != 2 && option1 != 3)
            {
                Console.WriteLine("INVALID INPUT!");
                OptionReport();
            }

            if (option1 == 1)
            {
                ScaleReport();
            }
            else if (option1 == 2)
            {
                ClearData();
            }
            else if (option1 == 3)
            {
                Environment.Exit(0);
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

            Console.WriteLine("Do you wish to go back to original values?\n1)yes\n2)no");
            string option = Console.ReadLine();
            int option1;
            while (!int.TryParse(option, out option1))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.Write("Do you wish to go back to original values?\n1)yes\n2)no");
                option = Console.ReadLine();
            }

            if (option1 != 1 && option1 != 2)
            {
                Console.WriteLine("INVALID INPUT!");
                OptionReport();
            }

            if (option1 == 1)
            {
                DisplayReport();
            }
            else if (option1 == 2)
            {
                Environment.Exit(0);
            }
        }

        // Method for clearing data in collections and restarting
        public void ClearData()
        {
            prodNames.RemoveAt(prodNames.Count - 1);
            names.RemoveAt(names.Count - 1);
            quantities.RemoveAt(quantities.Count - 1);
            units.RemoveAt(units.Count - 1);
            steps.RemoveAt(steps.Count - 1);

            Input();
        }
    }
}
