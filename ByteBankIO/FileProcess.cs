using System.Diagnostics;
using System.Text;

namespace ByteBankIO
{
    public class FileProcess
    {
        public static void DoWork()
        {
            var filePath = "contas.txt";
            var currentBytes = -1;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var buffer = new byte[1024]; // 1KB
            var sw = new Stopwatch();

            sw.Start();
            while (currentBytes != 0)
            {
                currentBytes = fileStream.Read(buffer, 0, 1024);
                WriteBuffer(buffer, currentBytes);
            }
            sw.Stop();

            Console.WriteLine($"Memória utilizada: {Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} mb");
            Console.WriteLine($"Tempo de processamento: {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }

        private static void WriteBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding();

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);
        }
    }
}
