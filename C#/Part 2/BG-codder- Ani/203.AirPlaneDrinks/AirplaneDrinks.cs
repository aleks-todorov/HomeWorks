using System;

//100/100
class AirPlaneDrinks
{
    static void Main(string[] args)
    {
        int n;
        int teaCustomersNumber;
        int coffeeCustomersNumber;
        bool[] seats;

        n = Int32.Parse(Console.ReadLine());
        teaCustomersNumber = Int32.Parse(Console.ReadLine());
        coffeeCustomersNumber = n - teaCustomersNumber;
        seats = new bool[n + 1];
        for (int i = 0; i < teaCustomersNumber; i++)
        {
            int teaCustomer = Int32.Parse(Console.ReadLine());
            seats[teaCustomer] = true;
        }

        long seconds = 0;
        seconds += (teaCustomersNumber / 7 + (teaCustomersNumber % 7 > 0 ? 1 : 0)) * 47;
        seconds += (coffeeCustomersNumber / 7 + (coffeeCustomersNumber % 7 > 0 ? 1 : 0)) * 47;
        seconds += n * 4;

        for (int i = n, c = 0, t = 0; i > 0; i--)
        {
            if (seats[i] == true && t % 7 == 0)
            {
                seconds += 2 * i;
            }
            if (seats[i] == false && c % 7 == 0)
            {
                seconds += 2 * i;
            }

            if (seats[i] == true)
            {
                t++;
            }
            else
            {
                c++;
            }
        }

        Console.Write(seconds);
    }
}
