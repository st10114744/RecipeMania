using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Recipe1
{
    internal class Class1
    {
        public string NumIngred { get; set; }
        public string ProdName { get; set; }
        public string[] Name { get; set; }
        public double[] Quantity { get; set; }
        public string[] Unit { get; set; }

        //Declare arrays in class 
        private string[] ingredients;

        

        public Class1() 
        {
        
        }

        public void Intro() 
        {
            Console.WriteLine("********WELCOME TO RECIPE MANIA********");

        }

        public void Input()
        {
            Console.WriteLine("ENTER THE NAME OF THE PRODUCT YOU WANTING TO MAKE:");
            ProdName = Console.ReadLine();

            Console.Write("Number of ingredients: ");
            NumIngred = Console.ReadLine();
            int numIngredients;
            while (!int.TryParse(NumIngred, out numIngredients))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.Write("Number of ingredients: ");
                NumIngred = Console.ReadLine();
            }

            // Initialize the arrays here
            Name = new string[numIngredients];
            Quantity = new double[numIngredients];
            Unit = new string[numIngredients];

            // Ask the user to enter the details for each ingredient
            for (int i = 0; i < numIngredients; i++)// allows us to loop through each ingredient
            {
                Console.WriteLine($"Enter the details for ingredient #{i + 1}:");//enter details and auto generates ingredient number based on number of ingredients
                Console.Write("Name: ");//enter ingredient name
                string name = Console.ReadLine();
                Name[i] = name;// sends the name to array

                Console.Write("Quantity: ");//quantity of ingredient
                string input = Console.ReadLine();
                double quantity;

                while (!double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out quantity))// allows there to be a white space before or after input and allows "," or "." as a decimal point.
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");//prompts user to enter again if input is incorrect
                    Console.Write("Quantity: ");
                    input = Console.ReadLine();
                }

                Quantity[i] = quantity;


                Console.Write("Unit of Measurement: ");//input unit of measurement
                string unit = Console.ReadLine();
                Unit[i] = unit;
            }
        }

           







    }
}
