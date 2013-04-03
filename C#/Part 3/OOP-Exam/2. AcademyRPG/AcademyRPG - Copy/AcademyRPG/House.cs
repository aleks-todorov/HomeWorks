﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class House : StaticObject
    {

        public House(Point position, int owner)
            : base(position, owner)
        {
        }

        public int DefensePoints
        {
            get { return 500; }
        }
    }
}
