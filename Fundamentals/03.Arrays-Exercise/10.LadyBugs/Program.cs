
int fieldSize = int.Parse(Console.ReadLine());

int[] field = new int[fieldSize];

int[] tempfield = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

for (int i = 0; i < tempfield.Length; i++)
{
    int bugIndex= tempfield[i];
    if( bugIndex >=0 && bugIndex <= field.Length - 1)
    {
        field[bugIndex] = 1;
    }


}

string input;
while ((input = Console.ReadLine()) != "end")
{
    string[] inputArray = input.Split(" ");

    int index0Bug = int.Parse(inputArray[0]);
    string index1Direction = inputArray[1];
    int index2Movement = int.Parse(inputArray[2]);

    if (index0Bug < 0 || index0Bug >field.Length-1 || field[index0Bug] != 1 )
    {
        continue;
    }
    else
    {
        field[index0Bug] = 0;

        if (index1Direction == "right")
        {
            int landIndex = index0Bug + index2Movement;
            if (landIndex > field.Length - 1)
            {
                continue;
            }
            if (field[landIndex] == 1)
            {
                while (field[landIndex] == 1)
                {
                    landIndex += index2Movement;
                    if (landIndex > field.Length - 1)
                    {
                        break;
                    }
                }
            }

            if (landIndex <= field.Length - 1)
            {
                field[landIndex] = 1;
            }
        }

        if (index1Direction == "left")
        {
            int landIndex = index0Bug - index2Movement;

            if (landIndex <0)
            {
                continue;
            }

            if (field[landIndex] == 1)
            {
                while (field[landIndex] == 1)
                {
                    landIndex -= index2Movement;
                    if (landIndex <0)
                    {
                        break;
                    }
                }
            }

            if (landIndex >=0)
            {
                field[landIndex] = 1;
            }
        }


        //    if (index2Movement < 0)
        //    {
        //        for (int i = Math.Abs(index2Movement)+index0Bug; i >= field.Length; i++)
        //        {
        //            if (i == field.Length)
        //            {
        //                field[index0Bug] = 0;
        //                break;
        //            }
        //            else if (field[i] == 1)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                field[i] = 1;
        //                field[index0Bug] = 0;
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = index0Bug + index2Movement; i <= field.Length; i++)
        //        {
        //            if (i == field.Length)
        //            {
        //                field[index0Bug] = 0;
        //                break;
        //            }
        //            else if (field[i] == 1)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                field[i] = 1;
        //                field[index0Bug] = 0;
        //                break;
        //            }
        //        }
        //    }
        //}
        //else if (index1Direction == "left")
        //{
        //    if (index2Movement < 0)
        //    {
        //        for (int i = Math.Abs(index2Movement)+index0Bug; i >= field.Length - fieldSize - 1; i--)
        //        {
        //            if (i == field.Length - fieldSize - 1)
        //            {
        //                field[index0Bug] = 0;
        //                break;
        //            }
        //            else if (field[i] == 1)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                field[i] = 1;
        //                field[index0Bug] = 0;
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = index0Bug - index2Movement; i >= field.Length - fieldSize - 1; i--)
        //        {
        //            if (i == field.Length - fieldSize - 1)
        //            {
        //                field[index0Bug] = 0;
        //                break;
        //            }
        //            else if (field[i] == 1)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                field[i] = 1;
        //                field[index0Bug] = 0;
        //                break;
        //            }
        //        }
        //    }
        //}
    }


}
Console.WriteLine(string.Join(" ", field));