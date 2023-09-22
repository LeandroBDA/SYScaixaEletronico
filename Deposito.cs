namespace CaixaEletronico;

public class Deposito
{
    public void deposito()
    {
        Console.WriteLine("VOCÊ ESCOLHEU A OPÇÃO DE DEPOSITO");
        // Console.WriteLine("QUANTO DESEJA DEPOSITAR?:");
        decimal.Parse(Console.ReadLine());
        int valor = int.Parse(Console.ReadLine());
     
        if (valor >= 0 && valor != null)
        {
            Console.WriteLine("VALOR VÁLIDO, DESEJA CONTINUAR?");
            Console.WriteLine("[1] - SIM");
            Console.WriteLine("[2] - NÃO");
            string option = Console.ReadLine();
        }
    }
}