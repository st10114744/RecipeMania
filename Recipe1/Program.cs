namespace Recipe1
{
    internal class Program

    //********************************************************************************
    //Main Method

    {
            private static void Main(string[] args)
            {
           
            Class1 Callhere = new Class1();
            Callhere.RecipeCaloriesExceeded += RecipeCaloriesExceededHandler;
            Callhere.Intro();
            }
        private static void RecipeCaloriesExceededHandler(string recipeName)
        {
            Console.WriteLine($"The recipe '{recipeName}' exceeds 300 calories!");
        }
    }
        //*********************************************************************************
    }
