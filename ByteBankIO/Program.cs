using ByteBankIO;

class Program
{
    static void Main(string[] args)
    {
        var filePath = "contas.txt";

        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            var reader = new StreamReader(fileStream);

            //var textFile = reader.ReadToEnd();

            //var number = reader.Read();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                Console.WriteLine(line);
            }

            
        };

        //FileProcess.DoWork(filePath);
    }

}