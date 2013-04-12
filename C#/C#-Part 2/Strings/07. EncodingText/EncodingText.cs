using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Task: 
 
 Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters.
 * The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second
 * – with the second, etc. When the last key character is reached, the next is the first.
*/
namespace _07.EncodingText
{
    class EncodingText
    {
        // TO DO... 
        static void Main(string[] args)
        {
            string key = "14365784567324";
            string text = "Some text for encryption";
            string encryptedText = string.Empty;
            int keyPossition = 0;
            for (int i = 0; i < text.Length - 1; i++)
            {
                char symbol = text[i];
            }
        }
    }
}
