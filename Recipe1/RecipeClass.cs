using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe1
{
    internal class RecipeClass
    {
        private static void RecipeCaloriesExceededHandler(string recipeName)
        {
            Console.WriteLine($"The recipe '{recipeName}' exceeds 300 calories!");
        }
    }
}
