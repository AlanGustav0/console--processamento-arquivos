using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankIO
{
    public class ContaCorrente
    {
        public int Numero { get; }
        public int Agencia { get; }
        public double Saldo { get; private set; }
        public Cliente Titular { get; set; }

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de deposito deve ser maior que zero.", nameof(valor));
            }

            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de saque deve ser maior que zero.", nameof(valor));
            }

            if (valor > Saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }

            Saldo += valor;
        }

        public static ContaCorrente ConvertStringToAccount(string line)
        {
            var paths = line.Split(" ");

            var agency = int.Parse(paths[0]);
            var number = int.Parse(paths[1]);
            var balance = double.Parse(paths[2].Replace(".",","));
            var holderName = paths[3];

            var holder = new Cliente();

            holder.Nome = holderName;

            var conta = new ContaCorrente(agency, number);
            conta.Depositar(balance);
            conta.Titular = holder;

            return conta;
        }
    }
}
