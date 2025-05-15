namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle(5, 4);
            Circle circle = new Circle(3);

            Shape rectShape = new Rectangle(5, 6);
            Shape circleShape = new Circle(7);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());

            Console.WriteLine(rectShape.CalculateArea());
            Console.WriteLine(rectShape.CalculatePerimeter());
            Console.WriteLine(rectShape.Draw());

            Console.WriteLine(circleShape.CalculateArea());
            Console.WriteLine(circleShape.CalculatePerimeter());
            Console.WriteLine(circleShape.Draw());
        }
    }
}
