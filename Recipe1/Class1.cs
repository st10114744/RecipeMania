using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
        public string Option { get; set; }


        //Declare arrays in class
        public string[] Name { get; set; }
        public double[] Quantity { get; set; }
        public string[] Unit { get; set; }
        
        private string[] steps { get; set; }



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

                Quantity[i] = quantity;//sends quantity input to array


                Console.Write("Unit of Measurement: ");//input unit of measurement
                string unit = Console.ReadLine();
                Unit[i] = unit;//sends unit to array
            }
            IngredientSteps();
        }

        public void IngredientSteps()
        {
            Console.Write("Enter the number of steps: ");//prompting user to enter the number of steps for recipe
            int numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];// initialisng array

            // Prompt the user to enter the description for each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter the description for step #{i + 1}: ");//autogenerates step number according to number of steps
                steps[i] = Console.ReadLine();//sends descriptions to array
            }
            displayReport();
        }

        public void displayReport() 
        {
            
            Console.WriteLine($"\n\n\n*****{ProdName.ToUpper()} INGREDIENTS*****");//Recipe name 

            //displays ingredients via iterating through for loop
            for (int i = 0; i < Name.Length; i++)
            {
                Console.WriteLine($"{Name[i]} : {Quantity[i]} {Unit[i]}");//concatinates all details in arrays into one string for each ingredient
            }

            //displays all the neccessary steps after each ingredient
            Console.WriteLine("\n*****Steps*****");//itterates through for loop displaying the steps
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
            OptionReport();
        }

        public void OptionReport ()
        {
            Console.WriteLine("WOULD YOU LIKE TO?\n1)SCALE RECIPE\n2)CLEAR DATA\n3)QUIT");//ask user which option they would prefer
            Option = Console.ReadLine();
            int Option1;
            while (!int.TryParse(Option, out Option1))//if the incorrect number is entered
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.Write("WOULD YOU LIKE TO?\n1)SCALE RECIPE\n2)CLEAR DATA\n3)QUIT");
                Option = Console.ReadLine();
            }
            if (Option1 != 1 && Option1 != 2 && Option1 != 3)//if an integer is entered besides 1,2,3
            {
                Console.WriteLine(" INVALID INPUT!");
                OptionReport();
            }

            if (Option1==1) 
            {
                ScaleReport();//goes to scale data report
            }
           else if (Option1 == 2) 
            {
                ClearData();//goes to clear data method
            }
            else if(Option1 == 3)
            {
                System.Environment.Exit(0);//exits program
            }
        }

        public void ScaleReport() 
        {
            Console.Write("Scale quantities by: ");//input the amount you want to scale by
            string scaleInput = Console.ReadLine();
            double scale;
            while (!double.TryParse(scaleInput, out scale))//invalid integer
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.Write("Scale quantities by: ");
                scaleInput = Console.ReadLine();
            }
            Console.WriteLine("\n\n*****SCALED REPORT*****");
            for (int i = 0; i < Quantity.Length; i++)//itterates through quantities and scales them according to the number
            {
                double scaledQuantity = Quantity[i] * scale;
                Console.WriteLine($"{Name[i]} : {scaledQuantity} {Unit[i]}");
            }
            

         }

        public void ClearData() 
        {
            //clears Arrays
            Array.Clear(Name, 0, Name.Length);
            Array.Clear(Unit, 0, Unit.Length);
            Array.Clear(Quantity, 0, Quantity.Length);
            Array.Clear(steps, 0, steps.Length);


        }
           







    }
}
