namespace CaixaEletronico;

public class Sacar : Depositar
{
    public Sacar()
    {
        
    }
    
    public Sacar(double saldo) : base(saldo)
    {
    }
    public void SacarValor()
    {
        Console.WriteLine("INFORME O VALOR A SER SACADO: "); 
        double saque = double.Parse(Console.ReadLine());

        if (saque == 0 || saque < 0)
        {
            Console.WriteLine("O VALOR INSERIDO NÃO PODE SER NULO OU NEGATIVO! POR FAVOR TENTE NOVAMENTE"); 
            Thread.Sleep(3000); 
            Console.Clear();
            SacarValor();
        }
        else if (saque > Saldo)
        {
            Console.WriteLine("Saque impossível. Tente novamente.");
            SacarValor();
        }
        else
        { 
            Saldo -= saque;
            Console.WriteLine("Saque realizado!");
            Console.WriteLine($"Seu novo saldo é de {Saldo} reais!");
            var backSysCaixa = new SYScaixa();
            backSysCaixa.Syscaixa();
        }
    }
}