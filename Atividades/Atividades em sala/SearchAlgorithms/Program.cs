string[] items = ["olá", "mundo", "isto", "é", "um", "programa", "de", "busca", "em", "C#"];
Console.Write("Digite o item que deseja buscar: ");
string? target = Console.ReadLine();

int LinearSearch(string[] array, string? query)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == query)
        {
            return i; // Encontrado em [i]
        }
    }
    return -1; // Não encontrado
}

int result = LinearSearch(items, target);

if (result != -1)
{
    Console.WriteLine($"Item '{target}' encontrado na posição {result + 1}.");
}
else
{
    Console.WriteLine($"Item '{target}' não encontrado.");
}