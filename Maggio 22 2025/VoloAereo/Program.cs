using System;

public class PrenotazioneViaggio
{
    private int _postiOccupati = 0;
    private const int maxPosti = 150;

    public string CodiceVolo
    {
        get;
        set;
    }
    public int PostiOccupati
    {
        get
        {
            return _postiOccupati;
        }
    }

    public int PostiLiberi
    {
        get
        {
            return maxPosti - _postiOccupati;
        }
    }

    public override string ToString()
    {
        return $"Codice volo: {CodiceVolo} | Posti liberi: {PostiLiberi} | Posti occupati: {_postiOccupati}";
    }

    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= 0)
        {
            Console.WriteLine("Numero non valido.");
        }

        else if (numeroPosti <= PostiLiberi)
        {
            _postiOccupati += numeroPosti;
            Console.WriteLine($"{numeroPosti} posti prenotati.");
        }

        else
        {
            Console.WriteLine("Non ci sono abbastanza posti disponibili.");
        }
    }

    public void AnnullaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= 0)
        {
            Console.WriteLine("Numero non valido.");
        }

        else if (numeroPosti <= _postiOccupati)
        {
            _postiOccupati -= numeroPosti;
            Console.WriteLine($"{numeroPosti} posti annullati.");
        }

        else
        {
            Console.WriteLine("Non puoi annullare più posti di quanti ne siano disponibili.");
        }
    }

    public string VisualizzaStato()
    {
        return $"Codice volo: {CodiceVolo} | Posti liberi: {PostiLiberi} | Posti occupati: {_postiOccupati}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;
        int scelta;
        List<PrenotazioneViaggio> voloAereo = new List<PrenotazioneViaggio>();

        do
        {
            Console.WriteLine("Cosa vuoi fare?");
            Console.WriteLine("[1] Prenotare posti su un nuovo volo\n[2] Prenotare posti su un volo esistente\n[3] Cancellare prenotazione posti");
            Console.WriteLine("[4] Controllare stato voli\n[5] Uscire");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    PrenotaPostoNuovo(voloAereo);
                    break;
                case 2:
                    PrenotaPostoEsistente(voloAereo);
                    break;
                case 3:
                    CancellaPrenotazione(voloAereo);
                    break;
                case 4:
                    StampaVoli(voloAereo);
                    break;
                case 5:
                    esci = true;
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                    break;
            }
        } while (!esci);
    }

    private static void PrenotaPostoNuovo(List<PrenotazioneViaggio> voloAereo)
    {
        PrenotazioneViaggio volo = new PrenotazioneViaggio();
        Console.WriteLine("Inserisci il codice del volo:");
        volo.CodiceVolo = Console.ReadLine();
        Console.WriteLine($"Quanti posti vuoi prenotare? (Posti disponibili: {volo.PostiLiberi})");
        int prenotazione = int.Parse(Console.ReadLine());
        volo.EffettuaPrenotazione(prenotazione);
        voloAereo.Add(volo);
    }

    private static void PrenotaPostoEsistente(List<PrenotazioneViaggio> voloAereo)
    {
        for (int i = 0; i < voloAereo.Count; i++)
        {
            Console.WriteLine($"VOLO {i + 1} | {voloAereo[i].VisualizzaStato()}");
        }

        Console.WriteLine("Su quale volo vuoi prenotare posti? (Inserisci numero del volo)");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine($"Quanti posti vuoi prenotare? (Posti disponibili: {voloAereo[v - 1].PostiLiberi})");
        int prenotazione = int.Parse(Console.ReadLine());
        voloAereo[v - 1].EffettuaPrenotazione(prenotazione);
    }

    private static void CancellaPrenotazione(List<PrenotazioneViaggio> voloAereo)
    {
        for (int i = 0; i < voloAereo.Count; i++)
        {
            Console.WriteLine($"VOLO {i + 1} | {voloAereo[i].VisualizzaStato()}");
        }

        Console.WriteLine("Da quale volo vuoi cancellare la prenotazione? (Inserisci numero del volo)");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine($"Quanti posti vuoi cancellare? (Posti prenotati: {voloAereo[v - 1].PostiOccupati})");
        int cancella = int.Parse(Console.ReadLine());
        voloAereo[v - 1].AnnullaPrenotazione(cancella);
    }

    private static void StampaVoli(List<PrenotazioneViaggio> voloAereo)
    {
        foreach (PrenotazioneViaggio viaggio in voloAereo)
        {
            Console.WriteLine(viaggio.VisualizzaStato());
        }
    }
}
