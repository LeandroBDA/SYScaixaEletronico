namespace CaixaEletronico;

public class User
{
    public string Username { get;  set; }
    public string Password { get; set; }
    public decimal Saldo { get; set; }

    public string DataNascimento { get; set; }

    public User(string username, string password, string dataNascimento)
    {
        Username = username;
        Password = password;
        DataNascimento = dataNascimento;
    }

    public decimal Depositar(decimal deposito, User user)
    {
        user.Saldo = user.Saldo + deposito;
        return user.Saldo;
    }

    public decimal Sacar(decimal valorRetirado, User user)
    {
        user.Saldo = user.Saldo - valorRetirado;
        return user.Saldo;
    }
}
