using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CreationOfAttribute
{
    [VersionAtribute(1, 13)]
    class CreationOfAttribute
    {
        static void Main(string[] args)
        {
            Type type = typeof(CreationOfAttribute);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAtribute attr in allAttributes)
            {
                Console.WriteLine("Version of this class is:" + attr.ToString());
            }

        }
    }
}
