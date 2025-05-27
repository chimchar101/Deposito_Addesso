using System;

public sealed class Logger
{
    private static Logger _istanza;

    private Logger()
    {

    }

    public static Logger GetIstance()
    {
        if (_istanza == null)
        {
            _istanza = new Logger();
        }

        return _istanza;
    }

    public void ScriviMessaggio(string messaggio)
    {
        Console.WriteLine($"[{DateTime.Now}] {messaggio}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Logger log1 = Logger.GetIstance();
        Logger log2 = Logger.GetIstance();

        log1.ScriviMessaggio("Questo è il primo messaggio.");
        log2.ScriviMessaggio("Questo è il secondo messaggio.");

        Console.WriteLine($"log1 e log2 sono istanze uguali? {log1 == log2}");
    }
}