using System;

public interface ITorta
{
    string Descrizione();
}

public class TortaCioccolato : ITorta
{
    public string Descrizione()
    {
        return "Torta al cioccolato";
    }
}

public class TortaVaniglia : ITorta
{
    public string Descrizione()
    {
        return "Torta alla vaniglia";
    }
}

public class TortaFrutta : ITorta
{
    public string Descrizione()
    {
        return "Torta alla frutta";
    }
}

public abstract class DecoratoreTorta : ITorta
{
    protected ITorta _baseTorta;

    public DecoratoreTorta(ITorta baseTorta)
    {
        _baseTorta = baseTorta;
    }

    public abstract string Descrizione();
}

public class ConPanna : DecoratoreTorta
{
    public ConPanna(ITorta baseTorta)
        : base(baseTorta) { }

    public override string Descrizione()
    {
        return $"{_baseTorta.Descrizione()} + panna";
    }
}

public class ConFragole : DecoratoreTorta
{
    public ConFragole(ITorta baseTorta)
        : base(baseTorta) { }

    public override string Descrizione()
    {
        return $"{_baseTorta.Descrizione()} + fragole";
    }
}

public class ConGlassa : DecoratoreTorta
{
    public ConGlassa(ITorta baseTorta)
        : base(baseTorta) { }

    public override string Descrizione()
    {
        return $"{_baseTorta.Descrizione()} + glassa";
    }
}

public static class TortaFactory
{
    public static ITorta CreaTortaBase(string torta)
    {
        switch (torta)
        {
            case "1":
                return new TortaCioccolato();
            case "2":
                return new TortaVaniglia();
            case "3":
                return new TortaFrutta();
            case "0":
                Console.WriteLine("Arrivederci campione!");
                return null;
            default:
                Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                return null;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;

        Console.WriteLine("Benvenuto. Scegli il tipo di torta:");
        Console.WriteLine("[1] Cioccolato\n[2] Vaniglia\n[3] Frutta\n[0] Esci");
        string tortaBase = Console.ReadLine();

        ITorta torta = TortaFactory.CreaTortaBase(tortaBase);
        if (torta == null)
        {
            return;
        }

        do
        {
            Console.WriteLine("Che decorazioni vuoi aggiungere?");
            Console.WriteLine("[1] Panna\n[2] Fragole\n[3] Glassa\n[0] Nessun altro ingrediente");
            string decorazione = Console.ReadLine();

            switch (decorazione)
            {
                case "1":
                    torta = new ConPanna(torta);
                    break;
                case "2":
                    torta = new ConFragole(torta);
                    break;
                case "3":
                    torta = new ConGlassa(torta);
                    break;
                case "0":
                    esci = true;
                    break;
                default:
                    Console.WriteLine("Errore input.");
                    break;
            }
        } while (!esci);

        Console.WriteLine("\nLa tua torta completa è: ");
        Console.WriteLine(torta.Descrizione());
    }
}