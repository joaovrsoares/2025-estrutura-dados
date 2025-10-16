int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
SelectionSort.SelectionSort.Sort(integerValues);
Console.WriteLine("Vetor de inteiros:");
Console.WriteLine(string.Join(", ", integerValues));
Console.WriteLine("***********************");

Console.WriteLine("Vetor de nomes:");
string[] stringValues = { "Estouro de pilha", "Memória insuficiente", "Fora dos limites", "Exceção de ponteiro nulo", "Referência nula" };
SelectionSort.SelectionSort.Sort(stringValues);
Console.Write(string.Join(",\n", stringValues.Select(s => $"- {s}")));