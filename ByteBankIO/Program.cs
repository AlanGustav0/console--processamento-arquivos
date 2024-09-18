using ByteBankIO;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        var numeroDeBytesLidos = -1;
        var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open, FileAccess.Read);

        var buffer = new byte[1024]; // 1KB

        while (numeroDeBytesLidos != 0)
        {
            numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
            EscreverBuffer(buffer, numeroDeBytesLidos);
        }

        Console.WriteLine($"\nMemória utilizada: {Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} mb");
        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer, 0, bytesLidos);
        Console.Write(texto);
    }
}