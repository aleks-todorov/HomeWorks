using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        //Task 11: 
        //Implement a Gift class. It should be a moving object, which always falls down. 
        //The gift shouldn't collide with any ball, but should collide (and be destroyed) with the racket.
        //You must NOT edit any existing .cs file. 

        private char[,] giftBody = new char[,] { { '$' } };

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<Gift> gifts = new List<Gift>();

                gifts.Add(new Gift(this.topLeft, this.giftBody));

                return gifts;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
