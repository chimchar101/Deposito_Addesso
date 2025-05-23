using System;

public class Soldato
{
    private string _nome, _grado;
    private int _anniServizio;

    public string Nome
    {
        get;
        set;
    }

    public string Grado
    {
        get;
        set;
    }

    public int AnniServizio
    {
        get
        {
            return _anniServizio;
        }
        set
        {
            if (value >= 0)
            {
                _anniServizio = value;
            }
        }
    }

    public virtual string Descrizione()
    {
        return $"Nome: {Nome} | Grado: {Grado} | Anni di servizio: {AnniServizio}";
    }
}

public class Fante : Soldato
{
    private string _arma;

    public string Arma
    {
        get;
        set;
    }

    public Fante(string nome, string grado, int anniServizio, string arma)
    {
        Nome = nome;
        Grado = grado;
        AnniServizio = anniServizio;
        Arma = arma;
    }

    public override string Descrizione()
    {
        return $"Fante | Nome: {Nome} | Grado: {Grado} | Anni di servizio: {AnniServizio} | Arma: {Arma}";
    }
}

public class Artigliere : Soldato
{
    private int _calibro;

    public int Calibro
    {
        get
        {
            return _calibro;
        }

        set
        {
            if (value > 0)
            {
                _calibro = value;
            }
        }
    }

    public Artigliere(string nome, string grado, int anniServizio, int calibro)
    {
        Nome = nome;
        Grado = grado;
        AnniServizio = anniServizio;
        Calibro = calibro;
    }

    public override string Descrizione()
    {
        return $"Artigliere | Nome: {Nome} | Grado: {Grado} | Anni di servizio: {AnniServizio} | Calibro: {Calibro}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;
        int scelta;
        List<Soldato> soldati = new List<Soldato>();

        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Aggiungi Fante\n[2] Aggiungi Artigliere\n[3] Visualizza tutti i soldati\n[4] Esci");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    AggiungiFante(soldati);
                    break;
                case 2:
                    AggiungiArtigliere(soldati);
                    break;
                case 3:
                    StampaSoldati(soldati);
                    break;
                case 4:
                    esci = true;
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                    break;
            }
        } while (!esci);
    }

    private static void AggiungiFante(List<Soldato> soldati)
    {
        Console.WriteLine("Inserisci il nome del Fante:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il grado del Fante:");
        string grado = Console.ReadLine();
        Console.WriteLine("Inserisci gli anni di servizio del Fante:");
        int anni = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci l'arma del Fante:");
        string arma = Console.ReadLine();

        Fante fante = new Fante(nome, grado, anni, arma);
        soldati.Add(fante);
        Console.WriteLine("Fante inserito!");
    }

    private static void AggiungiArtigliere(List<Soldato> soldati)
    {
        Console.WriteLine("Inserisci il nome dell'Artigliere:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il grado dell'Artigliere:");
        string grado = Console.ReadLine();
        Console.WriteLine("Inserisci gli anni di servizio dell'Artigliere:");
        int anni = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il calibro dell'Artigliere:");
        int calibro = int.Parse(Console.ReadLine());

        Artigliere artigliere = new Artigliere(nome, grado, anni, calibro);
        soldati.Add(artigliere);
        Console.WriteLine("Fante inserito!");
    }
    
    private static void StampaSoldati(List<Soldato> soldati)
    {
        foreach (Soldato soldato in soldati)
        {
            Console.WriteLine(soldato.Descrizione());
        }
    }
}