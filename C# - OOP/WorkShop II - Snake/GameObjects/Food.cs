using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private char foodSymbol;
        protected Food(Wall wall,char foodSymbol, int Points) : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = Points;
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = Random.Shared.Next(2, wall.LeftX - 2);
            this.TopY = Random.Shared.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElements.Any(x=>x.LeftX==this.LeftX && x.TopY==this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = Random.Shared.Next(2, wall.LeftX - 2);
                this.TopY = Random.Shared.Next(2, wall.TopY - 2);
                isPointOfSnake = snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.LeftX == this.LeftX && snake.TopY == this.TopY;
        }
    }
}
