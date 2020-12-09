using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class SistemaBanco
    {
        public static bool Logado { get; set; }
        
        public static void Iniciar()
        {
            string[] dados = LeituraDados();

            Conta conta = CriarConta(dados);

            RetornaDadosIniciais(conta);

            Logado = true;

            ExibeMenuEnquantoLogado(conta);

        }

        private static void ExibeMenuEnquantoLogado(Conta conta)
        {
            

            while (Logado)
            {
                int opcao = MenuDeOpcoes();
                switch (opcao)
                {
                    case 1:
                        Saque(conta);
                        break;
                    case 2:
                        Deposito(conta);
                        break;
                    case 3:
                        Console.WriteLine("Obrigado, volte sempre");
                        Console.Read();
                        Logado = false;
                        break;
                }
            }
        }

        private static void PerguntaDesejaContinuar()
        {
            Console.WriteLine("");
            Console.WriteLine("Deseja continuar logado (S/N)?");
            string escolha = Console.ReadLine();
            if (escolha.ToLower() == "n")
            {
                Logado = false;
                Console.WriteLine("Obrigado, volte sempre");
            }
        }

        private static int MenuDeOpcoes()
        {
            
            Console.WriteLine("");
            Console.WriteLine("Sacar [1]");
            Console.WriteLine("Depositar [2]");
            Console.WriteLine("Sair [3]");
            Console.WriteLine("");
            Console.WriteLine("Digite o número referente a sua opção:");
            Console.WriteLine("");
            return int.Parse(Console.ReadLine());
        }

        private static string[] LeituraDados()
        {
            Console.WriteLine("Digite o número da conta: ");
            string conta = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Digite o nome do titular: ");
            string nome = Console.ReadLine();

            Console.WriteLine("");
            string senha = RecebeSenha();

            Console.WriteLine("");
            Console.WriteLine("Haverá depósito inicial (S/N)? ");
            string escolhaDepositoInicial = Console.ReadLine();

            Console.WriteLine("");

            string deposito = "0.00";

            if (escolhaDepositoInicial.ToLower() == "s")
            {
                Console.WriteLine("Digite o valor do depósito inicial: ");
                deposito = Console.ReadLine();
            }

            string[] dados = new string[4] { conta, nome, deposito, senha };
            return dados;
        }

        private static string RecebeSenha()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite a senha para a conta (6 números): ");
            string senha1 = Console.ReadLine();

            while (senha1.Length != 6)
            {
                Console.WriteLine("");
                Console.WriteLine("A senha deve ter 6 dígitos!");
                Console.WriteLine("");
                Console.WriteLine("Digite a senha para a conta (6 números): ");
                senha1 = Console.ReadLine();
                //123456 *******
            }

            Console.WriteLine("");
            Console.WriteLine("Repita a senha:  ");
            string senha2 = Console.ReadLine();

            if (senha1 != senha2)
            {
                Console.WriteLine("Senhas não conferem. Tente novamente.");
                RecebeSenha();
            }

            return senha2;
        }

        private static Conta CriarConta(string[] dados)
        {
            string conta = dados[0];
            string nome = dados[1];
            double deposito = double.Parse(dados[2], CultureInfo.InvariantCulture);
            string senha = dados[3];
            Conta contaBancaria = new Conta(conta, nome, deposito, senha);
            return contaBancaria;

        }

        public static void RetornaDadosIniciais(Conta contaBancaria)
        {
            Console.WriteLine("");
            Console.WriteLine("Dados da conta: ");
            Console.WriteLine("");
            Console.WriteLine(contaBancaria.ToString());
        }

        public static void Deposito(Conta contaBancaria)
        {
            Console.WriteLine("");
            Console.WriteLine("Entre um valor para o depósito: ");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("");
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if (contaBancaria.ChecaSenhaValida(senha))
            {
                contaBancaria.Deposito(valor);
                Console.WriteLine("");
                Console.WriteLine("Dados da conta atualizados: ");
                Console.WriteLine(contaBancaria.ToString());
            }
            else
            {
                Console.WriteLine("Senha incorreta.");
                PerguntaDesejaContinuar();
            }

        }

        public static void Saque(Conta contaBancaria)
        {
            Console.WriteLine("");
            Console.WriteLine("Entre um valor para saque:");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("");
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            if (contaBancaria.ChecaSenhaValida(senha))
            {
                contaBancaria.Saque(valor);
                Console.WriteLine("");
                Console.WriteLine("Dados da conta atualizados: ");
                Console.WriteLine(contaBancaria.ToString());
            }
            else
            {
                Console.WriteLine("Senha incorreta.");
                PerguntaDesejaContinuar();
            }
            
        }
    }
}
