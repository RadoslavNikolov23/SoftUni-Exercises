
int numberChickenMenu=int.Parse(Console.ReadLine());
int numberFishMenu=int.Parse(Console.ReadLine());
int numberVeganMenu=int.Parse(Console.ReadLine());

double priceChicken = 10.35;
double priceFish = 12.40;
double priceVegan = 8.15;

double orderChicken = priceChicken * numberChickenMenu;
double orderFish = priceFish* numberFishMenu;
double orderVegan = priceVegan * numberVeganMenu;

double orderDesert=(orderChicken+orderFish+orderVegan)*0.20;
double deliveryTax = 2.50;

double finalOrder= orderChicken + orderFish + orderVegan+orderDesert+deliveryTax;

Console.WriteLine(finalOrder);
//Изход
//Да се отпечата на конзолата един ред:  "{цена на поръчката}"
