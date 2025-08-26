using System;

class TicTacToe {

    static void Main(string[] args) {

        char[,] grid = new char[3, 3];

        int currentPlayer = 1;
        int rounds = 0;

        StartGrid(grid);

        while (true) {
            Console.Clear();
            PrintGrid(grid);

            char symbol = (currentPlayer == 1) ? 'X' : 'O';
            Console.Write("É a vez do jogador ");
            ColouredWrite(symbol);
            Console.WriteLine();

            Console.Write("Escolha uma posição de 1 a 9: ");

            if (int.TryParse(Console.ReadLine(), out int position)) {
                if (MakeMove(grid, position, symbol)) {
                    rounds++;

                    // Após 5 rodadas, já dá para ter um vencedor
                    if (rounds >= 5) {
                        if (CheckForWinner(grid, symbol)) {
                            Console.Clear();
                            PrintGrid(grid);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"🎉 Parabéns! O jogador {symbol} venceu!");
                            Console.ResetColor();
                            break;
                        }
                    }

                    if (rounds == 9) {
                        Console.Clear();
                        PrintGrid(grid);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("👵 Deu velha! O jogo terminou sem vencedores.");
                        Console.ResetColor();
                        break;
                    }

                    currentPlayer = (currentPlayer == 1) ? 2 : 1;
                } else {
                    Console.WriteLine("Jogada inválida! A posição já está ocupada ou o número não existe. Pressione Enter para tentar de novo.");
                    Console.ReadLine(); // Pausa para o jogador ler a mensagem.
                }
            } else {
                Console.WriteLine("Entrada inválida! Por favor, digite um número de 1 a 9. Pressione Enter para continuar.");
                Console.ReadLine(); // Pausa para o jogador ler a mensagem.
            }
        }

        Console.WriteLine("Fim de jogo! Pressione Enter para sair.");
        Console.ReadLine(); // Pausa para o jogador ler a mensagem.
    }

    static bool MakeMove(char[,] grid, int position, char symbol) {
        int row = (position - 1) / 3; // Linha
        int col = (position - 1) % 3; // Coluna

        if (grid[row, col] != 'X' && grid[row, col] != 'O') {
            grid[row, col] = symbol;
            return true;
        }
        return false;
    }

    static bool CheckForWinner(char[,] grid, char symbol) {
        for (int i = 0; i < 3; i++) {
            // Verificar linhas
            if (grid[i, 0] == symbol && grid[i, 1] == symbol && grid[i, 2] == symbol)
                return true;
            // Verificar colunas
            if (grid[0, i] == symbol && grid[1, i] == symbol && grid[2, i] == symbol)
                return true;
        }
        // Verificar diagonais
        if (grid[0, 0] == symbol && grid[1, 1] == symbol && grid[2, 2] == symbol)
            return true;
        if (grid[0, 2] == symbol && grid[1, 1] == symbol && grid[2, 0] == symbol)
            return true;

        return false;
    }

    // Preenche o tabuleiro de 1 a 9
    static void StartGrid(char[,] grid) {
        char number = '1';
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                grid[i, j] = number++;
            }
        }
    }

    static void PrintGrid(char[,] tabuleiro) {
        Console.WriteLine("     |     |     ");
        for (int i = 0; i < 3; i++) {
            Console.Write("  ");
            ColouredWrite(tabuleiro[i, 0]);
            Console.Write("  |  ");
            ColouredWrite(tabuleiro[i, 1]);
            Console.Write("  |  ");
            ColouredWrite(tabuleiro[i, 2]);
            Console.WriteLine();

            if (i < 2)
                Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
        }
    }

    // Função auxiliar para imprimir o símbolo colorido
    static void ColouredWrite(char c) {
        if (c == 'X')
            Console.ForegroundColor = ConsoleColor.Blue;
        else if (c == 'O')
            Console.ForegroundColor = ConsoleColor.Red;
        else // números 1 a 9
            Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.Write(c);
        Console.ResetColor();
    }
}