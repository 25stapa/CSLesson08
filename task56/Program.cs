/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

// Declaration and initialization of a two-dimensional array.
int m = GetParameter2DArray("Enter the number of rows: ");
int n = GetParameter2DArray("Enter the number of columns: ");
int[,] array2D = Init2DArray();

//  Method for getting array parameters
int GetParameter2DArray(string message)
{
    int num = 0;
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out num) && num > 1)
        {
            break;
        }
        else
        {
            Console.WriteLine("You entered not a number, or a number less than or equal to one, please try again...");
        }
    }
    return num;
}

//  Method for obtaining a two-dimensional array with random numbers(-10; 10).
int[,] Init2DArray()
{
    int[,] matrix = new int[m, n];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(-10, 11);
        }

    }
    return matrix;
}

//  Method for outputting a two-dimensional array to the console
void Print2DArray(int[,] array2D)
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

Console.WriteLine();
Print2DArray(array2D);

//  Method that returns the sum of the elements of a string
int SumRowElements(int[,] array2D, int i)
{
    int sumRow = array2D[i, 0];
    for (int j = 1; j < array2D.GetLength(1); j++)
    {
        sumRow += array2D[i, j];
    }
    return sumRow;
}


int rowMinSum = 0;
int sumRow = SumRowElements(array2D, 0);

for (int i = 1; i < array2D.GetLength(0); i++)
{
    int tempSumRow = SumRowElements(array2D, i);
    if (sumRow > tempSumRow)
    {
        sumRow = tempSumRow;
        rowMinSum = i;
    }
}

Console.WriteLine($"\nRow with minimum sum of elements: {rowMinSum + 1}\nSum of row elements: {sumRow}");
