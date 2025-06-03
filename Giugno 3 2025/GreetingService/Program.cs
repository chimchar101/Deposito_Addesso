public interface IGreeter
{
    void Greet(string nome);
}

public class ConsoleGreeter : IGreeter
{
    public void Greet(string nome)
    {
        Console.WriteLine($"Benvenuto, {nome}!");
    }
}

public class GreetingService
{
    private readonly IGreeter _greeter;

    public GreetingService(IGreeter greeter)
    {
        _greeter = greeter;
    }

    public void GreetUser(string nome)
    {
        _greeter.Greet(nome);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IGreeter greeter = new ConsoleGreeter();
        GreetingService greetingService = new GreetingService(greeter);

        Console.WriteLine("Inserisci il tuo nome:");
        string nome = Console.ReadLine();
        greetingService.GreetUser(nome);
    }
}