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

    static void CreateWithStreamWriter()
    {
        //File path
        var filePath = "exportedAccountsStream.csv";

        using (var stream = new FileStream(filePath, FileMode.Create))
        using(var writer = new StreamWriter(stream))
        {
            //Create line file
            var accounts = "457, 7795, 4585.40, Pedro Sampaio";
            writer.Write(accounts);
        }
    }
}


