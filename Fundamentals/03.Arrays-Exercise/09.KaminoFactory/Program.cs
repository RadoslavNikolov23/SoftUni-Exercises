int lengthSequnce = int.Parse(Console.ReadLine());

string input;

int[] currDNA = new int[lengthSequnce];
int[] bestDNA = new int[lengthSequnce];
int sequnceNumber = 0;
int bestSequnceNumber = 0;
int bestSumArray = 0;

int bestOneIndex = 0;

int bestIndexRow = 0;
int bestIndexLenght = 0;






while ((input = Console.ReadLine()) != "Clone them!")
{
    currDNA = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    int counterOneIndex = 0;
    int counterIndexRow = 0;
    int counterIndexLenght = 0;
    sequnceNumber++;


    for (int i = 0; i < currDNA.Length - 1; i++)
    {
        if (currDNA[i].Equals(currDNA[i + 1]))
        {
            counterIndexRow++;
            counterIndexLenght++;
            if(counterIndexRow==1)
            {
                counterOneIndex = i;
            }


        }

    }
    int curentSumArray = currDNA.Sum();


    if (counterOneIndex >= bestIndexRow)
    {
        if (counterOneIndex == bestIndexRow)
        {
            if (curentSumArray > bestSumArray)
            {
                bestDNA = currDNA;
                bestSequnceNumber = sequnceNumber;
                bestSumArray = curentSumArray;
               // bestOneIndex = counterOneIndex;
                bestIndexRow = counterIndexRow;
              //  bestIndexLenght = counterIndexLenght;


            }
            else if (curentSumArray == bestSumArray && counterIndexLenght>bestIndexLenght)
            {
                bestDNA = currDNA;
                bestSequnceNumber = sequnceNumber;
                bestSumArray = curentSumArray;
                // bestOneIndex = counterOneIndex;
                bestIndexRow = counterIndexRow;
                bestIndexLenght = counterIndexLenght;

            }

        }
        else
        {
            bestDNA = currDNA;
            bestSequnceNumber = sequnceNumber;
            bestSumArray = curentSumArray;
            bestOneIndex = counterOneIndex;
           // bestIndexLenght = counterIndexLenght;



        }

    }



}



Console.WriteLine($"Best DNA sample {bestSequnceNumber} with sum: {bestSumArray}.");
Console.WriteLine(string.Join(" ", bestDNA));