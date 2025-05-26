using System;

public abstract class DispositivoElettronico
{
    public string Modello { get; set; }

    public abstract void Accendi();
    public abstract void Spegni();
    public virtual void MostraInfo()
    {
        Console.WriteLine($"Modello {GetType().Name}: {Modello}");
    }
}

public class Computer : DispositivoElettronico
{
    public Computer(string modello)
    {
        Modello = modello;
    }

    public override void Accendi()
    {
        Console.WriteLine($"Il computer {Modello} si avvia...");
    }

    public override void Spegni()
    {
        Console.WriteLine($"Il computer {Modello} si spegne.");
    }
}

public class Stampante : DispositivoElettronico
{
    public Stampante(string modello)
    {
        Modello = modello;
    }

    public override void Accendi()
    {
        Console.WriteLine($"La stampante {Modello} si avvia...");
    }

    public override void Spegni()
    {
        Console.WriteLine($"La stampante {Modello} va in standby.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;
        int scelta;
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>();

        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Aggiungi computer\n[2] Aggiungi stampante\n[3] Stampa modello dispositivi");
            Console.WriteLine("[4] Accendi i dispositivi\n[5] Spegni i dispositivi\n[0] Esci");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    AggiungiComputer(dispositivi);
                    break;
                case 2:
                    AggiungiStampante(dispositivi);
                    break;
                case 3:
                    StampaModello(dispositivi);
                    break;
                case 4:
                    AccendiDispositivi(dispositivi);
                    break;
                case 5:
                    SpegniDispositivi(dispositivi);
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

    private static void AggiungiComputer(List<DispositivoElettronico> dispositivi)
    {
        Console.WriteLine("Inserisci il modello del computer:");
        string modello = Console.ReadLine();

        Computer computer = new Computer(modello);
        dispositivi.Add(computer);
    }

    private static void AggiungiStampante(List<DispositivoElettronico> dispositivi)
    {
        Console.WriteLine("Inserisci il modello della stampante:");
        string modello = Console.ReadLine();

        Stampante stampante = new Stampante(modello);
        dispositivi.Add(stampante);
    }

    private static void StampaModello(List<DispositivoElettronico> dispositivi)
    {
        foreach (DispositivoElettronico disp in dispositivi)
        {
            disp.MostraInfo();
        }
    }

    private static void AccendiDispositivi(List<DispositivoElettronico> dispositivi)
    {
        foreach (DispositivoElettronico disp in dispositivi)
        {
            disp.Accendi();
        }
    }

    private static void SpegniDispositivi(List<DispositivoElettronico> dispositivi)
    {
        foreach (DispositivoElettronico disp in dispositivi)
        {
            disp.Spegni();
        }
    }
}