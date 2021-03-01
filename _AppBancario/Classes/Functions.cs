using System;
using System.Collections.Generic;
using System.Globalization;

namespace AppBancario.Classes
{
    public class Functions
    {
        private static Functions functions = new Functions();
        
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
            functions.ReturnOptions(TypeCount);
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
        
        public static void ShowCounts()
        {
            Console.Clear();
            Console.WriteLine("======================= Contas existentes =======================\n");
            int count = 0;
            foreach (var i in listAccounts)
            {
                Console.WriteLine($"CONTA: {count} | NOME DO TITULAR: {i.name} | TIPO DA CONTA: {Convert.ToString(i.Type)} | CPF: {i.cpf} \n");
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
            functions.ReturnOptions(TypeCount);
            if (functions.ValidateCount(int.Parse(TypeCount)))
            {
                int b = int.Parse(TypeCount);
                Console.WriteLine("Informe o valor que deseja depositar:");
                listAccounts[b].money += double.Parse(Console.ReadLine());
                Console.WriteLine($"\nDeposito feito com sucesso!\n\nCONTA: {b} | TITULAR: {listAccounts[b].name} | SALDO: {listAccounts[b].money.ToString($"C", CultureInfo.CreateSpecificCulture("pt-BR"))}\n");
            } 
            else
            {   
                functions.OperationDenied();
            }
        }

        private void OperationDenied() 
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("Numero de conta inexistente!");
            Console.WriteLine("!! OPERAÇÃO CANCELADA !!");
            Console.WriteLine("==================================\n");
        }
        
        private void ReturnOptions(string param)
        {
            try
            {
                if (param == "")
                {
                    throw new System.FormatException();
                }

                else if (param.ToUpper() == "R")
                {
                    Console.Clear();
                    return;
                }
                else if (!Exit(param))
                {
                    Environment.Exit(0);
                }
            }
            catch (System.FormatException) 
            {
                Console.WriteLine("\nInforme uma opção valida!\n");
                return;
            }
        }
        
        private bool ValidateCount(int param)
        {
            int index = 0;
            while (index < listAccounts.Count) 
            {   
                if (index == param)
                {
                    return true;
                }
                else 
                {
                   index++;
                }
                
            }
            return false;
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
            functions.ReturnOptions(TypeCount);
            if (functions.ValidateCount(int.Parse(TypeCount))) 
            {
                int b = int.Parse(TypeCount);
                Console.WriteLine("Informe o valor que deseja sacar:");
                double cash = double.Parse(Console.ReadLine());
                if (listAccounts[b].money >= cash)
                {
                    listAccounts[b].money -= cash;

                    Console.WriteLine($"\nSaque realizado com sucesso!\n\nCONTA: {b} | TITULAR: {listAccounts[b].name} | SAQUE: {cash.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))} | NOVO SALDO: {listAccounts[b].money.ToString($"C", CultureInfo.CreateSpecificCulture("pt-BR"))}\n");
                    return;
                }
                else 
                {
                    Console.WriteLine("\nSaldo Insuficiente!");
                    Console.WriteLine("!! OPERAÇÃO CANCELADA !!\n");
                }      
            }
            else
            {
                functions.OperationDenied();
            }
        }  
        
        public static void TransferCash()
        {
            Console.Clear();
            Console.WriteLine("============== Transferência ==============");
            Console.WriteLine();
            Console.WriteLine("R - Voltar ao Menu anterior");
            Console.WriteLine("X - SAIR");
            Console.WriteLine("Informe o numero da sua conta:");
            var TypeCount = Console.ReadLine();
            functions.ReturnOptions(TypeCount);
            if (functions.ValidateCount(int.Parse(TypeCount)))
            {
                int source = int.Parse(TypeCount);
                Console.WriteLine("\nValor a ser transferido:");
                double transferCash = double.Parse(Console.ReadLine());
                
                if (listAccounts[source].money >= transferCash)
                {
                    Console.WriteLine("\nInforme a conta de destino:");
                    var DestinyCount = Console.ReadLine();
                    if (functions.ValidateCount(int.Parse(DestinyCount)))
                    {
                        int destiny = int.Parse(DestinyCount);
                        Console.WriteLine($"\nCONTA DE ORIGEM: {source} | TITULAR: {listAccounts[source].name} | CPF: {listAccounts[source].cpf}");
                        Console.WriteLine($"CONTA DE DESTINO: {destiny} | TITULAR: {listAccounts[destiny].name} | CPF: {listAccounts[destiny].cpf}");
                        Console.WriteLine($"Valor a ser tranferido: {transferCash.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");
                        Console.WriteLine("\n1 - CONFIRMA");
                        Console.WriteLine("X - ANULA");
                        var opt = Console.ReadLine();
                        try {
                            if (opt == "1")
                            {
                                listAccounts[source].money -= transferCash;
                                listAccounts[destiny].money += transferCash;
                                Console.WriteLine("\nTransferência realizada com sucesso!\n");
                            }
                            else if (opt.ToUpper() == "X")
                            {
                                Console.WriteLine("Transação cancelada!!");
                                return;
                            }
                            else 
                            {
                                throw new System.FormatException();
                            }
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("\nInforme uma opção valida!\n");
                            return;
                        }

                    }
                    else
                    {
                        functions.OperationDenied();
                    }
                }
                else
                {
                    Console.WriteLine("\nSaldo Insuficiente!");
                    Console.WriteLine("!! OPERAÇÃO CANCELADA !!\n");
                }
            }
            else
            {
                functions.OperationDenied();
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