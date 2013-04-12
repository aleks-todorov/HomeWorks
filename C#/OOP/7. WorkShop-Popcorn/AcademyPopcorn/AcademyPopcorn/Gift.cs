using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        public new const string CollisionGroupString = "Gift";

        public Gift(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body, new MatrixCoords(1, 0))
        {
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }
    }
}