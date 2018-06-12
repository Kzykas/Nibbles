using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Snake
    {
        SnakeBodyPart head;
        private List<SnakeBodyPart> snakeBody = new List<SnakeBodyPart>();
        private int size=0;

        public Snake(int xCoordinate, int yCoordinate)
        {
            head = new SnakeBodyPart(xCoordinate, yCoordinate);
            snakeBody.Add(head);
            AddSnakeBodyPart();
        }

        public List<SnakeBodyPart> SnakeBody
        {
            get { return snakeBody; }
            set { snakeBody = value; }
        }

        public int Size {
            get { return size; }
            set { size = value; }
        }

        public void Move(ConsoleKey command)
        {
            switch (command)
            {
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(head.XCoordinate, head.YCoordinate);
                    Console.Write(" ");
                    head.YCoordinate--;
                    break;
                case ConsoleKey.DownArrow:
                    Console.SetCursorPosition(head.XCoordinate, head.YCoordinate);
                    Console.Write(" ");
                    head.YCoordinate++;
                    break;
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(head.XCoordinate, head.YCoordinate);
                    Console.Write(" ");
                    head.XCoordinate++;
                    break;
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(head.XCoordinate, head.YCoordinate);
                    Console.Write(" ");
                    head.XCoordinate--;
                    break;
            }
        }

        public bool DeathToBoundaries(int xCoordGrid, int yCoordGrid)
        {
            return head.XCoordinate == 0 || head.XCoordinate == xCoordGrid-1 
                || head.YCoordinate == 0 || head.YCoordinate == yCoordGrid-1 ? true : false;
        }

        public bool CatchPrey(Prey prey)
        {
            return head.XCoordinate == prey.XCoordinate && head.YCoordinate == prey.YCoordinate ? true : false;
        }

        public void AddSnakeBodyPart()
        {
            snakeBody.Add(new SnakeBodyPart(snakeBody[size].XCoordinate, snakeBody[size].YCoordinate));
            size++;
        }
    }
}
