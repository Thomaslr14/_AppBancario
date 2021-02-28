using System;
using AppBancario.Classes;


namespace AppBancario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var option = Menu();

            while (Functions.Exit(option)) 
            {
                try {
                    switch(int.Parse(option))
                    {
                    
                        case 1:
                        Functions.CreateCount();
                        break;

                        case 2:
                        Functions.GetCash();
                        break;


                        case 3:
                        Functions.SetCash();
                        break;


                        case 4:
                        break;

                        case 5:
                        Functions.ShowCounts();
                        break;

                        default:
                            throw new System.FormatException();
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Informe uma opção valida!\n");
                }

                option = Menu();
            }

            Environment.Exit(0);

        }
        static string Menu() 
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("Bem vindo ao DIO Bank\n");
            Console.WriteLine("Informe uma opção:");
            Console.WriteLine("1 - Criar uma conta");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Transferir");
            Console.WriteLine("5 - Exibir contas");
            Console.WriteLine("X - SAIR");
            Console.WriteLine("===================================================================");

            var option = Console.ReadLine();
            return option;
        }
            
    }
}
