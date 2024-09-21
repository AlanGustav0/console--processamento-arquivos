using System.Diagnostics;
using System.Text;

namespace ByteBankIO
{
    public class FileProcess
    {
        public static void DoWork(string filePath, int process)
        {
            var sw = new Stopwatch();
            sw.Start();

            switch (process)
            {
                case 1:
                    ExecuteWithStreamReader(filePath);
                    break;
                case 2:
                    ExecuteWithFileStream(filePath);
                    break;
                default:
                    ExecuteWithStreamReader(filePath);
                    break;
            }

            

            sw.Stop();
            Console.WriteLine($"\nMemória utilizada: {Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} mb");
            Console.WriteLine($"Tempo de processamento: {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }

        private static void ExecuteWithStreamReader(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var reader = new StreamReader(fileStream);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var account = ContaCorrente.ConvertStringToAccount(line!);

                    var sucessMessage = $"Titular: {account.Titular.Nome}\nAccount: {account.Numero} | Agency: {account.Agencia} | Balance: {account.Saldo}\n";

                    Console.WriteLine(sucessMessage);
                }

            };
        }

        private static void ExecuteWithFileStream(string filePath)
        {
            var currentBytes = -1;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var buffer = new byte[1024]; // 1KB
           
            
            while (currentBytes != 0)
            {
                currentBytes = fileStream.Read(buffer, 0, 1024);
                WriteBuffer(buffer, currentBytes);
            }
            
        }

        private static void WriteBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding();

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);
        }
    }
}
