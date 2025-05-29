using System;

public interface IObserver
{
    void Update(string news);
}

public class NewsAgency
{
    private static NewsAgency _instance;
    private IObserver _subscriber;

    public static NewsAgency Instance
    {
        get
        {
            if (_instance == null)
                _instance = new NewsAgency();
            return _instance;
        }
    }

    public void Register(IObserver newSubscriber)
    {
        _subscriber = newSubscriber;
    }

    public void Notify(string news)
    {
        if (_subscriber != null)
            _subscriber.Update(news);
    }

    public void PublishNews(string news)
    {
        Console.WriteLine($"Notizia pubblicata: {news}");
        Notify(news);
    }
}

public class MobileApp : IObserver
{
    public void Update(string news)
    {
        Console.WriteLine("-----------");
        Console.WriteLine($"Notifica mobile: {news}");
        Console.WriteLine("-----------");
    }
}

public class EmailClient : IObserver
{
    public void Update(string news)
    {
        Console.WriteLine("-----------");
        Console.WriteLine($"Notifica email: {news}");
        Console.WriteLine("-----------");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var agency = NewsAgency.Instance;
        IObserver mobile = new MobileApp();
        IObserver email = new EmailClient();
        bool esci = false;
        string news;

        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Invia notizia con notifica mobile\n[2] Invia notizia per email\n[0] Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    agency.Register(mobile);
                    Console.WriteLine("Inserisci la notizia:");
                    news = Console.ReadLine();
                    agency.Notify(news);
                    break;
                case 2:
                    agency.Register(email);
                    Console.WriteLine("Inserisci la notizia:");
                    news = Console.ReadLine();
                    agency.Notify(news);
                    break;
                case 0:
                    esci = true;
                    Console.WriteLine("Arrivederci campione!");
                    break;
                default:
                    Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                    break;
            }
        } while (!esci);
    }
}