// Задача 3 * : Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

// Метод получения числа от пользователя
int InputUser(string message)
{
    Console.Write($"{message} => ");
    return Convert.ToInt32(Console.ReadLine());
}

// Метод создания двумерного массива
int[,] CreationMatrix(int row, int col)
{
    int[,] array = new int[row, col];
    return array;
}

// Метод заполнения массива псевдорандомными числами
int[,] FillMatrix(int[,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(1, 8);
        }
    }
    return array;
}

// Метод вывода массива
void PrintMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
    }
    Console.WriteLine();
}

// Проверка на возможность перемножения матриц
bool ValidateMultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix)
{
    if (firstMartrix.GetLength(1) == secomdMartrix.GetLength(0)) return true;
    return false;
}

// Метод произведение матриц
int[,] MultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix)
{
    int[,] resultMatrix = new int[secomdMartrix.GetLength(0), secomdMartrix.GetLength(1)];
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < firstMartrix.GetLength(1); k++)
            {
                sum += firstMartrix[i, k] * secomdMartrix[k, j];
            }
            resultMatrix[i, j] = sum;
        }
    }
    return resultMatrix;
}

// Обработка исключений
try
{
    int userRow = InputUser("Введите количество строк в двумерном массиве");
    int userCol = InputUser("Введите количество колонок в двумерном массиве");
    int[,] userMatrix = CreationMatrix(userRow, userCol);
    Console.WriteLine("\nЗаполненая матрица  :");
    PrintMatrix(FillMatrix(userMatrix));

    int userRowTwo = InputUser("Введите количество строк в двумерном массиве");
    int userColTwo = InputUser("Введите количество колонок в двумерном массиве");
    int[,] userMatrixTwo = CreationMatrix(userRowTwo, userColTwo);
    Console.WriteLine("\nЗаполненая матрица  :");
    PrintMatrix(FillMatrix(userMatrixTwo));
    if (ValidateMultiplyMatrix(userMatrix, userMatrixTwo))
    {
        Console.WriteLine("Произведение матриц :");
        PrintMatrix(MultiplyMatrix(userMatrix, userMatrixTwo));
    }
    else
    {
        Console.WriteLine("Эти матрицы перемножить нельзя");
    }
}
catch (FormatException)
{
    Console.WriteLine("Вы ввели не число =(");
}