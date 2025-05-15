namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            decimal amountMoney=decimal.Parse(Console.ReadLine());
            int countStudents=int.Parse(Console.ReadLine());
            decimal priceLightSaberSingle=decimal.Parse(Console.ReadLine());
            decimal priceRobesSingle=decimal.Parse(Console.ReadLine());
            decimal priceBeltsSingle=decimal.Parse(Console.ReadLine());

            decimal addLightSabers = Math.Ceiling(countStudents * 0.1m);
            decimal totalLightSabers = (countStudents+addLightSabers) * priceLightSaberSingle;
            decimal totalRobes = countStudents * priceRobesSingle;
            decimal freeStudentsBelts = 0;
            if (countStudents >= 6)
            {
                 freeStudentsBelts = countStudents/ 6;
               

            }
            decimal totalBelts = (countStudents-freeStudentsBelts) * priceBeltsSingle;

            decimal totalPrice = totalLightSabers + totalRobes + totalBelts;

            if(totalPrice>amountMoney)
            {
                Console.WriteLine($"John will need {(totalPrice - amountMoney):f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }

        }
    }
}
