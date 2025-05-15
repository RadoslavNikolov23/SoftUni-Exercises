using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private readonly Wall wall;
        private char foodSymbol;
        protected Food(Wall wall, char foodSymbol, int Points) : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = Points;
        }

        public int FoodPoints { get; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = Random.Shared.Next(2, this.wall.LeftX - 2);
            this.TopY = Random.Shared.Next(2, this.wall.TopY - 2);

            bool isPointOfSnake = IsPointOfSnake(snakeElements);

            while (isPointOfSnake)
            {
                LeftX = Random.Shared.Next(2, wall.LeftX - 2);
                TopY = Random.Shared.Next(2, wall.TopY - 2);
                isPointOfSnake = IsPointOfSnake(snakeElements);
                    
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        private bool IsPointOfSnake(Queue<Point> snakeElements) => snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY);

        public bool IsFoodPoint(Point snake) => snake.LeftX == LeftX && snake.TopY == TopY;
    }
}
