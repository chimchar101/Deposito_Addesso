using System;

public class PrenotazioneViaggio
{
    private int _postiPrenotati = 0;
    private const int maxPosti = 20;

    public string Destinazione
    {
        get;
        set;
    }
    public int PostiDisponibili
    {
        get
        {
            return maxPosti - _postiPrenotati;
        }
    }

    public void PrenotaPosti(int numero)
    {
        if (numero <= 0)
        {
            Console.WriteLine("Numero non valido.");
        }

        else if (numero <= PostiDisponibili)
        {
            _postiPrenotati += numero;
            Console.WriteLine($"{numero} posti prenotati.");
        }

        else
        {
            Console.WriteLine("Posti insufficienti disponibili.");
        }
    }

    public void AnnullaPrenotazione(int numero)
    {
        if (numero <= 0)
        {
            Console.WriteLine("Numero non valido.");
        }

        else if (numero <= _postiPrenotati)
        {
            _postiPrenotati -= numero;
            Console.WriteLine($"{numero} posti annullati.");
        }

        else
        {
            Console.WriteLine("Numero troppo alto.");
        }
    }

    public void StampaDettagli()
    {
        Console.WriteLine($"\nDestinazione: {Destinazione}");
        Console.WriteLine($"Posti prenotati: {_postiPrenotati}");
        Console.WriteLine($"Posti disponibili: {PostiDisponibili}\n");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        PrenotazioneViaggio viaggio = new PrenotazioneViaggio();

        Console.Write("Inserisci la destinazione del viaggio: ");
        viaggio.Destinazione = Console.ReadLine();
        viaggio.StampaDettagli();

        viaggio.PrenotaPosti(5);
        viaggio.StampaDettagli();

        viaggio.AnnullaPrenotazione(3);
        viaggio.StampaDettagli();

        viaggio.PrenotaPosti(8);
        viaggio.StampaDettagli();
        
        viaggio.AnnullaPrenotazione(4);
        viaggio.StampaDettagli();

        viaggio.PrenotaPosti(100);
        viaggio.AnnullaPrenotazione(50);
    }
}