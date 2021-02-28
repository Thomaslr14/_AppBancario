using System;
using System.Collections.Generic;
using System.Globalization;

namespace AppBancario.Classes
{
    public class Functions
    {

        private static List<Account> listAccounts = new List<Account>();

        public static void CreateCount()
        {
            Account account = new Account();
            Console.Clear();
            Console.WriteLine("========== Criação de Conta ==========");
            Console.WriteLine();
            Console.WriteLine("Informe o tipo de conta:");
            Console.WriteLine("1 - Pessoa Fisica");
            Console.WriteLine("2 - Pessoa Juridica");
            Console.WriteLine("R - Voltar ao Menu anterior");
            Console.WriteLine("X - SAIR");
            var TypeCount = Console.ReadLine();
            try 
            {
                if (TypeCount == "")
                {
                    throw new System.FormatException();
                }
                else if (TypeCount.ToUpper() == "R")
                {
                    Console.Clear();
                    return;
                }
                else if (!Exit(TypeCount))
                {
                    Environment.Exit(0);
                }
                else 
                {
                    
                    switch(Convert.ToInt32(TypeCount))
                    {
                        case 1:
                        account.Type = Enum.AccountType.PF;

                        Console.WriteLine("\nInforme seu nome completo:");
                        account.name = Console.ReadLine();
                        Console.WriteLine("Informe seu CPF:");
                        account.cpf = Console.ReadLine();
                        break;

                        case 2:
                        account.Type = Enum.AccountType.PJ;

                        Console.WriteLine("\nInforme o nome da empresa:");
                        account.name = Console.ReadLine();
                        Console.WriteLine("Informe seu CNPJ:");
                        account.cpf = Console.ReadLine();
                        break;
                    }
                    listAccounts.Add(account);
                    Console.WriteLine($"\nCliente {account.name} cadastrado com sucesso!\n");
                }
            } 
            catch (System.FormatException)
            {
                Console.WriteLine("Informe uma opção valida!\n");
                return;
            }
            
        }
        
        public static void ShowCounts()
        {
            Console.Clear();
            Console.WriteLine("======================= Contas existentes =======================\n");
            int count = 0;
            foreach (var i in listAccounts)
            {
                Console.WriteLine($"CONTA: {count} | NOME DO TITULAR: {i.name} | TIPO DA CONTA: {Convert.ToString(i.Type)} \n");
                count++;
            }
        }
        
        public static void SetCash()
        {
            Console.Clear();
            Console.WriteLine("========== Depositar dinheiro ==========");
            Console.WriteLine();
            Console.WriteLine("R - Voltar ao Menu anterior");
            Console.WriteLine("X - SAIR");
            Console.WriteLine("Informe o numero da conta:");
            var TypeCount = Console.ReadLine();
            if (TypeCount.ToUpper() == "R")
            {
                Console.Clear();
                return;
            }
            else if (!Exit(TypeCount))
            {
                Environment.Exit(0);
            }
            else 
            {
                for (int index = 0; index < listAccounts.Count; index++) 
                {
                    if (int.Parse(TypeCount) == index)
                    {
                        Console.WriteLine("Informe o valor que deseja depositar:");
                        listAccounts[index].money += double.Parse(Console.ReadLine());
                        Console.WriteLine($"\nDeposito feito com sucesso!\n\nCONTA: {index} | TITULAR: {listAccounts[index].name} | SALDO: {listAccounts[index].money.ToString($"C", CultureInfo.CreateSpecificCulture("pt-BR"))}\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("==================================");
                        Console.WriteLine("\nNumero de conta inexistente!");
                        Console.WriteLine("!! OPERAÇÃO CANCELADA !!\n");
                        Console.WriteLine("==================================");
                    }
                }
            }
        }
        
        public static void GetCash()
        {
            Console.Clear();
            Console.WriteLine("============= Saque =============");
            Console.WriteLine();
            Console.WriteLine("R - Voltar ao Menu anterior");
            Console.WriteLine("X - SAIR");
            Console.WriteLine("Informe o numero da conta:");
            var TypeCount = Console.ReadLine();
            if (TypeCount.ToUpper() == "R")
            {
                Console.Clear();
                return;
            }
            else if (!Exit(TypeCount))
            {
                Environment.Exit(0);
            }
            else 
            {
                for (int index = 0; index < listAccounts.Count; index++) 
                {
                    if (int.Parse(TypeCount) == index)
                    {
                        Console.WriteLine("Informe o valor que deseja sacar:");
                        double cash = double.Parse(Console.ReadLine());
                        if (listAccounts[index].money >= cash)
                        {
                            listAccounts[index].money -= cash;

                            Console.WriteLine($"Saque realizado com sucesso!\n\nCONTA: {index} | TITULAR: {listAccounts[index].name} | SAQUE: {cash.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))} | NOVO SALDO: {listAccounts[index].money.ToString($"C", CultureInfo.CreateSpecificCulture("pt-BR"))}\n");
                        }
                        else 
                        {
                            Console.WriteLine("\nSaldo Insuficiente!");
                            Console.WriteLine("!! OPERAÇÃO CANCELADA !!\n");
                            return;
                        }                        
                    }
                    else
                    {
                        Console.WriteLine("==================================");
                        Console.WriteLine("\nNumero de conta inexistente!");
                        Console.WriteLine("!! OPERAÇÃO CANCELADA !!\n");
                        Console.WriteLine("==================================");
                    }
                }
            }
        }
        
        public static bool Exit(string param)
        {
            if (param.ToUpper() == "X")
            {
                Console.WriteLine("Obrigado por utilizar o DIO Bank!");
                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}