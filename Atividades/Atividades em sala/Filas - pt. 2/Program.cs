using Filas;
using Filas___pt._2;

static void Main(string[] args)
{
    CallCenter center = new CallCenter();
    Parallel.Invoke(
        () => CallersAction(center),
        () => ConsultantsAction(center, "Isaias", ConsoleColor.Red),
        () => ConsultantsAction(center, "Durigon", ConsoleColor.Yellow),
        () => ConsultantsAction(center, "Marcos", ConsoleColor.Green));
}

private static void CallersAction(CallCenter center) {
    Random random = new Random();
    while (true)
    {
        int clientId = random.Next(1, 10000);
        int waitingCount = center.Call(clientId);
        Log($"Chamada do {clientId}, aguardando na fila: {waitingCount}");
        Thread.Sleep(random.Next(1000, 5000));
    }
}

private static void ConsultantsAction(CallCenter center, string name, ConsoleColor color) {
    Random random = new Random();
    while (true)
    {
        IncomingCall call = center.Answer(name);
        if (call != null)
        {
            Console.ForegroundColor = color;
            Log($"Chamado ")
        }
    }
}