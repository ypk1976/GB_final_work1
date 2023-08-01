// 1. Создать репозиторий на GitHub
// 2. Нарисовать блок-схему алгоритма (можно обойтись блок-схемой основной содержательной части, если вы выделяете её в отдельный метод)
// 3. Снабдить репозиторий оформленным текстовым описанием решения (файл README.md)
// 4. Написать программу, решающую поставленную задачу
// 5. Использовать контроль версий в работе над этим небольшим проектом (не должно быть так, что всё залито одним коммитом, как минимум этапы 2, 3, и 4 должны быть расположены в разных коммитах)

// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

int maxSymbols = 3; //Максимальная длина строки.
int maxElements = 5; //Максимальное количество элементов массива при вводе с клавиатуры
// Задаем исходный массив строк для работы с параметром (1)
string[] inputParameter = { "Hello", "Hi", "Bye", "OK", "No", "Yes", "Wow", "C#", "Success" };

// Выводим приглашение на выбор варианта заполнения массива
Console.WriteLine("Пожалуйста, введите способ заполнения первоначального массива:");
Console.WriteLine("1 - из параметра, 2 - с клавиатуры");
int choice = Convert.ToInt32(Console.ReadLine());

if (CheckValidity(choice))
{
    switch (choice)
    {
        case 1:
            {
                Console.WriteLine("Выбран ввод из параметра");
                ProcessParameter(inputParameter);
                break;
            }
        case 2:
            {
                Console.WriteLine("Выбран ввод с клавиатуры");
                FillArray(maxElements);
                break;
            }
    }
}

void FillArray(int size)
{
    string[] array = new string[size];
    for (int i = 0; i < size; i++)
    {
        Console.WriteLine($"Введите значение {i + 1}-го элемента:");
        string element = Console.ReadLine();
        array[i] = element;
    }
    ProcessParameter(array);
}

bool CheckValidity(int choice)
{
    if (choice < 1 || choice > 2)
    {
        Console.WriteLine("Возможные варианты 0 или 1");
        return false;
    }
    return true;
}

void ProcessParameter(string[] input)
{
    Console.WriteLine("Исходный массив:");
    Console.Write("[");
    for (int i = 0; i < input.Length; i++)
    {
        if (i < (input.Length - 1)) Console.Write($"\"{input[i]}\", ");
        else Console.Write($"\"{input[i]}\"]");
    }
    Console.WriteLine();
    string[] output = new string[input.Length];
    int count = 0;
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i].Length <= maxSymbols)
        {
            output[count] = input[i];
            count++;
        }
    }
    Array.Resize(ref output, count);
    Console.WriteLine("Новый массив из коротких строк:");
    Console.Write("[");
    for (int i = 0; i < output.Length; i++)
    {
        if (i < (output.Length - 1)) Console.Write($"\"{output[i]}\", ");
        else Console.Write($"\"{output[i]}\"]");
    }
    Console.WriteLine();
}

