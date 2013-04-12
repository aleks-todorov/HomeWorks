using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BitArray64Example
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong number;

        public ulong Number
        {
            get { return number; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!!!");
                }

                else
                {
                    number = value;
                }
            }
        }

        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = ConvertedToBinary();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int[] ConvertedToBinary()
        {
            var numberToConvert = this.Number;

            var bits = new int[64];

            for (int i = 63; i >= 0; i--)
            {
                if (numberToConvert != 0)
                {
                    //From this cast, numbers larger than int.MaxValue are shown wrongly
                    bits[i] = (int)numberToConvert % 2;
                    numberToConvert /= 2;
                }
                else
                {
                    bits[i] = 0;
                }
            }
            return bits;
        }

        //Creating Indexers
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new System.IndexOutOfRangeException();
                }
                else
                {
                    int[] bits = this.ConvertedToBinary();
                    return bits[index];
                }
            }
        }

        public override bool Equals(object obj)
        {
            var numberToCompare = obj as BitArray64;

            //Comaparing Students only based on few parameters
            if (numberToCompare == null)
            {
                return false;
            }

            if (!Object.Equals(this.Number, numberToCompare.Number))
            {
                return false;
            }

            return true;
        }
        public static bool operator ==(BitArray64 firstNumber, BitArray64 secondNumber)
        {
            return BitArray64.Equals(firstNumber, secondNumber);
        }

        public static bool operator !=(BitArray64 firstNumber, BitArray64 secondNumber)
        {
            return !(BitArray64.Equals(firstNumber, secondNumber));
        }

        public override int GetHashCode()
        {
            //Just some expression that I thought. Bet there is better way... 
            return (int)(this.Number % 100000000) ^ int.MaxValue;
        }
    }
}

