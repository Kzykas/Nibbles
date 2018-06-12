using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMechanics gameMechanics = new GameMechanics(40,20);
            gameMechanics.BuildSides();
            gameMechanics.DrawSnake();
            gameMechanics.CreatePrey();
            Console.SetCursorPosition(5, 25);
            Console.WriteLine("Press any arrow key to start the game");
            ConsoleKey command = Console.ReadKey().Key;
            do
            {
                if (gameMechanics.Snake.CatchPrey(gameMechanics.Prey))
                {
                    gameMechanics.CreatePrey();
                    gameMechanics.Snake.AddSnakeBodyPart();
                }
                gameMechanics.Snake.Move(command);
                gameMechanics.BuildSides();
                
                gameMechanics.DrawSnake();
                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(150);
                
            } while (!gameMechanics.GameOver());

            Console.ReadKey();

        }


    }
}
