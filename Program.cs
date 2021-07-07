using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {
        /* Como não estou usando BANCO DE DADOS, irei criar uma lista
           para armazenar as contas */
        static List<Conta> listContas = new List<Conta>();

        /* =======================*/
        static void Main(string[] args)
        {
            //Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Lucas Rafael");
            //Console.WriteLine(minhaConta.ToString());
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();

                        break;

                    case "2":
                        InserirConta();

                        break;

                    case "3":
                        TransferirConta();

                        break;

                    case "4":

                        SacarConta();

                        break;

                    case "5":
                        DepositarConta();
                        break;

                    case "C":
                        //função nativa de limpar o console
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");

            /*=========== */
            Console.WriteLine("Pressione ENTER para sair...");
            Console.Read();
            /*FIM DO MAIN*/
        }


        //Método de Obter opção de usuário
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO BANK a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C - Limpar tela!!!");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }

        //Método listar contas
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas:");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {

                Conta conta = listContas[i];
                Console.WriteLine("{0}", i);
                Console.WriteLine(conta);
            }

        }


        //Método inserir conta
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome completo do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            /*Posso passar sem indicar o nome dos parametros lá do construtor, 
              como por exemplo: Conta(entradaSaldo, entradaNome) ao invés de
              Conta (saldo: entradaSaldo, nome: entradaNome); porém nesse caso
              tem que ser na ordem que for colocado lá no construtor.
            */
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);

        }


        //Método listar contas
        private static void TransferirConta()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }


        //Método listar contas
        private static void SacarConta()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);


        }


        //Método listar contas
        private static void DepositarConta()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor de depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);

        }
    }
}
