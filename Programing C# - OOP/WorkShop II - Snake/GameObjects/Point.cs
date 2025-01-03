using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX { get; set; }
        public int TopY { get; set; }

        public void Draw(char symbom)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbom);
        }

        public void Draw(int leftX, int topY, char symbom)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbom);
        }
    }
}
