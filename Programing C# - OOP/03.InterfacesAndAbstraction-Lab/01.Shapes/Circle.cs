using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Radius => this.radius;

        public void Draw()
        {
            double ringIn = this.radius - 0.4;
            double ringOut = this.radius + 0.4;

            for (double i = this.radius; i >= -this.radius; --i)
            {
                for (double j = -this.Radius; j < ringOut; j += 0.5)
                {

                    double allValue = (i*i) + (j * j);

                    if(allValue>=ringIn*ringIn && allValue <= ringOut * ringOut)
                    {
                        Console.Write('*');
                    }
                    else Console.Write(' ');
                }
            Console.WriteLine();
            }
        }
    }
}
