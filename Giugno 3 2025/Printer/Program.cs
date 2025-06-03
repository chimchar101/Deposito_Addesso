public interface ILogger
{
    public void Log();
}

public class ConsoleLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine($"Log: Stampa effettuata con successo.");
    }
}

public class Printer
{
    public ILogger Logger { get; set; }

    public void Print()
    {
        if (Logger == null)
        {
            Console.WriteLine("Logger non è stato inizializzato.");
        }

        Logger.Log();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Printer printer = new Printer();
        printer.Logger = new ConsoleLogger();
        printer.Print();
    }
}