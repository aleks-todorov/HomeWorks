using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CreationOfAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Enum, AllowMultiple = true)]
    class VersionAtribute : Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }

        public VersionAtribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public override string ToString()
        {
            string result = Major + "." + Minor;
            return result;
        }
    }
}
