using System;
using System.Collections.Generic;
using System.Globalization;

//15/100 :((
class Cooking
{
    static void Main(string[] args)
    {
        NumberFormatInfo myInv = NumberFormatInfo.InvariantInfo;

        Dictionary<string, int> unitNumber = new Dictionary<string, int>(new StringComparer());
        unitNumber.Add("tablespoons", 1);
        unitNumber.Add("liters", 2);
        unitNumber.Add("fluid ounces", 3);
        unitNumber.Add("teaspoons", 4);
        unitNumber.Add("gallons", 5);
        unitNumber.Add("pints", 6);
        unitNumber.Add("quarts", 7);
        unitNumber.Add("cups", 8);
        unitNumber.Add("milliliters", 9);
        unitNumber.Add("tbsps", 10);
        unitNumber.Add("ls", 11);
        unitNumber.Add("fl ozs", 12);
        unitNumber.Add("tsps", 13);
        unitNumber.Add("gals", 14);
        unitNumber.Add("pts", 15);
        unitNumber.Add("qts", 16);
        unitNumber.Add("mls", 17);

        double[,] measurementTransform = new double[,] {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 1, 0, 0, 0.333, 0, 0, 0, 0, 0, 1, 0, 0, 0.333, 0, 0, 0, 0},
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0.001, 0, 1, 0, 0, 0, 0, 0, 0.001},
{0, 0, 0, 1, 0, 0, 0, 0, 8, 0, 0, 0, 1, 0, 0, 0, 0, 0},
{0, 3, 0, 0, 1, 0, 0, 0, 48, 0.2, 3, 0, 0, 1, 0, 0, 0, 0.2},
{0, 0, 0, 0, 0, 1, 0, 0.25, 0, 0, 0, 0, 0, 0, 1, 0, 0.25, 0},
{0, 0, 0, 0, 0, 0, 1, 2, 0.5, 0, 0, 0, 0, 0, 0, 1, 2, 0},
{0, 0, 0, 0, 0, 4, 0.5, 1, 0, 0, 0, 0, 0, 0, 4, 0.5, 1, 0},
{0, 0, 0, 0.125, 0.0208, 0, 2, 0, 1, 0, 0, 0, 0.125, 0.0208, 0, 2, 0, 0},
{0, 0, 1000, 0, 4, 0, 0, 0, 0, 1, 0, 1000, 0, 4, 0, 0, 0, 1},
{0, 1, 0, 0, 0.333, 0, 0, 0, 0, 0, 1, 0, 0, 0.333, 0, 0, 0, 0},
{0, 0, 1, 0, 0, 0, 0, 0, 0, 0.001, 0, 1, 0, 0, 0, 0, 0, 0.001},
{0, 0, 0, 1, 0, 0, 0, 0, 8, 0, 0, 0, 1, 0, 0, 0, 0, 0},
{0, 3, 0, 0, 1, 0, 0, 0, 48, 0.2, 3, 0, 0, 1, 0, 0, 0, 0.2},
{0, 0, 0, 0, 0, 1, 0, 0.25, 0, 0, 0, 0, 0, 0, 1, 0, 0.25, 0},
{0, 0, 0, 0, 0, 0, 1, 2, 0.5, 0, 0, 0, 0, 0, 0, 1, 2, 0},
{0, 0, 0, 0, 0, 4, 0.5, 1, 0, 0, 0, 0, 0, 0, 4, 0.5, 1, 0},
{0, 0, 1000, 0, 4, 0, 0, 0, 0, 1, 0, 1000, 0, 4, 0, 0, 0, 1}};


        Dictionary<string, Quantity> recipe = new Dictionary<string, Quantity>(new StringComparer());
        int recipeNumber = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < recipeNumber; i++)
        {
            string recipeLine = Console.ReadLine();
            string[] splitRecipeLine = recipeLine.Split(':');
            double quantityNumber = Double.Parse(splitRecipeLine[0], myInv);
            if (!recipe.ContainsKey(splitRecipeLine[2]))
            {
                recipe.Add(splitRecipeLine[2], new Quantity(splitRecipeLine[1], quantityNumber));
            }
            else
            {
                Quantity currentQuantity = recipe[splitRecipeLine[2]];
                if (string.Equals(currentQuantity.unit, splitRecipeLine[1], StringComparison.InvariantCultureIgnoreCase))
                {
                    currentQuantity.quantity += quantityNumber;
                    recipe[splitRecipeLine[2]] = currentQuantity;
                }
                else
                {
                    int productUnitNum = unitNumber[splitRecipeLine[1]];
                    int recipeProductNum = unitNumber[currentQuantity.unit];
                    double coeff = measurementTransform[recipeProductNum, productUnitNum];
                    currentQuantity.quantity += quantityNumber * coeff;
                    recipe[splitRecipeLine[2]] = currentQuantity;
                }
            }
        }

        int productsNumber = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < productsNumber; i++)
        {
            string productLine = Console.ReadLine();
            string[] splitProductLine = productLine.Split(':');
            double productQuantityNumber = double.Parse(splitProductLine[0], myInv);
            if (recipe.ContainsKey(splitProductLine[2]))
            {
                Quantity currentQuantity = recipe[splitProductLine[2]];
                if (string.Equals(currentQuantity.unit, splitProductLine[1], StringComparison.InvariantCultureIgnoreCase))
                {
                    currentQuantity.quantity -= productQuantityNumber;
                    recipe[splitProductLine[2]] = currentQuantity;
                }
                else
                {
                    int productUnitNum = unitNumber[splitProductLine[1]];
                    int recipeProductNum = unitNumber[currentQuantity.unit];
                    double coeff = measurementTransform[recipeProductNum, productUnitNum];
                    currentQuantity.quantity -= productQuantityNumber * coeff;
                    recipe[splitProductLine[2]] = currentQuantity;
                }
            }
        }

        foreach (var recipeProd in recipe)
        {
            if (recipeProd.Value.quantity > 0)
            {
                Console.Write("{0:F2}", recipeProd.Value.quantity);
                Console.Write(':');
                Console.Write(recipeProd.Value.unit);
                Console.Write(':');
                Console.Write(recipeProd.Key);
                Console.WriteLine();
            }
        }

    }
}

public class StringComparer : IEqualityComparer<string>
{
    public bool Equals(string string1, string string2)
    {
        int compare = String.Compare(string1, string2, true);
        if (compare == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetHashCode(string string1)
    {
        string stringLowered = string1.ToLower();
        return stringLowered.GetHashCode();
    }
}

struct Quantity
{
    public string unit;
    public double quantity;

    public Quantity(string unit, double quantity)
    {
        this.unit = unit;
        this.quantity = quantity;
    }
}