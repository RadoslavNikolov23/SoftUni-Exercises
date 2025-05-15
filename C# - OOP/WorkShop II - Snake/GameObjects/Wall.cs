using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        private int playersPoints;
        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            this.InitializeWallBorders();
            this.DrawPlayersPoints();
        }

        public void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        public void SetVerticalLine(int leftX)
        {
            for (int topY = 1; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        public void InitializeWallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);
            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX-1);
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.LeftX == 0 || snake.LeftX == this.LeftX-1
                || snake.TopY == 0 || snake.TopY == this.TopY;
        }

        public void IncreasePlayersPoints(Queue<Point> snakeElements)
        {
            this.playersPoints = snakeElements.Count - 6;
        }

        public void DrawPlayersPoints()
        {
            Console.SetCursorPosition(this.LeftX+3, 0);
            Console.Write($"Player points: {this.playersPoints}");

            Console.SetCursorPosition(this.LeftX + 3, 1);
            Console.Write($"Player level: {this.playersPoints / 10}");
        }
    }
}
