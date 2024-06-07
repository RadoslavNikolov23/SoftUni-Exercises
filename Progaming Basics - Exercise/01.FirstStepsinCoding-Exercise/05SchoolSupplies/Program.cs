
int numberPens=int.Parse(Console.ReadLine());
int numberMarkets=int.Parse(Console.ReadLine());
double literDetergent=double.Parse(Console.ReadLine());
double procentDiscount=double.Parse(Console.ReadLine());

double packPens = 5.80;
double packMarkets = 7.20;
double detergentForLiter =1.20;

double sumBeforeDiscount=(packPens*numberPens)+(packMarkets*numberMarkets)+(detergentForLiter*literDetergent);
double finalPrice = sumBeforeDiscount - (sumBeforeDiscount * (procentDiscount / 100));

Console.WriteLine(finalPrice);

//Изход
//Да се отпечата на конзолата колко пари ще са нужни на Ани, за да си плати сметката.
