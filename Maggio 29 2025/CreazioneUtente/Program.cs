using System;

public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}

public interface ISubject
{
    void Registra(IObserver o);
    void Rimuovi(IObserver o);
    void Notifica(string nomeUtente);
}

public class GestoreCreazioneUtente : ISubject
{
    private readonly List<IObserver> _observer = new List<IObserver>();

    public void Registra(IObserver osservatore)
    {
        _observer.Add(osservatore);
    }

    public void Rimuovi(IObserver osservatore)
    {
        _observer.Remove(osservatore);
    }

    public void Notifica(string nome)
    {
        foreach (var obs in _observer)
        {
            obs.NotificaCreazione(nome);
        }
    }

    public void CreaUtente(string nome)
    {
        UserFactory.Crea(nome);
        Notifica(nome);
    }
}

public static class UserFactory
{
    public static Utente Crea(string nome)
    {
        return new Utente(nome);
    }
}

public class Utente
{
    private string _nome;

    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public Utente(string nome)
    {
        Nome = nome;
    }

    public override string ToString()
    {
        return $"Nome utente: {Nome}";
    }
}

public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"LOG | Creazione utente: {nomeUtente}");
    }
}

public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"MARKETING | Creazione utente: {nomeUtente}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GestoreCreazioneUtente gestore = new GestoreCreazioneUtente();
        gestore.Registra(new ModuloLog());
        gestore.Registra(new ModuloMarketing());
        bool esci = false;
        string news;

        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Crea un nuovo utente\n[2] Stampa lista utenti\n[0] Esci");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("Inserisci il nome dell'utente:");
                    string nomeUtente = Console.ReadLine();
                    gestore.CreaUtente(nomeUtente);
                    break;
                case "0":
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