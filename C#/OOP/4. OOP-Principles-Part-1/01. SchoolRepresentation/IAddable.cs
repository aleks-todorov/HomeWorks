using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolRepresentation
{
    interface IAddable<T>
    {
        //This interface will be implemented from Classes, Teacher, School
        void AddElement(T element);
    }
}
