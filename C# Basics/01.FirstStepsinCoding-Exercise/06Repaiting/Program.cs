

int neededNylon=int.Parse(Console.ReadLine());
int neededPaint=int.Parse(Console.ReadLine());
int neededTinner=int.Parse(Console.ReadLine());
int neededHoursByWorkers=int.Parse(Console.ReadLine());

double priceNylon = 1.50;
double pricePaint = 14.50;
double priceTinner = 5.00;

double finalNylon=(neededNylon+2)*priceNylon;
double finalPaint = pricePaint * (neededPaint+(neededPaint*0.10));
double finalTinner = neededTinner * priceTinner;

double bag = 0.40;

double allPrice=finalNylon+finalPaint+finalTinner+bag;

double priceWorkers = (allPrice * 0.30) * neededHoursByWorkers;

double finalPrice = allPrice + priceWorkers;

Console.WriteLine(finalPrice);


//разбира се и 0.40 лв. за торбички. 
//Сумата, която се заплаща на майсторите за 1 час работа, 
//е равна на 30% от сбора на всички разходи за материали.

//В
//Изход
//Да се отпечата на конзолата един ред:
//•	"{сумата на всички разходи}"
