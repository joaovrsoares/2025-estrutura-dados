// Recursividade: chamar a função dentro dela mesma
// Exemplo: calcular a sequência de Fibonacci (0, 1, 1, 2, 3, 5, 8, 13, 21, ...)

static int Fibonacci(int n)
{
    if (n == 0) return 0; // caso base
    if (n == 1) return 1; // caso base
    if (n < 0) return -1; // caso inválido

    return Fibonacci(n - 1) + Fibonacci(n - 2); // chamada recursiva
}



/*Console.WriteLine("Digite um número para calcular a sequência de Fibonacci:");
int n = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i <= n; i++) {
    Console.Write(Fibonacci(i) + " "); // Para mostrar a sequência de Fibonacci até o número n
}
*/

static int Factorial(int n) {
    if (n == 0) return 1; // caso base
    else return n * Factorial(n - 1); // chamada recursiva
}

Console.WriteLine("Digite um número para calcular o fatorial:");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("O fatorial de " + n + " é: " + Factorial(n));