using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private readonly Point[] pointsOfDirection;
        private readonly Wall wall;
        private readonly Snake snake;
        private Direction direction;
        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.direction = Direction.Right;
            this.sleepTime = 100;
            this.pointsOfDirection = new Point[4];
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirections();
                }
                bool isMoving = snake.IsMoving(this.pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    this.AskUserForRestar();
                }

                this.sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void CreateDirections()
        {
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirections()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if(userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;

        }

        private void AskUserForRestar()
        {
            int leftX = this.wall.LeftX +2;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();

            if(input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over!");
            Environment.Exit(0);
        }
    }
}
