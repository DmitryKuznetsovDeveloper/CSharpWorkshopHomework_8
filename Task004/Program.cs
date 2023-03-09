// Задача 4 * : Напишите программу, которая заполнит спирально квадратный массив.

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

// Метод заполнения массива по спирали
int[,] FillMatrixSpiral(int[,] sqareMatrix)
{
    int temp = 1, i = 0, j = 0;      // инициализируем счетчик цифр и индексы
    while (temp <= sqareMatrix.Length) // цикл будет продолжатся пока не заполнит все элементы
    {
        sqareMatrix[i, j] = temp; // присваиваем первому элементу массива значение 1
        temp++; // увеличиваем счетчик цифр
        if (i <= j + 1 && i + j < sqareMatrix.GetLength(1) - 1)
            j++;
        else if (i < j && i + j >= sqareMatrix.GetLength(0) - 1)
            i++;
        else if (i >= j && i + j > sqareMatrix.GetLength(1) - 1)
            j--;
        else
            i--;
    }
    return sqareMatrix;
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

// Обработка исключений
try
{
    int userRow = InputUser("Введите количество строк в двумерном массиве");
    int userCol = InputUser("Введите количество колонок в двумерном массиве");
    int[,] userMatrix = CreationMatrix(userRow, userCol);
    Console.WriteLine("\nЗаполненая матрица по спирали :");
    PrintMatrix(FillMatrixSpiral(userMatrix));
}
catch (FormatException)
{
    Console.WriteLine("Вы ввели не число =(");
}