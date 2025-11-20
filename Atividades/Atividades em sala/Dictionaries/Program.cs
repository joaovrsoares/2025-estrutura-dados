// Aplicativo de console para gerenciar códigos de rastreio (chave)
// e códigos de barras (valor) de encomendas.

/* ENUNCIADO:
 * Uma empresa de entregas e logística precisa gerenciar os códigos das etiquetas de entrega para cada pacote de produto em seu respectivo código de barras. Observe que a chave é o código de rastreio e o valor é o código de barras da encomenda.
 * Escreva um produto que armazene em um dicionário uma quantidade x de informações referentes ao rastreio e ao pacote, permitindo ao usuário inserí-las em tempo de execução.
 * Tome cuidado para que o sistema informe quando houver lançamentos repetidos e não ocasionar erros inesperados. Em seguida, forneça um recurso para que o usuário possa procurar tanto por código de rastreio quanto por código da encomenda e dê um retorno amigável e informativo ao usuário.
 */

var rastreios = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

while (true)
{
    MostrarMenu();
    Console.Write("Escolha uma opção: ");
    var opcao = Console.ReadLine()?.Trim();

    switch (opcao)
    {
        case "1":
            InserirVarios();
            break;
        case "2":
            InserirUnico();
            break;
        case "3":
            PesquisarPorRastreio();
            break;
        case "4":
            PesquisarPorBarcode();
            break;
        case "5":
            ListarTodos();
            break;
        case "0":
        case "s":
        case "S":
            Console.WriteLine("Saindo... Até logo!");
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

    Pausar();
}

void MostrarMenu()
{
    Console.WriteLine();
    Console.WriteLine("=== Gerenciador de Etiquetas de Entrega ===");
    Console.WriteLine("1) Inserir vários lançamentos (quantidade X)");
    Console.WriteLine("2) Inserir um lançamento");
    Console.WriteLine("3) Pesquisar por código de rastreio (chave)");
    Console.WriteLine("4) Pesquisar por código de barras (valor)");
    Console.WriteLine("5) Listar todos os lançamentos");
    Console.WriteLine("0) Sair");
}

void InserirVarios()
{
    var qtdStr = LerNaoVazio("Informe a quantidade de lançamentos que deseja inserir: ");
    if (!int.TryParse(qtdStr, out var qtd) || qtd <= 0)
    {
        Console.WriteLine("Quantidade inválida. Operação cancelada.");
        return;
    }

    for (int i = 1; i <= qtd; i++)
    {
        Console.WriteLine($"\nLançamento {i} de {qtd}");
        InserirUmFluxo();
    }
}

void InserirUnico() => InserirUmFluxo();

void InserirUmFluxo()
{
    var rastreio = LerNaoVazio("Digite o código de rastreio: ");
    var barcode = LerNaoVazio("Digite o código de barras da encomenda: ");

    // Verifique se já existe um par com o mesmo barcode vinculado a outro rastreio
    string? rastreioExistenteParaMesmoBarcode = null;
    foreach (var kv in rastreios)
    {
        if (string.Equals(kv.Value, barcode, StringComparison.OrdinalIgnoreCase))
        {
            rastreioExistenteParaMesmoBarcode = kv.Key;
            break;
        }
    }

    if (rastreioExistenteParaMesmoBarcode != null && !string.Equals(rastreioExistenteParaMesmoBarcode, rastreio, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine($"Atenção: este código de barras já está associado ao rastreio '{rastreioExistenteParaMesmoBarcode}'.");
        if (!Confirmar("Deseja mover/associar este código de barras para o novo rastreio informado? (s/n): "))
        {
            Console.WriteLine("Operação cancelada pelo usuário.");
            return;
        }

        // Remover a associação anterior
        rastreios[rastreioExistenteParaMesmoBarcode] = string.Empty; // limpar temporariamente
        // Se o rastreio anterior ficar vazio, opcionalmente poderíamos removê-lo
        if (string.IsNullOrWhiteSpace(rastreios[rastreioExistenteParaMesmoBarcode]))
        {
            rastreios.Remove(rastreioExistenteParaMesmoBarcode);
        }
    }

    if (rastreios.ContainsKey(rastreio))
    {
        var atual = rastreios[rastreio];
        if (string.Equals(atual, barcode, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Lançamento repetido: o rastreio já está associado a este mesmo código de barras. Nenhuma alteração realizada.");
        }
        else
        {
            Console.WriteLine($"Rastreio já existente. Atual: '{atual}'. Novo: '{barcode}'.");
            if (Confirmar("Deseja atualizar o código de barras deste rastreio? (s/n): "))
            {
                rastreios[rastreio] = barcode;
                Console.WriteLine("Atualização realizada com sucesso.");
            }
            else
            {
                Console.WriteLine("Atualização cancelada pelo usuário.");
            }
        }
    }
    else
    {
        rastreios[rastreio] = barcode;
        Console.WriteLine("Lançamento inserido com sucesso.");
    }
}

void PesquisarPorRastreio()
{
    var rastreio = LerNaoVazio("Informe o código de rastreio para pesquisa: ");
    if (rastreios.TryGetValue(rastreio, out var barcode))
    {
        Console.WriteLine($"Encontrado! Rastreio: '{rastreio}' -> Código de barras: '{barcode}'.");
    }
    else
    {
        Console.WriteLine("Nenhum registro encontrado para o rastreio informado.");
    }
}

void PesquisarPorBarcode()
{
    var barcode = LerNaoVazio("Informe o código de barras para pesquisa: ");
    foreach (var kv in rastreios)
    {
        if (string.Equals(kv.Value, barcode, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Encontrado! Código de barras '{barcode}' pertence ao rastreio '{kv.Key}'.");
            return;
        }
    }
    Console.WriteLine("Nenhum registro encontrado para o código de barras informado.");
}

void ListarTodos()
{
    if (rastreios.Count == 0)
    {
        Console.WriteLine("Nenhum lançamento cadastrado até o momento.");
        return;
    }

    Console.WriteLine("\nLista de lançamentos (rastreio -> código de barras):");
    foreach (var kv in rastreios)
    {
        Console.WriteLine($"- {kv.Key} -> {kv.Value}");
    }
}

string LerNaoVazio(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var s = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(s))
            return s;
        Console.WriteLine("Entrada vazia. Tente novamente.");
    }
}

bool Confirmar(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var s = Console.ReadLine()?.Trim().ToLowerInvariant();
        if (s == "s" || s == "sim") return true;
        if (s == "n" || s == "nao" || s == "não") return false;
        Console.WriteLine("Resposta inválida. Digite 's' para sim ou 'n' para não.");
    }
}

void Pausar()
{
    Console.WriteLine();
    Console.Write("Pressione ENTER para continuar...");
    Console.ReadLine();
}
