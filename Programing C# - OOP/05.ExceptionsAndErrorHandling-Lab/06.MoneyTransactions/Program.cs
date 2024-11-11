namespace _06.MoneyTransactions
{
    public class Program
    {
        static void Main()
        {

            string[] intput = Console.ReadLine().Split(",");
            Dictionary<int, double> accountBalanceByAccountNumber = new Dictionary<int, double>();

            InputToDictionary(intput, accountBalanceByAccountNumber);

            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    ChechCommand(accountBalanceByAccountNumber, input);

        
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }  
                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (KeyNotFoundException ex)
                {
                    Console.WriteLine("Invalid account!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                input = Console.ReadLine();
            }
        }

        private static void InputToDictionary(string[] intput, Dictionary<int, double> accountBalanceByAccountNumber)
        {
            foreach (string str in intput)
            {
                string[] temp = str.Split("-");
                accountBalanceByAccountNumber.Add(int.Parse(temp[0]), double.Parse(temp[1]));
            }
        }

        private static void ChechCommand(Dictionary<int, double> accountBalanceByAccountNumber, string input)
        {
            string[] temp = input.Split(" ");
            string command = temp[0];
            int accountNumber = int.Parse(temp[1]);
            double requaredSum = double.Parse(temp[2]);

            switch (command)
            {
                case "Deposit":
                    accountBalanceByAccountNumber[accountNumber] += requaredSum;
                    break;
                case "Withdraw":
                    if (requaredSum > accountBalanceByAccountNumber[accountNumber])
                        throw new ArithmeticException("Insufficient balance!");
                    else
                        accountBalanceByAccountNumber[accountNumber] -= requaredSum;
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }

            KeyValuePair<int,double> individAccountNumberBalance = accountBalanceByAccountNumber.First(x => x.Key == accountNumber);

            Console.WriteLine($"Account {individAccountNumberBalance.Key} has new balance: {individAccountNumberBalance.Value:f2}");
   
        }
    }
}
