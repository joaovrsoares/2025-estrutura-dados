int[] numeros = { 2, 4, 6, 8, 10 };
Console.WriteLine(BinarySearchIterative(numeros, 8)); // Saída: 4

string[] nomes = { "Ana", "Bruno", "Carlos", "Diana" };
Console.WriteLine(BinarySearchIterative(nomes, "Carlos")); // Saída: 3

double[] valores = { 1.1, 2.2, 3.3, 4.4, 5.5 };
Console.WriteLine(BinarySearchIterative(valores, 6.6)); // Saída: Nil

static Object BinarySearchIterative<T>(T[] inputArray, T key) where T : IComparable
{
    int min = 0;
    int max = inputArray.Length - 1;

    while (min <= max)
    {
        int mid = (min + max) / 2;
        int comparison = key.CompareTo(inputArray[mid]);

        if (comparison == 0)
        {
            // Retorna índice (1-based, como no código original)
            return mid + 1;
        }
        else if (comparison < 0)
        {
            max = mid - 1;
        }
        else
        {
            min = mid + 1;
        }
    }

    return "Nil";
}

static object BinarySearchRecursive<T>(T[] inputArray, T key, int min, int max) where T : IComparable
{
    if (min > max)
    {
        return "Nil";
    }
    else
    {
        int mid = (min + max) / 2;
        int comparison = key.CompareTo(inputArray[mid]);

        if (comparison == 0)
        {
            // Retorna índice (1-based, como no código original)
            return mid + 1;
        }
        else if (comparison < 0)
        {
            return BinarySearchRecursive(inputArray, key, min, mid - 1);
        }
        else
        {
            return BinarySearchRecursive(inputArray, key, mid + 1, max);
        }
    }
}