using ByteBankIO;

partial class Program
{
    static void Main(string[] args)
    {

        var filePath = CreateWithStreamWriter();

        Console.WriteLine("INSIRA TIPO DE ARQUIVO:");
        Console.WriteLine("1 - CSV:");
        Console.WriteLine("2 - TEXT:");
        var fileType = int.Parse(Console.ReadLine()!);

        FileProcess.DoWork(1,fileType,filePath);
    }

}