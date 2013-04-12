using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoritBall : Ball
    {
        //Task 6: 
        //Implement a MeteoriteBall. It should inherit the Ball class and should leave a trail of 
        //TrailObject objects. Each trail objects should last for 3 "turns". Other than that, the Meteorite ball 
        //should behave the same way as the normal ball. You must NOT edit any existing .cs file.

        const int meteoritBallLife = 3;
        private char[,] trailObjectBody = new char[,] { { '*' } };
        private int trailLifeTime;

        public MeteoritBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.trailLifeTime = meteoritBallLife;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> tail = new List<TrailObject>();


            TrailObject trailObject = new TrailObject(this.TopLeft, this.trailObjectBody, this.trailLifeTime);
            tail.Add(trailObject);

            return tail;
        }
    }
}
