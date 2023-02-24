/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

// Declaration and initialization of a three-dimensional array.
Console.WriteLine("Enter array parameters: x, y, z");    
int x = GetParameterArray3D("Enter the number x: ");
int y = GetParameterArray3D("Enter the number y: ");
int z = GetParameterArray3D("Enter the number z: ");
int[,,] array3D = new int[x, y, z];

InitArray(array3D);
Console.WriteLine();
PrintArray(array3D);

//  Method for getting array parameters
int GetParameterArray3D(string message)
{
    int number = 0;
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("You entered not a number, or a number less than or equal to zero, please try again...");
        }
    }
    return number;
}

void InitArray(int[,,] array3D)
{
    int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
    int number;
    for (int i = 0; i < temp.GetLength(0); i++)
    {
        temp[i] = new Random().Next(10, 100);
        number = temp[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temp[i] == temp[j])
                {
                    temp[i] = new Random().Next(10, 100);
                    j = 0;
                    number = temp[i];
                }
                number = temp[i];
            }
        }
    }
    int count = 0;
    for (int x = 0; x < array3D.GetLength(0); x++)
    {
        for (int y = 0; y < array3D.GetLength(1); y++)
        {
            for (int z = 0; z < array3D.GetLength(2); z++)
            {
                array3D[x, y, z] = temp[count];
                count++;
            }
        }
    }
}

//  Method for outputting a three-dimensional array to the console
void PrintArray(int[,,] array3D)
{
    for (int j = 0; j < array3D.GetLength(1); j++)
    {
        for (int i = 0; i < array3D.GetLength(0); i++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"{array3D[i, j, k]}({i},{j},{k}); ");
            }
            Console.WriteLine();
        }
        
    }
}


