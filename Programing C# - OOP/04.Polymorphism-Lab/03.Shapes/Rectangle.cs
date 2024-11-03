using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;


        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        public double Height { get;  }
        public double Width { get; }
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2*(this.Width+this.Height);
        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
