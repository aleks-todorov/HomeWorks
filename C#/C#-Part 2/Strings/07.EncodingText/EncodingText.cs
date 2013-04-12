using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Task: 
 
    Write a program that encodes and decodes a string using given encryption key (cipher). 
    * The key consists of a sequence of characters. The encoding/decoding is done by performing XOR
    * (exclusive or) operation over the first letter of the string with the first of the key, the second –
    * with the second, etc. When the last key character is reached, the next is the first.
*/
namespace _07.EncodingText
{
    class EncodingText
    {
        static void Main(string[] args)
        {
            string key = "key";
            string text = "something";
            int currentKeySymbol = 0;
            string encryptedText = string.Empty;
            string decryptedText = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                char currentLetter = text[i];

                encryptedText += (char)((int)currentLetter ^ (int)key[currentKeySymbol]);
                currentKeySymbol++;
                if (currentKeySymbol == key.Length)
                {
                    currentKeySymbol = 0;
                }
            }
            Console.WriteLine(encryptedText);
            
            for (int i = 0; i < encryptedText.Length; i++)
            {
                char currentLetter = encryptedText[i];

                decryptedText += (char)((int)currentLetter ^ (int)key[currentKeySymbol]);
                currentKeySymbol++;
                if (currentKeySymbol == key.Length)
                {
                    currentKeySymbol = 0;
                }
            }
            Console.WriteLine(decryptedText);
        }
    }
}
