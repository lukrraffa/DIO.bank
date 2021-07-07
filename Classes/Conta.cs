using System;

namespace DIO.bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }


        /* --- MÉTODOS --- */

        //Método construtor
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {

            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;

        }

        //Método sacar
        public bool Sacar(double valorSaque)
        {

            //Validação de saldo insuficiente
            if ((this.Saldo - valorSaque) < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;


        }

        //Método depositar
        public void Depositar(double valorDeposito)
        {

            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        //Método transferir
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {

            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }

        }

        //Método ToString
        //Já existe ToString na classe mãe, então vou usar o OVERIDE para sobreescrever 
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo da Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito + " | ";
            return retorno;
        }


    }
}