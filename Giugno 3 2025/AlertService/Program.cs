public interface INotifier
{
    void Notify(string messaggio);
}

public class SmsNotifier : INotifier
{
    public void Notify(string messaggio)
    {
        Console.WriteLine($"Notifica SMS: {messaggio}");
    }
}

public class AlertService
{
    public void SendAlert(string messaggio, INotifier notifier)
    {
        notifier.Notify(messaggio);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SmsNotifier smsNotifier = new SmsNotifier();
        AlertService alertService = new AlertService();
        Console.WriteLine("Inserisci il messaggio:");
        string messaggio = Console.ReadLine();
        alertService.SendAlert(messaggio, smsNotifier);
    }
}