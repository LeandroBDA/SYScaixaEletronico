using System;

namespace CaixaEletronico
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            var users = new List<User>();
            
            Console.WriteLine("SEJA BEM-VINDO!");
            Thread.Sleep(3000);
            Console.Clear();
            myMenu(users);
        }
        public static void myMenu(List<User> users)
        {
            Console.WriteLine("=CAIXA ELETRÔNICO!=");
            Console.WriteLine("[1] - ACESSAR CAIXA");
            Console.WriteLine("[2] - CADASTRAR NOVO USUÁRIO");
            Console.WriteLine("[3] - SAIR");
            string option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1" : 
                    if (users.Count != 0)
                    {
                        login(users); break; 
                    }
                    else
                    {
                        Console.WriteLine("NENHUM USUÁRIO ENCONTRADO, POR FAVOR CADASTRE-SE!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        myMenu(users); break;
                    }
            
                case "2" : Cadastro(users); Console.Clear(); break;
            
                case "3" : Console.WriteLine("OK, OBRIGADO POR USAR O SYS");
                    Thread.Sleep(3000); 
                    Console.Clear();
                    myMenu(users); break;
            }
        } 
        public static void login(List<User> users)
        {
            Console.WriteLine("===LOGIN===");
            Console.Write("USUÁRIO:");
            string username = Console.ReadLine();
            Console.Write("SENHA:");
            string password = Console.ReadLine();
            Console.Clear();

            var user = users.Find(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                Console.WriteLine("USUÁRIO NÃO ENCONTRADO, POR FAVOR TENTE NOVAMENTE!");
                Thread.Sleep(3000);
                Console.Clear();
                login(users);
            }
            
            Syscaixa(user);
        } 
        public static void Cadastro(List<User> users)
        {
            Console.WriteLine("BEM-VINDO AO CADASTRO, PARA CONTINUAR INFORME OS DADOS ABAIXO");
            Console.Write("NOME COMPLETO: ");
            string usarname = Console.ReadLine();
            Console.Write("DATA DE NASCIMENTO: ");
            string dataNascimento = Console.ReadLine();
            Console.Write("SENHA:");
            string password = Console.ReadLine();
            Console.Clear();

            var NewUser = new User(usarname, password, dataNascimento);

            var userExiste = users.Find(x => x.Username == usarname);
            
            if (userExiste != null)
            {
                Console.WriteLine("USUÁRIO JÁ CADASTRADO."); 
                Thread.Sleep(3000); 
                Console.Clear();
                Cadastro(users);
            }
            
            users.Add(NewUser);
            Console.WriteLine("USUÁRIO CADASTRADO COM SUCESSO!");
            Thread.Sleep(3000);
            Console.Clear();
            myMenu(users);
        } 
        public static void Syscaixa(User user)
        {
            Console.WriteLine("[1]- DEPOSITAR");
            Console.WriteLine("[2]- SACAR");
            Console.WriteLine("[3]- CONSULTAR SALDO");
            Console.WriteLine("[0]- VOLTAR PARA O MENU PRINCIPAL");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1" : Console.WriteLine("UM MOMENTO..."); 
                    Thread.Sleep(2000); 
                    Console.Clear(); 
                    Depositar(user); break;
                
                case "2" : Console.WriteLine("UM MOMENTO..."); 
                    Thread.Sleep(2000); 
                    Console.Clear(); 
                    Sacar(user); break;
                
                case "3" : Console.WriteLine("UM MOMENTO..."); 
                    Thread.Sleep(2000); 
                    Console.Clear(); Consultar(user); break;
                
                case "0" : Console.WriteLine("UM MOMENTO...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    myMenu(new List<User>()); break;
            }
        }
        public static void Depositar(User user)
        {
            Console.WriteLine("QUANTO VOCÊ DESEJA DEPOSITAR?");
            decimal valor = decimal.Parse(Console.ReadLine());

            if (valor < 0)
            {
                Console.WriteLine("O VALOR INSERIDO NÃO PODE SER ZERO. TENTE NOVAMENTE!");
                Thread.Sleep(2000); Console.Clear();
                Depositar(user);
            }

            else
            {
                user.Depositar(valor, user);
                Console.WriteLine("VALOR DEPOSITADO COM SUCESSO");
                Thread.Sleep(2000); Console.Clear();
                Console.WriteLine($"SEU SALDO ATUAL É DE: {user.Saldo} ");
                Thread.Sleep(2000);
                Console.Clear(); Syscaixa(user);
            }

        }
        public static void Sacar(User user)
        {
            Console.WriteLine("QUANTO DESEJA SACAR?");
            decimal valor = decimal.Parse(Console.ReadLine());
            Thread.Sleep(2000);
            Console.Clear();

            if (valor == null)
            {
                Console.WriteLine("O VALOR INSERIDO NÃO PODE SER ZERO. POR FAVOR TENTE NOVAMENTE!");
                Thread.Sleep(2000); Console.Clear();
                Syscaixa(user);
            }
            else if (valor > user.Saldo || valor <= 0)
            {
                Console.WriteLine("SALDO INSUFICIENTE");
                Thread.Sleep(3000);
                Console.Clear();
                Syscaixa(user); 
            }

            {
                user.Sacar(valor, user);
                Console.WriteLine("VALOR RETIRADO COM SUCESSO");
                Thread.Sleep(2000); Console.Clear();
                Console.WriteLine($"SEU SALDO ATUAL É DE: {user.Saldo} ");
                Thread.Sleep(3000); Console.Clear(); Syscaixa(user);
            }
        }

        public static void Consultar (User user)
        {
            Console.WriteLine($"SEU SALDO ATUAL É DE {user.Saldo} ");
            Thread.Sleep(5000); 
            Console.Clear(); Syscaixa(user);
        }
    }
}