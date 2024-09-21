using ByteBankIO;

class Program
{
    static void Main(string[] args)
    {
        var filePath = "contas.txt";

        FileProcess.DoWork(filePath,1);
    }

}