using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //This ball should change direction only if it hits indestructible wall or user's racket
            if (collisionData.hitObjectsCollisionGroupStrings.Contains(UnpassableBlock.CollisionGroupString) ||
    collisionData.hitObjectsCollisionGroupStrings.Contains(Racket.CollisionGroupString))
            {
                base.RespondToCollision(collisionData);
            }
        }
    }
}
