using System;

public interface IObserver
{
    void Update(string news);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string news);
}

public sealed class NewsAgency
{
    private static NewsAgency _instance;
    private readonly List<IObserver> _observers = new List<IObserver>();

    private NewsAgency() { }

    public static NewsAgency Instance
    {
        get
        {
            if (_instance == null)
                _instance = new NewsAgency();
            return _instance;
        }
    }

    public void Register(IObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Remove(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string news)
    {
        foreach (var observer in _observers)
        {
            observer.Update(news);
        }
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
        var mobile = new MobileApp();
        var email = new EmailClient();

        NewsAgency.Instance.Register(mobile);
        NewsAgency.Instance.PublishNews("Questa è una notizia per mobile!");

        NewsAgency.Instance.Remove(mobile);
        NewsAgency.Instance.Register(email);
        NewsAgency.Instance.PublishNews("Questa è una notizia per email!");
    }
}