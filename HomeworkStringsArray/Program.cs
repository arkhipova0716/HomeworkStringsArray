// maxNewStringLenght - Глобальная переменная, в которой хранится максимальная длина новых строк
int maxNewStringLenght = 3;
// arrayLength - Количество строк для инициализации массива
int arrayLength;

// Инициализируем переменную rnd типа класса Random для генерации случайных чисел
Random rnd = new Random();

// Бесконечный цикл, который будет работать до тех пор, пока не будет введено число
while (true) {
    Console.Write("Введите количество строк в массиве: ");
    // Попытка ввода с клавиатуры кол-ва строк в массиве
    // Проверяем, введено ли число, если да, введенное число будет записано в переменную arrayLength
    if (int.TryParse(Console.ReadLine(), out arrayLength))
    {
        // Если число, выходим из цикла
        break;
    }

    // Если введено не число, выводим соотв. сообщение
    Console.WriteLine("Пожалуйста, введите число!\n");
}


// Инициализация нового массива, размер которого равен arrayLength
string[] inputStringsArray = new string[arrayLength];

// Проходим циклом arrayLength раз и заполняем inputStringsArray с клавиатуры
for (int i = 0; i < arrayLength; i++)
{
    // Бесконечный цикл, который будет работать до тех пор, пока не будет введено что-либо
    while (true)
    {
        Console.Write($"Строка #{i}: ");

        // Временная переменная, в которой хранится то, что было введено с клавиатуры
        string tmp = Console.ReadLine();

        // Проверяем, не пустая ли строка
        if (!string.IsNullOrEmpty(tmp))
        {
            // Если не пустая, записываем значение по индексу в массив и идем дальше
            inputStringsArray[i] = tmp;
            break;
        }

        // Если нет, выводим соотв. сообщение
        Console.WriteLine("Строка не может быть пустой! Пожалуйста, попробуйте еще раз.");
    }
}

// Инициализация нового массива, размерностью arrayLenght, который будет заполнен на основе массива inputStringsArray
string[] newStringsArray = new string[arrayLength];

// Проходим циклом arrayLength и заполняем newStringsArray на основе inputStringsArray
for (int i = 0; i < arrayLength; i++)
{
    // Создаем переменную, которой присваиваем значение из массива inputStringsArray
    string fromInputStringsArray = inputStringsArray[i];

    // Инциализируем новую переменную, которой будет присвоено случайное число от 1 до 3
    int newStringLenght;

    // Если длина строки из первого массива меньше или равна maxNewStringLenght, то генерируем случайное число от 1 до длины строки
    if (fromInputStringsArray.Length <= maxNewStringLenght)
    {
        newStringLenght = rnd.Next(1, fromInputStringsArray.Length + 1);
    }
    // Иначе генерируем случайное число от 1 до maxNewStringLenght
    else
    {
        newStringLenght = rnd.Next(1, maxNewStringLenght + 1);
    }

    // Создаем переменную shuffledInputStringsArray, которой присваиваем строку из первого массива, в которой перемешаны буквы местами с помощью случайно сортировки
    string shuffledInputStringsArray = string.Join("", fromInputStringsArray.OrderBy(x => rnd.Next()));

    // Присваиваем по индексу в новом массиве значение, которое берет первые newStringLenght символа из перемешанной строки shuffledInputStringsArray
    newStringsArray[i] = shuffledInputStringsArray.Substring(0, newStringLenght);
}

// Выводим новый массив
Console.Write("[");
for (int i = 0; i< arrayLength; i++)
{
    if (i > 0)
    {
        // Если это не первый элемент, выводим запятую и пробел перед самой строчкой
        Console.Write(", ");
    }
    Console.Write($"\"{newStringsArray[i]}\"");
}