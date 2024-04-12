using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("Enter name of your Recipe");
                string name = Console.ReadLine();

                if (name == "quit")
                {
                    break;
                }

                recipe.SetName(name);

                Console.WriteLine("Enter number of ingredients in your Recipe: ");
                int numIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter names of ingredients {i + 1}: ");
                    string ingredientName = Console.ReadLine();

                    Console.WriteLine($"Enter quantity of {ingredientName}: ");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter units of measurement for {ingredientName}: ");
                    string units = Console.ReadLine();

                    recipe.AddIngredient(ingredientName, quantity, units);
                }

                Console.WriteLine("Enter the number of steps: ");
                int numSteps = int.Parse(Console.ReadLine());

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Enter step {i + 1}: ");
                    string step = Console.ReadLine();
                    recipe.AddStep(step);
                }

                Console.WriteLine("\nRecipe Details:");
                recipe.DisplayRecipe();

                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Scale recipe (0.5 for half, 2 for double, 3 for triple)");
                Console.WriteLine("2. Reset ingredient quantities to original values");
                Console.WriteLine("3. Clear all saved data and enter a new recipe");
                Console.WriteLine("4. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter scaling factor: ");
                        double scalingFactor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(scalingFactor);
                        Console.WriteLine("\nScaled Recipe:");
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        recipe.ResetQuantities();
                        Console.WriteLine("\nIngredient quantities reset to original values.");
                        Console.WriteLine("\nOriginal Recipe:");
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.ClearData();
                        Console.WriteLine("\nAll saved data cleared. Enter a new recipe.");
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    class Ingredient
    {
        public string Name { get; private set; }
        public double OriginalQuantity { get; private set; }
        public double Quantity { get; set; }
        public string Units { get; private set; }

        public Ingredient(string name, double quantity, string units)
        {
            Name = name;
            OriginalQuantity = quantity;
            Quantity = quantity;
            Units = units;
        }

        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;
        }

        public void ScaleQuantity(double factor)
        {
            Quantity *= factor;
        }
    }

    class Recipe
    {
        private string name;
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();

        public void SetName(string n)
        {
            name = n;
        }

        public void AddIngredient(string name, double quantity, string units)
        {
            Ingredient ingredient = new Ingredient(name, quantity, units);
            ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            steps.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe: " + name);
            Console.WriteLine("\nIngredients:");

            foreach (var ingredient in ingredients)
            {
                Console.WriteLine("- " + ingredient.Quantity + " " + ingredient.Units + " of " + ingredient.Name);
            }

            Console.WriteLine("\nSteps:");

            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + steps[i]);
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ScaleQuantity(factor);
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public void ClearData()
        {
            name = "";
            ingredients.Clear();
            steps.Clear();
        }
    }
}

