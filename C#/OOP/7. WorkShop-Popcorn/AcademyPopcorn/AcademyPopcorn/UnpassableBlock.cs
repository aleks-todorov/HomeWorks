using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "Unpassable Block";

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
        }
    }
}
