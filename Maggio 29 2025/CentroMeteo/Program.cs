using System;

public interface IObserver
{
    void Aggiorna(string messaggio);
}

public interface ISoggetto
{
    void Registra(IObserver osservatore);
    void Rimuovi(IObserver osservatore);
    void Notifica(string messaggio);
}

public class CentroMeteo : ISoggetto
{
    private readonly List<IObserver> _osservatori = new List<IObserver>();

    public void Registra(IObserver osservatore)
    {
        _osservatori.Add(osservatore);
    }

    public void Rimuovi(IObserver osservatore)
    {
        _osservatori.Remove(osservatore);
    }

    public void Notifica(string messaggio)
    {
        foreach (var osservatore in _osservatori)
        {
            osservatore.Aggiorna(messaggio);
        }
    }

    public void AggiornaMeteo(string dati)
    {
        Console.WriteLine($"Aggiornamento meteo: {dati}");
        Notifica(dati);
    }
}

public class DisplayConsole : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"CONSOLE | Meteo aggiornato: {messaggio}");
    }
}

public class DisplayMobile : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"MOBILE | Meteo aggiornato: {messaggio}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CentroMeteo centro = new CentroMeteo();
        IObserver console = new DisplayConsole();
        IObserver mobile = new DisplayMobile();
        bool esci = false;

        centro.Registra(console);
        centro.Registra(mobile);

        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Aggiorna il meteo\n[0] Esci");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il meteo:");
                    string dati = Console.ReadLine();
                    centro.AggiornaMeteo(dati);
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