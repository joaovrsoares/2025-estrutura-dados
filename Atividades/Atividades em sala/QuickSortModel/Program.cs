int[] array = { 5, 2, 9, 1, 5, 6 };
Console.WriteLine("Vetor a ser ordenado:");
Console.WriteLine(string.Join(", ", array));
QuickSortModel.QuickSort.Sort(array);
Console.WriteLine("Vetor ordenado:");
Console.WriteLine(string.Join(", ", array));

Console.WriteLine("Vetor de nomes:");
string[] stringArray = { "Índice fora dos limites", "Estouro de pilha", "Memória insuficiente", "Exceção de ponteiro nulo", "Referência nula" };
QuickSortModel.QuickSort.Sort(stringArray);
Console.Write(string.Join(",\n", stringArray.Select(s => $"- {s}")));