/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

// Declaration and initialization of a two-dimensional array.
int m = GetParameterArray2D("Enter the number of rows: ");
int n = GetParameterArray2D("Enter the number of columns: ");
int[,] array2D = InitArray2D();


int[,] InitArray2D()
{
    int[,] arr = new int[m, n];
    Random rnd = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = rnd.Next(0, 11);
        }
    }
    return arr;
}

//  Method for outputting a two-dimensional array to the console
void PrintArray2D(int[,] array2D)
{
    for (int m = 0; m < array2D.GetLength(0); m++)
    {
        for (int n = 0; n < array2D.GetLength(1); n++)
        {
            Console.Write($"{array2D[m, n]}; ");
        }
        Console.WriteLine();
    }
}

//  Method for getting array parameters
int GetParameterArray2D(string message)
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
Console.WriteLine();
Console.WriteLine("Given two-dimensional array:\n");

PrintArray2D(array2D);
Console.WriteLine();

//  Method for sorting rows in descending order
void SortToLower(int[,] array2D)
{
    for (int i = 0; i < array2D.GetLength(0); i++)
    {
        for (int j = 0; j < array2D.GetLength(1); j++)
        {
            for (int k = 0; k < array2D.GetLength(1) - 1; k++)
            {
                if (array2D[i, k] < array2D[i, k + 1])
                {
                    int temp = array2D[i, k + 1];
                    array2D[i, k + 1] = array2D[i, k];
                    array2D[i, k] = temp;
                }
            }
        }
    }
}

SortToLower(array2D);
Console.WriteLine("Sorted 2D array\n");
PrintArray2D(array2D);

Console.WriteLine();
