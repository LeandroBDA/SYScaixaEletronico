public static void Depositar(User user)
{
    Console.WriteLine("QUANTO VOCÊ DESEJA DEPOSITAR?");
    decimal valor = decimal.Parse(Console.ReadLine());

    if (valor < 0)
    {
        Console.WriteLine("O VALOR INSERIDO NÃO PODE SER ZERO. TENTE NOVAMENTE!");
        Thread.Sleep(3000); Console.Clear();
        Depositar(user);
    }

    else
    {
        user.Depositar(valor, user);
        Console.WriteLine("VALOR DEPOSITADO COM SUCESSO");
        Thread.Sleep(3000); Console.Clear();
        Console.WriteLine($"SEU SALDO ATUAL É DE: {user.Saldo} ");
        Thread.Sleep(3000);
        Console.Clear(); Syscaixa(user);
    }

}