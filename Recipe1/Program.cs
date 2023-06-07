namespace Recipe1
{
    internal class Program
    //***************************************************************************oooo0000----BEGIN CLASS----0000OOOO*****************************************************************************

    {
        //********************************************************************************
        //Main Method
        private static void Main(string[] args)
        {
            // Create an instance of Class1
            Class1 Callhere = new Class1();
            Callhere.RecipeCaloriesExceeded += RecipeCaloriesExceededHandler;

            // Call the Intro method to start the program
            Callhere.Intro();
        }

        // Event handler for the RecipeCaloriesExceeded event
        private static void RecipeCaloriesExceededHandler(string recipeName)
        {
            // Display a message indicating that the recipe exceeds 300 calories
            Console.WriteLine($"The recipe '{recipeName}' exceeds 300 calories!");
        }

    }
    //*********************************************************************************
}
//***************************************************************************oooo0000----END CLASS----0000OOOO*****************************************************************************

