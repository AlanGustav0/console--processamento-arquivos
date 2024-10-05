using System.Text;

partial class Program
{
    
    static void CreateFile()
    {
        //File path
        var filePath = "exportedAccounts.csv";

        //Open filestream with mode create
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            //Create line file
            var accounts = "456, 7895, 4785.40, Gustavo Santos";

            //define encoding UTF8
            var encoding = Encoding.UTF8;

            //Get btye array of line
            var bytes = encoding.GetBytes(accounts);

            //Write bytes of new file
            stream.Write(bytes, 0, bytes.Length);
        }
    }

    static string CreateWithStreamWriter(string fileType)
    {
        string accounts = "";

        Console.WriteLine("INICIO DA CRIAÇÃO DE CONTA");
        var filePath = $"exportedAccountsStream.{fileType}";

        Console.WriteLine("Insira o número da conta: ");
        var account = Console.ReadLine();

        Console.WriteLine("Insira o número da agência: ");
        var agency = Console.ReadLine();

        Console.WriteLine("Insira o valor do saldo: ");
        var ballance = Console.ReadLine();

        Console.WriteLine("Insira nome do titular: ");
        var holderName = Console.ReadLine();

        using (var stream = new FileStream(filePath, FileMode.Create))
        using(var writer = new StreamWriter(stream))
        {
            if(fileType.Equals("csv"))
            {
                accounts = $"{account}, {agency}, {ballance}, {holderName}";

            }else if(fileType.Equals("txt"))
            {
                accounts = $"{account} {agency} {ballance} {holderName}";
            }
            
            writer.Write(accounts);
        }

        if (File.Exists(filePath)) Console.WriteLine("CONTA CADASTRADA COM SUCESSO!");

        return filePath;
    }
}


