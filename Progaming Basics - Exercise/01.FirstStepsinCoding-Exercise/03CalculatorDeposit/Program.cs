

double deposit=double.Parse(Console.ReadLine());
int depositTimeMonts=int.Parse(Console.ReadLine()); 
double yearIntrest=double.Parse(Console.ReadLine());

double interest = yearIntrest / 100;


double amount = deposit + depositTimeMonts * ((deposit * interest) / 12);

Console.WriteLine(amount);

//Напишете програма, която изчислява каква сума ще получите в края на депозитния период 
//    при определен лихвен процент. Използвайте следната формула: 
//сума = депозирана сума + срок на депозита * ((депозирана сума * годишен лихвен процент ) / 12)

//Изход
//Да се отпечата на конзолата сумата в края на срока.
