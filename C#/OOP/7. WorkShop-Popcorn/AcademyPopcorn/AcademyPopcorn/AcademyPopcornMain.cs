using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int endRow = WorldRows;
            int startCol = 2;
            int endCol = WorldCols - 2;


            //Task 1: Implementing Game field with adding a "for cycle" for rows
            //Task 10: Using UnpassableBlock 
            for (int row = startRow; row < endRow; row++)
            {
                for (int col = startCol; col < endCol; col++)
                {
                    if (row == startRow)
                    {
                        UnpassableBlock unpassable = new UnpassableBlock(new MatrixCoords(row, col));
                        engine.AddObject(unpassable);
                    }
                    if (row != startRow && (col == startCol || col == endCol - 1))
                    {
                        UnpassableBlock unpassable = new UnpassableBlock(new MatrixCoords(row, col));
                        engine.AddObject(unpassable);
                    }
                    else if (row <= startRow + 5 && row != startRow)
                    {
                        //Task12: Implementing GiftBlock.cs 
                        GiftBlock currBlock = new GiftBlock(new MatrixCoords(row, col));
                        engine.AddObject(currBlock);
                    }
                }

            }

            // Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 10),
            //     new MatrixCoords(-1, 1));

            //Task7: Implementing Meteorit Ball 
            //MeteoritBall meteoritBall = new MeteoritBall(new MatrixCoords(WorldRows / 2, 10), new MatrixCoords(-1, 1));

            //Task9: Implement Unstoppable ball
            UnstoppableBall ultimateBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 10), new MatrixCoords(-1, 1));

            engine.AddObject(ultimateBall);

            //TODO - Task 13: Implementing Shooting Ability
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);


        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
