public class Operatore
{
    private string _nome, _turno;

    public string Nome
    {
        get;
        set;
    }

    public string Turno
    {
        get
        {
            return _turno;
        }
        set
        {
            if (value.ToLower() == "giorno" || value.ToLower() == "notte")
            {
                _turno = value;
            }

            else
            {
                Console.WriteLine("Turno non valido.");
            }
        }
    }

    public virtual string Descrizione()
    {
        return $"Nome: {Nome} | Turno: {Turno}";
    }

    public virtual string EseguiCompito()
    {
        return "Operatore generico in servizio.";
    }
}

public class OperatoreEmergenza : Operatore
{
    private int _livelloUrgenza;
    public int LivelloUrgenza
    {
        get
        {
            return _livelloUrgenza;
        }

        set
        {
            if (value >= 1 && value <= 5)
            {
                _livelloUrgenza = value;
            }

            else
            {
                Console.WriteLine("Livello urgenza non valido.");
            }
        }
    }

    public OperatoreEmergenza(string nome, string turno, int livelloUrgenza)
    {
        Nome = nome;
        Turno = turno;
        LivelloUrgenza = livelloUrgenza;
    }

    public override string Descrizione()
    {
        return $"Operatore Emergenze | Nome: {Nome} | Turno: {Turno}";
    }

    public override string EseguiCompito()
    {
        return $"L'operatore {Nome} sta gestendo l'emergenza di livello {LivelloUrgenza}.";
    }
}

public class OperatoreSicurezza : Operatore
{
    public string AreaSorvegliata
    {
        get;
        set;
    }

    public OperatoreSicurezza(string nome, string turno, string areaSorvegliata)
    {
        Nome = nome;
        Turno = turno;
        AreaSorvegliata = areaSorvegliata;
    }

    public override string Descrizione()
    {
        return $"Operatore Sicurezza | Nome: {Nome} | Turno: {Turno}";
    }

    public override string EseguiCompito()
    {
        return $"L'operatore {Nome} sta sorvegliando {AreaSorvegliata}.";
    }
}

public class OperatoreLogistica : Operatore
{
    private int _numeroConsegne;
    public int NumeroConsegne
    {
        get
        {
            return _numeroConsegne;
        }

        set
        {
            if (value >= 0)
            {
                _numeroConsegne = value;
            }

            else
            {
                Console.WriteLine("Numero consegne non valido.");
            }
        }
    }

    public OperatoreLogistica(string nome, string turno, int numeroConsegne)
    {
        Nome = nome;
        Turno = turno;
        NumeroConsegne = numeroConsegne;
    }

    public override string Descrizione()
    {
        return $"Operatore Logistica | Nome: {Nome} | Turno: {Turno}";
    }

    public override string EseguiCompito()
    {
        return $"L'operatore {Nome} sta coordinando {NumeroConsegne} consegne.";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;
        int scelta;
        List<Operatore> operatori = new List<Operatore>();

        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Aggiungi Operatore Emergenze\n[2] Aggiungi Operatore Sicurezza\n[3] Aggiungi Operatore Logistico");
            Console.WriteLine("[4] Controlla tutti gli operatori\n[5] Fai eseguire i compiti agli operatori\n[0] Esci");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    AggiungiEmergenza(operatori);
                    break;
                case 2:
                    AggiungiSicurezza(operatori);
                    break;
                case 3:
                    AggiungiLogistica(operatori);
                    break;
                case 4:
                    StampaOperatori(operatori);
                    break;
                case 5:
                    Compito(operatori);
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

    private static void AggiungiEmergenza(List<Operatore> operatori)
    {
        Console.WriteLine("Inserisci il nome dell'operatore:");
        string nome = Console.ReadLine();
        Console.WriteLine("Che turno fa? (Giorno/Notte)");
        string turno = Console.ReadLine();
        Console.WriteLine("Livello dell'emergenza dell'operatore? (Da 1 a 5)");
        int livello = int.Parse(Console.ReadLine());

        OperatoreEmergenza operatore = new OperatoreEmergenza(nome, turno, livello);
        operatori.Add(operatore);

        Console.WriteLine("Operatore Emergenze inserito!");
    }

    private static void AggiungiSicurezza(List<Operatore> operatori)
    {
        Console.WriteLine("Inserisci il nome dell'operatore:");
        string nome = Console.ReadLine();
        Console.WriteLine("Che turno fa? (Giorno/Notte)");
        string turno = Console.ReadLine();
        Console.WriteLine("Dove sta sorvegliando?");
        string area = Console.ReadLine();

        OperatoreSicurezza operatore = new OperatoreSicurezza(nome, turno, area);
        operatori.Add(operatore);

        Console.WriteLine("Operatore Sicurezza inserito!");
    }

    private static void AggiungiLogistica(List<Operatore> operatori)
    {
        Console.WriteLine("Inserisci il nome dell'operatore:");
        string nome = Console.ReadLine();
        Console.WriteLine("Che turno fa? (Giorno/Notte)");
        string turno = Console.ReadLine();
        Console.WriteLine("Quante consegne sta coordinando?");
        int consegne = int.Parse(Console.ReadLine());

        OperatoreLogistica operatore = new OperatoreLogistica(nome, turno, consegne);
        operatori.Add(operatore);

        Console.WriteLine("Operatore Logistica inserito!");
    }

    private static void StampaOperatori(List<Operatore> operatori)
    {
        foreach (Operatore operatore in operatori)
        {
            Console.WriteLine(operatore.Descrizione());
        }
    }

    private static void Compito(List<Operatore> operatori)
    {
        foreach (Operatore operatore in operatori)
        {
            Console.WriteLine(operatore.EseguiCompito());
        }
    }
}
