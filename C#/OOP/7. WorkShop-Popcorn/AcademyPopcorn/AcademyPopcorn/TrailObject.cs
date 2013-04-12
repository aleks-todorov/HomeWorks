using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 5:
    //Implement a TrailObject class. It should inherit the GameObject class and should have a 
    //constructor which takes an additional "lifetime" integer. The TrailObject should disappear after a "lifetime" 
    //amount of turns. You must NOT edit any existing .cs file.

    public class TrailObject : GameObject
    {
        private int lifeTime;

        public int LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime)
            : base(topLeft, body)
        {
            this.TopLeft = topLeft;
            int imageRows = body.GetLength(0);
            int imageCols = body.GetLength(1);
            this.body = body;
            this.IsDestroyed = false;
            this.LifeTime = lifeTime;
        }

        public override void Update()
        {
            //Task 5: Introducing somethig like a counter. On each Update() we subsrtact 1 from LifeTime. If LifeTime gets 0 - the obj i destroyed.
            if (this.LifeTime > 0)
            {
                LifeTime--;
            }
            else
            {
                this.IsDestroyed = true;
            }
        }
    }
}
