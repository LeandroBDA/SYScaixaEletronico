namespace CaixaEletronico;

public class Depositar
{
    public double Saldo { get; set; }
    
    public void Deposito()
    {
        Console.WriteLine("===DEPOSITO===");
        Console.WriteLine("QUANTO VOCÊ DESEJA DEPOSITAR?");
        Saldo = double.Parse(Console.ReadLine());
        Thread.Sleep(3000); 
        Console.Clear();

        if (Saldo == 0 || Saldo < 0)
        {
            Console.WriteLine("O VALOR INSERIDO NÃO PODE SER NULO OU NEGATIVO! POR FAVOR TENTE NOVAMENTE");
            Thread.Sleep(3000);
            Console.Clear();
            Deposito();
        }
        else
        {
            double saldo = Saldo;
            Console.WriteLine("VALOR DEPOSITADO COM SUCESSO!");
            Thread.Sleep(3000);
            Console.Clear();
            var backcaixa = new SYScaixa();
            backcaixa.Syscaixa();
        }
    }
}