using ByteBankIO;

partial class Program
{
    static void Main(string[] args)
    {
        string fileType = "";
        Console.WriteLine("INSIRA TIPO DE ARQUIVO:");
        Console.WriteLine("1 - CSV:");
        Console.WriteLine("2 - TXT:");

        var file = int.Parse(Console.ReadLine()!);
        if(file == 1)
        {
            fileType = "csv";
        }else if(file == 2)
        {
            fileType = "txt";
        }
        

        var filePath = CreateWithStreamWriter(fileType);

        

        FileProcess.DoWork(1,fileType,filePath);
    }

}