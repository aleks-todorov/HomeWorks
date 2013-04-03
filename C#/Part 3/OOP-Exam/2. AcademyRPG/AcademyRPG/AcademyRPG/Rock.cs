using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        public int Quantity { get; set; }
        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }

        public Rock(int hitpoints, Point position)
            : base(position)
        {
            this.Quantity = hitpoints / 2;
            this.HitPoints = hitpoints;
        }
    }
}
