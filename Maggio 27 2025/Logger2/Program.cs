using System;

public sealed class Logger
{
    private static Logger _istanza;
    private List<string> _vociLog;

    private Logger()
    {
        _vociLog = new List<string>();
    }

    public static Logger GetIstance()
    {
        if (_istanza == null)
        {
            _istanza = new Logger();
        }

        return _istanza;
    }

    public void Log(string messaggio)
    {
        _vociLog.Add(messaggio);
    }

    public void StampaLog()
    {
        foreach (string log in _vociLog)
        {
            Console.WriteLine(log);
        }

        Console.WriteLine("--------------------");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Logger log1 = Logger.GetIstance();
        Logger log2 = Logger.GetIstance();

        Console.WriteLine("Inserisci un messaggio per la prima istanza di Logger:");
        string message = Console.ReadLine();
        log1.Log(message);

        Console.WriteLine("Inserisci un messaggio per la seconda istanza di Logger:");
        message = Console.ReadLine();
        log2.Log(message);

        Console.WriteLine("Stampa dei Log attraverso la prima istanza");
        log1.StampaLog();

        Console.WriteLine("Stampa dei Log attraverso la seconda istanza");
        log2.StampaLog();

        Console.WriteLine("Le due istanze stampano gli stessi log.");
        Console.WriteLine($"Le due istanze sono uguali? {log1 == log2}");
    }
}