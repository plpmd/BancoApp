using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class Conta
    {
        public double Saldo { get; private set; }
        public string NumeroConta { get; private set; }
        public string NomeTitular { get; set; }

        public string SenhaConta { get; private set; }

        
        
        public Conta(string numeroConta, string nome, double saldo, string senhaConta)
        {
            NumeroConta = numeroConta;
            NomeTitular = nome;
            Saldo = saldo;
            SenhaConta = senhaConta;
        }

        public override string ToString()
        {
            return "Conta: " + NumeroConta + ", Titular: " + NomeTitular + ", Saldo: $ " + Saldo.ToString("F2");
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
        }


        public void Saque(double valor)
        {
            Saldo -= valor + 5;
        }

        public bool ChecaSenhaValida(string senha)
        {
            bool senhasConferem = false;
            string senhaSalva = SenhaConta;
            
            if (senhaSalva == senha)
            {
                senhasConferem = true;
            }

            return senhasConferem;
            
        }
    }
}
