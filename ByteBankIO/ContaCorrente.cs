using System.Globalization;

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

        public static ContaCorrente ConvertStringToAccount(string line, string type)
        {

            //Quebra de linha utilizando Split
            //var paths = line.Split(" ");

            //var agency = int.Parse(paths[0]);
            //var number = int.Parse(paths[1]);
            //var balance = double.Parse(paths[2].Replace(".",","));
            //var holderName = paths[3];

            //Quebra de linha utilizando Span
            char index = ',';

            if(type.Equals("txt"))
            {
                Console.WriteLine("TIPO DE ARQUIVO DEFINIDO: TXT");
                index = ' ';
            }
            else if(type.Equals("csv"))
            {
                Console.WriteLine("TIPO DE ARQUIVO DEFINIDO: CSV");
            }


            var span = line.AsSpan(line.IndexOf(line.First()));

            var firstPosition = span.IndexOf(index);

            //get agency with span
            var agency = int.Parse(span.Slice(0, firstPosition));

            //get number with span
            span = span.Slice(firstPosition + 1);
            firstPosition = span.IndexOf(index);
            var number = int.Parse(span.Slice(0, firstPosition), provider: CultureInfo.InvariantCulture);

            //get balance with span
            span = span.Slice(firstPosition + 1);
            firstPosition = span.IndexOf(index);
            var balance = double.Parse(span.Slice(0, firstPosition).ToString().Replace(".", ","), provider: CultureInfo.InvariantCulture);

            //get holderName with span
            span = span.Slice(firstPosition + 1);
            firstPosition = span.IndexOf(index);
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
