using System.Text;

Console.WriteLine("How many lines of text file do you want to generate?");
string numberOfLinesRequested = Console.ReadLine();
if (!Int32.TryParse(numberOfLinesRequested, out int numberOfLines))
    return;

Console.WriteLine("Creating");
try
{
    using (FileStream fs = File.Create(Directory.GetCurrentDirectory() + "/testfile" + DateTime.Now.Ticks + ".txt"))
    {
        Random random = new Random();
        StringBuilder lineToWrite = new StringBuilder();
        for(int i = 0; i < numberOfLines; i++)
        {
            lineToWrite.Append(random.Next(100_000));
            lineToWrite.Append('.');
            lineToWrite.Append(' ');
            lineToWrite.Append(DateTime.Now.AddSeconds(i).ToString("f"));
            lineToWrite.Append('\n');
            byte[] line = new UTF8Encoding(true).GetBytes(lineToWrite.ToString());
            fs.Write(line, 0, line.Length);
            lineToWrite.Clear();
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
Console.WriteLine("Done");