public class Veicolo
{
    public string Targa
    {
        get;
        set;
    }

    public virtual string Ripara()
    {
        return $"Il veicolo viene controllato.";
    }
}

public class Auto : Veicolo
{
    public Auto(string targa)
    {
        Targa = targa;
    }

    public override string Ripara()
    {
        return $"Controllo olio, freni e motore dell'auto con targa \"{Targa}\".";
    }
}

public class Moto : Veicolo
{
    public Moto(string targa)
    {
        Targa = targa;
    }
    
    public override string Ripara()
    {
        return $"Controllo catena, freni e gomme della moto con targa \"{Targa}\".";
    }
}

public class Camion : Veicolo
{
    public Camion(string targa)
    {
        Targa = targa;
    }
    
    public override string Ripara()
    {
        return $"Controllo sospensioni, freni rinforzati e carico del camion con targa \"{Targa}\".";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;
        int scelta, budget = 0;
        List<Veicolo> veicoli = new List<Veicolo>();

        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Aggiungi Auto\n[2] Aggiungi Moto\n[3] Aggiungi Camion\n[4] Effettua un controllo su tutti i veicoli\n[0] Esci");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    AggiungiAuto(veicoli);
                    break;
                case 2:
                    AggiungiMoto(veicoli);
                    break;
                case 3:
                    AggiungiCamion(veicoli);
                    break;
                case 4:
                    RiparaVeicoli(veicoli, budget);
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

    private static void AggiungiAuto(List<Veicolo> veicoli)
    {
        Console.WriteLine("Inserisci la targa dell'auto:");
        string targa = Console.ReadLine();

        Auto auto = new Auto(targa);
        veicoli.Add(auto);

        Console.WriteLine("Auto inserita!");
    }

    private static void AggiungiMoto(List<Veicolo> veicoli)
    {
        Console.WriteLine("Inserisci la targa della moto:");
        string targa = Console.ReadLine();

        Moto moto = new Moto(targa);
        veicoli.Add(moto);

        Console.WriteLine("Moto inserita!");
    }

    private static void AggiungiCamion(List<Veicolo> veicoli)
    {
        Console.WriteLine("Inserisci la targa del camion:");
        string targa = Console.ReadLine();

        Camion camion = new Camion(targa);
        veicoli.Add(camion);

        Console.WriteLine("Camion inserito!");
    }

    private static void RiparaVeicoli(List<Veicolo> veicoli, int budget)
    {
        int contaRiparazioni = 0;

        for (int i = 0; i < veicoli.Count; i++)
        {
            Console.WriteLine($"Veicolo {i + 1} | Targa: {veicoli[i].Targa}");
        }

        Console.WriteLine("Su quale veicolo vuoi andare a fare riparazioni? (Inserisci numero del veicolo)");
        int v = int.Parse(Console.ReadLine());

        Console.WriteLine("Quante riparazioni puoi fare? (Da 0 a 3)");
        int r = int.Parse(Console.ReadLine());

        if (r == 0)
        {
            Console.WriteLine("Non puoi effettuare riparazioni.");
        }

        else if (r >= 1 && r <= 3)
        {
            for (int i = 0; i < r; i++)
            {
                Console.WriteLine($"Riparazione {i + 1} su {r} | {veicoli[v - 1].Ripara()}");
            }

            Console.WriteLine("Riparazioni effettuate con successo!");
        }
    }
}