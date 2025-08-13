using System.Globalization;

Console.WriteLine("");
Console.WriteLine("Informe o seu nome: ");

// ? -> Operador Nullable
// Indica que a variável pode receber valor nulo
string? name = Console.ReadLine();

Console.WriteLine(
    $"Seja bem-vindo {name}!\n"
);

// Declarando Vetor
// Sem inicialização
int[] numbers;

// Inicializando vetor
numbers = new int[5];

// Tudo numa linha
int[] numbers2 = new int[5];

// Atribuindo valores ao vetor
numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;
numbers[3] = 4;
numbers[4] = 5;

// Declarando e inicializando vetor
int[] numbers3 = new int[] { 1, 2, 3, 4, 5 };

// Simplificando a declaração
int[] numbers4 = { 1, 2, 3, 4, 5 };

// Preenchendo um vetor com os 12 meses do ano
string[] months = new string[12];

for (int i = 1; i <= 12; i++)
{
    DateTime firstDay =
        new DateTime(DateTime.Now.Year, i, 1);

    string monthName =
        firstDay.ToString(
            "MMMM",
            CultureInfo.CreateSpecificCulture("en")
        );

    months[i - 1] = monthName;
}

foreach (string month in months)
{
    Console.WriteLine(month);
}

// Array multidimensional
// Duas dimensões
int[,] numbers52 = new int[5, 2];

// Três dimensões
int[,,] numbers543 = new int[5, 4, 3];

// Inicializando matriz valorada 
int[,] nmb = new int[,] {
    { 1, 2, -9 },
    { 5, 7, 10 },
    { 6, 115, 54 }
};

// Também podemos acessar a matriz da seguinte maneira
int myNumber = nmb[2, 1];
Console.WriteLine("Imprimindo o valor da matriz: ");
Console.WriteLine(myNumber);

