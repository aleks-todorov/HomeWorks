using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PrintingCardsNames
{
    class PrintingCardsNames
    {
        static void Main(string[] args)
        {
            string[] cardsColors = { "hearts", "diamonds", "spades", "clubs" };
            for (int n = 0; n < 4; n++)
            {
                Console.WriteLine("\n<<<{0}>>>\n", cardsColors[n]);
                for (int i = 2; i < 15; i++)
                {
                    string cardName;
                    switch (i)
                    {
                        case 2: cardName = "Two of "; break;
                        case 3: cardName = "Three of "; break;
                        case 4: cardName = "Four of "; break;
                        case 5: cardName = "Five of "; break;
                        case 6: cardName = "Six of "; break;
                        case 7: cardName = "Seven of "; break;
                        case 8: cardName = "Eight of "; break;
                        case 9: cardName = "Nine of "; break;
                        case 10: cardName = "Ten of "; break;
                        case 11: cardName = "Jack of "; break;
                        case 12: cardName = "Queen of "; break;
                        case 13: cardName = "King of "; break;
                        case 14: cardName = "Ace of "; break;
                        default: cardName = "Joker"; break;
                    }
                    Console.WriteLine(cardName + cardsColors[n]);
                }
            }
        }
    }
}
