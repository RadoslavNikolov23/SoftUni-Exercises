using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private readonly Queue<Point> snakeElements;
        private readonly Food[] foods;
        private readonly Wall wall;

        private int foodIndex;
        private int nextLeftX;
        private int nextTopY;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            this.foodIndex = this.RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }

            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }
        public int RandomFoodNumber => Random.Shared.Next(0, this.foods.Length);

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();
            this.GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements.Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(snakeSymbol);

            if (this.foods[this.foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');
            return true;
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }

        
        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[foodIndex].FoodPoints;
            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
            }

            this.wall.IncreasePlayersPoints(snakeElements);
            this.wall.DrawPlayersPoints();

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(this.snakeElements);
        }
    }
}
