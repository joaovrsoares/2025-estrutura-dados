using System.Collections;

/*
 * A tabela hash é baseada no conceito de par chave-valor.
 * A chave é a forma de se acessar o respectivo valor e, por ser chave, deve ser ÚNICA.
 */

Hashtable ht = new Hashtable()
{
    { "João", "123" },
    { "Vitor", "456" }
};

Console.WriteLine("Tabela hash criada com sucesso.");

// Adicionando novos pares
ht["Soares"] = "789"; // Forma 1
ht.Add("da", "10"); // Forma 2

// Verificar se existem pares chave-valor na tabela ht
if (ht.Count > 0)
{
    // Percorrer os pares armazenados
    foreach (DictionaryEntry entry in ht)
    {
        Console.WriteLine($"Chave: {entry.Key}, valor: {entry.Value}.");
    }
}
else
{
    Console.WriteLine("A tabela hash está vazia.");
}

/*
 * Vimos que ao adicionar uma chave repetida a uma hash table, o programa crasha e interrompe a execução.
 * Para evitar esse comportamento, fazemos uso da cláusula (sentença) try-catch.
 */
Console.WriteLine("\nAdicionando chave-valor com chave repetida...");

try
{
    ht.Add("João", "123");
    Console.WriteLine("Chave-valor adicionado com sucesso.");
}
catch (ArgumentException)
{
    Console.WriteLine("Não é possível adicionar chaves iguais.");
    // Console.WriteLine(ae.Message);
}
catch (Exception e)
{
    Console.WriteLine($"Erro desconhecido: {e.Message}");
}

// Agora o usuário irá informar
Console.WriteLine("\nAdicionando chave-valor informada pelo usuário...");
Console.Write("Informe uma chave para adicionar na tabela hash: ");
string? key = Console.ReadLine();
Console.Write("Informe um valor para adicionar na tabela hash: ");
string? value = Console.ReadLine();

try
{
    ht.Add(key!, value!);
    Console.WriteLine("Chave-valor adicionado com sucesso.");
}
catch (ArgumentException)
{
    Console.WriteLine("Não é possível adicionar chaves iguais.");
    // Console.WriteLine(ae.Message);
}
catch (Exception e)
{
    Console.WriteLine($"Erro desconhecido: {e.Message}");
}

// Agora faremos uma busca na tabela hash
Console.Write("\nInforme uma chave para buscar na tabela hash: ");
string search = Console.ReadLine()!;
Console.WriteLine(ht.ContainsKey(search)
    ? $"Encontrado {search}, com valor {ht[search]}."
    : $"Chave {search} não encontrada.");