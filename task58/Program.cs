/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

//  Method for getting array parameters
int GetParamArray(string message)
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

// Declaration and initialization parameters of a two-dimensional array.
int m = GetParamArray("Enter the number of rows first array: ");
int n = GetParamArray("Enter the number of columns first array and rows second array : ");
int p = GetParamArray("Enter the number of columns second array: ");

//  Method for obtaining a range of random numbers.
int GetInputNumbers(string input)
{
    int inpNum = 0;
    while (true)
    {
        Console.Write(input);
        if (int.TryParse(Console.ReadLine(), out inpNum) && inpNum != 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("You entered not a number, or a number less than or equal to one, please try again...");
        }
    }
    return inpNum;
}

//  Getting a Range of Random Numbers.
int inpNum = GetInputNumbers("Enter a range of random numbers: from 1 to: ");

int[,] firstArray2D = new int[m, n];
InitArray2D(firstArray2D);
Console.WriteLine("\nFirst array 2D:");
PrintArray2D(firstArray2D);

int[,] secondArray2D = new int[n, p];
InitArray2D(secondArray2D);
Console.WriteLine("\nSecond array 2D:");
PrintArray2D(secondArray2D);

int[,] resultArray2D = new int[m, p];

//  Method for obtaining a two-dimensional array with random numbers
void InitArray2D(int[,] array)
{
    //int[,] array = new int[m, n];
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(1,inpNum + 1);
        }
    }
}

//  Method for outputting a two-dimensional array to the console
void PrintArray2D(int[,] array)
{
    for (int m = 0; m < array.GetLength(0); m++)
    {
        for (int n = 0; n < array.GetLength(1); n++)
        {
            Console.Write($"{array[m, n]}; ");
        }
        Console.WriteLine();
    }
}

//  Multiplication of the first and second array
MultiplyArray2D(firstArray2D, secondArray2D, resultArray2D);
Console.WriteLine($"\nMultiplication of the first and second array:");
PrintArray2D(resultArray2D);

//Method for multiplying first and second array2D
void MultiplyArray2D(int[,] firstArray2D, int[,] secomdArray2D, int[,] resultArray2D)
{
    for (int i = 0; i < resultArray2D.GetLength(0); i++)
    {
        for (int j = 0; j < resultArray2D.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < firstArray2D.GetLength(1); k++)
            {
                sum += firstArray2D[i, k] * secomdArray2D[k, j];
            }
            resultArray2D[i, j] = sum;
        }
    }
}
