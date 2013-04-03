using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class UpgradedEngine : Engine
    {
        public override void ExecuteControllableCommand(string[] commandWords)
        {
            base.ExecuteControllableCommand(commandWords);

            switch (commandWords[1])
            {
                case "giant":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = 0;
                        this.AddObject(new Lumberjack(name, position, owner));
                        break;
                    }
                case "knight":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name, position, owner));
                        break;
                    }
                case "rock":
                    {
                        int hitPoints = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Rock(hitPoints, position));
                        break;
                    }
                case "house":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        int owner = int.Parse(commandWords[3]);
                        this.AddObject(new House(position, owner));
                        break;
                    }
                case "ninja":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Ninja(name, position, owner));
                        break;
                    }
            }
        }
    }
}
