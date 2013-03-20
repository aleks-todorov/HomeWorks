using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacketEngine : Engine
    {
        //Task 4: Inherit the Engine class. Create a method ShootPlayerRacket. Leave it empty for now.

        public ShootingRacketEngine(IRenderer renderer, IUserInterface userInterface, int threadSleep)
            : base(renderer, userInterface, threadSleep)
        {
        }

        public void ShootPlayerRacket()
        {
            //Implement Shooting
        }
    }
}
