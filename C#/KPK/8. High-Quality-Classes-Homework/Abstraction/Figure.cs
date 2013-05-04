using System;

namespace Abstraction
{
    abstract class Figure
    {
        public virtual double CalcPerimeter()
        {
            throw new NotImplementedException();
        }

        public virtual double CalcSurface()
        {
            throw new NotImplementedException();
        }
    }
}
