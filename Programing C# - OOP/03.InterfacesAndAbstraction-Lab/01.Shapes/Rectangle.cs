using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int heigth)
        {
            this.width = width;
            this.height = heigth;
        }

       
        public void Draw()
        {
            DrawLine(this.width, '*', '*');
            for(int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ');

            }
            DrawLine(this.width, '*', '*');

        }

        private void DrawLine(int width, char end, char middle)
        {
            Console.Write(end);
            for(int i=1;i<width-1; ++i)
            {
                Console.Write(middle);
            }
            Console.WriteLine(end);
        }
    }
}
