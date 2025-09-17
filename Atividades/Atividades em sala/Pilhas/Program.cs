using System.Collections.Generic;

Console.WriteLine("Invertendo palavras com pilhas (stacks)");

Console.WriteLine("Digite uma palavra");
string palavra = Console.ReadLine() ?? string.Empty;

Stack<char> chars = new Stack<char>();
foreach (var c in palavra)
    chars.Push(c);

string palavra_invertida = string.Empty;
while (chars.Count > 0)
{
    char c = chars.Pop();
    palavra_invertida += c;
}

if (palavra == palavra_invertida)
{
    Console.WriteLine($"É um fucking palíndromo");
}
else
{
    Console.WriteLine($"Ihhhh, moiô");
}