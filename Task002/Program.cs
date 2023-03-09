// Задача 2: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

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
            array[i, j] = random.Next(1, 20);
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

// Метод поиска строки с минимальной суммой 
int FindSmallestAmountRow(int[,] array)
{
    int minSumRow = 0, minIndex = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sumElement = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumElement += array[i, j];
        }
        if (minSumRow == 0) minSumRow = sumElement;
        if (sumElement < minSumRow)
        {
            minSumRow = sumElement;
            minIndex = i;
        }
    }
    return minIndex;
}

// Обработка исключений
try
{
    int userRow = InputUser("Введите количество строк в двумерном массиве");
    int userCol = InputUser("Введите количество колонок в двумерном массиве");
    int[,] userMatrix = CreationMatrix(userRow, userCol);
    Console.WriteLine("\nЗаполненая матрица  :");
    PrintMatrix(FillMatrix(userMatrix));
    Console.WriteLine($"\nСтрока с наименьшей суммой элементов с индексом : {FindSmallestAmountRow(userMatrix)}");
}
catch (FormatException)
{
    Console.WriteLine("Вы ввели не число =(");
}
