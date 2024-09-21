using System;
using System.Collections.Generic;
using System.Globalization;
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

            //Quebra de linha utilizando Split
            //var paths = line.Split(" ");

            //var agency = int.Parse(paths[0]);
            //var number = int.Parse(paths[1]);
            //var balance = double.Parse(paths[2].Replace(".",","));
            //var holderName = paths[3];

            //Quebra de linha utilizando Span
            var span = line.AsSpan(line.IndexOf(line.First()));

            var firstPosition = span.IndexOf(' ');

            //get agency with span
            var agency = int.Parse(span.Slice(0, firstPosition));

            //get number with span
            span = span.Slice(firstPosition + 1);
            firstPosition = span.IndexOf(' ');
            var number = int.Parse(span.Slice(0, firstPosition), provider: CultureInfo.InvariantCulture);

            //get balance with span
            span = span.Slice(firstPosition + 1);
            firstPosition = span.IndexOf(' ');
            var balance = double.Parse(span.Slice(0, firstPosition).ToString().Replace(".", ","), provider: CultureInfo.InvariantCulture);

            //get holderName with span
            span = span.Slice(firstPosition + 1);
            firstPosition = span.IndexOf(' ');
            var holderName = span.Slice(0).ToString();

            var holder = new Cliente();

            holder.Nome = holderName;

            var conta = new ContaCorrente(agency, number);
            conta.Depositar(balance);
            conta.Titular = holder;

            return conta;
        }
    }
}
