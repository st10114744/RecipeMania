using NUnit.Framework;

namespace Recipe1
{
    public class Tests
    { 
       
        [SetUp]
        public void Setup()
        {
            class1 = new Class1();
        }

        [Test]
        public void CalculateTotalCalories_WhenIngredientsPresent_ReturnsCorrectTotal()
        {
            // Arrange
            var class1 = new Class1();
            class1.AddIngredient("Ingredient 1", 100, "g", 50);
            class1.AddIngredient("Ingredient 2", 200, "g", 75);
            class1.AddIngredient("Ingredient 3", 150, "g", 100);

            // Act
            double totalCalories = class1.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(225, totalCalories);
        }
    }
}