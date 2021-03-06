﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Point
    {
        private string name;
        private int points;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        public Point() { }

        public Point(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }
}
