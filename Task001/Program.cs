// Задача 1: Задайте двумерный массив. Напишите программу, которая упорядочивает по убыванию элементы каждой строки двумерного массива.

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

// Метод сортировки каждой строки матрицы по убыванию
int[,] SortDescendingRow(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1); k++)
            {
                if (array[i, j] > array[i, k])
                {
                    int temp = array[i, j];
                    array[i, j] = array[i, k];
                    array[i, k] = temp;
                }
            }
        }
    }
    return array;
}

// Обработка исключений
try
{
    int userRow = InputUser("Введите количество строк в двумерном массиве");
    int userCol = InputUser("Введите количество колонок в двумерном массиве");
    int[,] userMatrix = CreationMatrix(userRow, userCol);
    Console.WriteLine("\nЗаполненая матрица  :");
    PrintMatrix(FillMatrix(userMatrix));
    Console.WriteLine("\nДвумерная матрица где строки отсортированны по убыванию :");
    PrintMatrix(SortDescendingRow(userMatrix));
}
catch (FormatException)
{
    Console.WriteLine("Вы ввели не число =(");
}
