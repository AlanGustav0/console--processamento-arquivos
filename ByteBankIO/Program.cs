using ByteBankIO;

partial class Program
{
    static void Main(string[] args)
    {
        CreateFile();
        var filePath = "contas.txt";

        FileProcess.DoWork(filePath,1);
    }

}