using System;

public interface IBevanda
{
    string Descrizione();
    double Costo();
}

public class Caffe : IBevanda
{
    public string Descrizione()
    {
        return "Caffè";
    }

    public double Costo()
    {
        return 1.20;
    }
}

public class Te : IBevanda
{
    public string Descrizione()
    {
        return "Tè";
    }

    public double Costo()
    {
        return 2.50;
    }
}

public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda _bevanda;
    
    public DecoratoreBevanda(IBevanda bevanda)
    {
        _bevanda = bevanda;
    }

    public virtual string Descrizione()
    {
        return $"{_bevanda}";
    }

    public virtual double Costo()
    {
        return _bevanda.Costo();
    }
}

public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda)
        : base(bevanda) { }

    public override string Descrizione()
    {
        return $"{_bevanda.Descrizione()} con latte";
    }

    public override double Costo()
    {
        return _bevanda.Costo() + 0.25;
    }
}

public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda)
        : base(bevanda) { }

    public override string Descrizione()
    {
        return $"{_bevanda.Descrizione()} con cioccolato";
    }

    public override double Costo()
    {
        return _bevanda.Costo() + 1.00;
    }
}

public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda)
        : base(bevanda) { }

    public override string Descrizione()
    {
        return $"{_bevanda.Descrizione()} con panna";
    }

    public override double Costo()
    {
        return _bevanda.Costo() + 0.50;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;
        do
        {
            Console.WriteLine("Benvenuto. Che bevanda vuoi?");
            Console.WriteLine("[1] Caffè\n[2] Tè\n[0] Esci");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    CreaCaffe();
                    break;
                case "2":
                    CreaTe();
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

    private static void CreaCaffe()
    {
        IBevanda caffe = new Caffe();

        Console.WriteLine("Che aggiunta vuoi fare?");
        Console.WriteLine("[1] Latte\n[2] Cioccolato\n[3] Panna");
        string sceltaB = Console.ReadLine();

        switch (sceltaB)
        {
            case "1":
                DecoratoreBevanda latte = new ConLatte(caffe);
                Console.WriteLine($"Il tuo {latte.Descrizione()} verrà a costare {latte.Costo()} euro.");
                Console.WriteLine("-----------");
                break;
            case "2":
                DecoratoreBevanda cioccolato = new ConCioccolato(caffe);
                Console.WriteLine($"Il tuo {cioccolato.Descrizione()} verrà a costare {cioccolato.Costo()} euro.");
                Console.WriteLine("-----------");
                break;
            case "3":
                DecoratoreBevanda panna = new ConPanna(caffe);
                Console.WriteLine($"Il tuo {panna.Descrizione()} verrà a costare {panna.Costo()} euro.");
                Console.WriteLine("-----------");
                break;
            default:
                Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                break;
        }
    }

    private static void CreaTe()
    {
        IBevanda te = new Te();

        Console.WriteLine("Che aggiunta vuoi fare?");
        Console.WriteLine("[1] Latte\n[2] Cioccolato\n[3] Panna");
        string sceltaB = Console.ReadLine();

        switch (sceltaB)
        {
            case "1":
                DecoratoreBevanda latte = new ConLatte(te);
                Console.WriteLine($"Il tuo {latte.Descrizione()} verrà a costare {latte.Costo()} euro.");
                Console.WriteLine("-----------");
                break;
            case "2":
                DecoratoreBevanda cioccolato = new ConCioccolato(te);
                Console.WriteLine($"Il tuo {cioccolato.Descrizione()} verrà a costare {cioccolato.Costo()} euro.");
                Console.WriteLine("-----------");
                break;
            case "3":
                DecoratoreBevanda panna = new ConPanna(te);
                Console.WriteLine($"Il tuo {panna.Descrizione()} verrà a costare {panna.Costo()} euro.");
                Console.WriteLine("-----------");
                break;
            default:
                Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                break;
        }
    }
}