using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.MathExpressionRefactoring
{
    class MathExpressionRefactoring
    {
        static void Main(string[] args)
        {

        }

        public static Size GetRotatedSize(Size initialSize, double angleOfRotation)
        {
            var newCosWidthSize = Math.Abs(Math.Cos(angleOfRotation)) * initialSize.Width;
            var newSinHeightSize = Math.Abs(Math.Sin(angleOfRotation)) * initialSize.Height;
            var newSinWidthSize = Math.Abs(Math.Sin(angleOfRotation)) * initialSize.Width;
            var newCosHeightSize = Math.Abs(Math.Cos(angleOfRotation)) * initialSize.Height;
            var fullWidthSize = newCosWidthSize + newSinWidthSize;
            var fullHeightSize = newCosHeightSize + newSinHeightSize;
            Size figSize = new Size(fullWidthSize, fullHeightSize);
            return figSize;
        }
    }
}
