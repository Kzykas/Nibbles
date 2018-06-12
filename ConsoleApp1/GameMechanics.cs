using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GameMechanics
    {
        private int xCoordGrid;
        private int yCoordGrid;
        private Snake snake = new Snake(19, 10);
        private Random random = new Random();
        private Prey prey= new Prey();
        private SnakeBodyPart snakeBodyGain;

        public GameMechanics(int xCoordGrid, int yCoordGrid)
        {
            this.xCoordGrid = xCoordGrid;
            this.yCoordGrid = yCoordGrid;
        }

        public Snake Snake {
            get { return snake; }
            set { snake = value; }
        }

        public Prey Prey
        {
            get { return prey; }
            set { prey = value; }
        }

        public void DrawSnake()
        {
            Console.SetCursorPosition(snake.SnakeBody[0].XCoordinate, snake.SnakeBody[0].YCoordinate);
            Console.WriteLine("0");

            for(int i=1; i<snake.SnakeBody.Count; i++)
            {
                Console.SetCursorPosition(snake.SnakeBody[i].XCoordinate, snake.SnakeBody[i].YCoordinate);
                Console.WriteLine("0");
            }
            
            if (snake.Size>=1)
            {
                Console.SetCursorPosition(snake.SnakeBody[snake.Size].XCoordinate, snake.SnakeBody[snake.Size].YCoordinate);
                Console.WriteLine(" ");
                for (int i = snake.Size; i > 0; i--)
                {
                    snake.SnakeBody[i].XCoordinate = snake.SnakeBody[i - 1].XCoordinate;
                    snake.SnakeBody[i].YCoordinate = snake.SnakeBody[i - 1].YCoordinate;
                }
            }

        }

        public void BuildSides()
        {
            for (int i = 0; i < xCoordGrid; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("$");
                Console.SetCursorPosition(i, yCoordGrid-1);
                Console.Write("$");
            }
            for (int i = 0; i < yCoordGrid; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("$");
                Console.SetCursorPosition(xCoordGrid-1, i);
                Console.Write("$");
            }

        }

        public bool GameOver()
        {
            if (snake.DeathToBoundaries(xCoordGrid, yCoordGrid))
            {
                Console.SetCursorPosition(xCoordGrid/4, yCoordGrid/4);
                Console.WriteLine("The snake hit the wall");
                return true;
            }
            return false;
        }

        public void CreatePrey()
        {
            prey.XCoordinate = random.Next(1, xCoordGrid - 2);
            prey.YCoordinate = random.Next(1, yCoordGrid - 2);
            Console.SetCursorPosition(prey.XCoordinate, prey.YCoordinate);
            Console.Write("x");
        }
    }
}
