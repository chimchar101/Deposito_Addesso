using System;

public interface IPizza
{
    string Descrizione();
}

public class Margherita : IPizza
{
    public string Descrizione()
    {
        return "Pizza Margherita";
    }
}

public class Diavola : IPizza
{
    public string Descrizione()
    {
        return "Pizza Diavola";
    }
}

public class Vegetariana : IPizza
{
    public string Descrizione()
    {
        return "Pizza Vegetariana";
    }
}

public abstract class IngredienteDecorator : IPizza
{
    protected IPizza _pizza;

    public IngredienteDecorator(IPizza pizza)
    {
        _pizza = pizza;
    }

    public abstract string Descrizione();
}

public class ConOlive : IngredienteDecorator
{
    public ConOlive(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return $"{_pizza.Descrizione()} + olive";
    }
}

public class ConMozzarellaExtra : IngredienteDecorator
{
    public ConMozzarellaExtra(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return $"{_pizza.Descrizione()} + mozzarella extra";
    }
}

public class ConFunghi : IngredienteDecorator
{
    public ConFunghi(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return $"{_pizza.Descrizione()} + funghi";
    }
}

public static class PizzaFactory
{
    public static IPizza CreaPizza(string pizza)
    {
        switch (pizza)
        {
            case "1":
                return new Margherita();
            case "2":
                return new Diavola();
            case "3":
                return new Vegetariana();
            default:
                Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                return null;
        }
    }
}

public interface IMetodoCottura
{
    string Cuoci(string pizza);
}

public class FornoElettrico : IMetodoCottura
{
    public string Cuoci(string descrizione)
    {
        return $"{descrizione}, cotta in forno elettrico";
    }
}

public class FornoLegna : IMetodoCottura
{
    public string Cuoci(string descrizione)
    {
        return $"{descrizione}, cotta in forno a legna";
    }
}

public class FornoVentilato : IMetodoCottura
{
    public string Cuoci(string descrizione)
    {
        return $"{descrizione}, cotta in forno ventilato";
    }
}

public class Chef
{
    private IMetodoCottura _metodoCottura;

    public void ImpostaMetodoCottura(IMetodoCottura metodoCottura)
    {
        _metodoCottura = metodoCottura;
    }

    public string CuociPizza(IPizza pizza)
    {
        if (_metodoCottura == null)
        {
            return "Nessuna strategia impostata.";
        }
        return _metodoCottura.Cuoci(pizza.Descrizione());
    }
}

public interface IObserver
{
    void Update(string pizza);
}

public class GestioneOrdine
{
    private static GestioneOrdine _instance;
    private IObserver _ordine;

    public static GestioneOrdine Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GestioneOrdine();
            return _instance;
        }
    }

    public void Register(IObserver newOrdine)
    {
        _ordine = newOrdine;
    }

    public void Notify(string pizza)
    {
        if (_ordine != null)
            _ordine.Update(pizza);
    }

}

public class SistemaLog : IObserver
{
    public void Update(string pizza)
    {
        Console.WriteLine("-----------");
        Console.WriteLine($"La pizzeria ha ricevuto il tuo ordine di: {pizza}.");
        Console.WriteLine("-----------");
    }
}

public class SistemaMarketing : IObserver
{
    public void Update(string promo)
    {
        Console.WriteLine("-----------");
        Console.WriteLine($"Notifica promo: {promo}");
        Console.WriteLine("-----------");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var chef = new Chef();
        var ordine = GestioneOrdine.Instance;
        IObserver log = new SistemaLog();
        IObserver market = new SistemaMarketing();
        bool esci = false;
        bool extra = true;
        string promo = "Sconto del 20% sul tuo prossimo ordine!";

        do
        {
            Console.WriteLine("Benvenuto in pizzeria! Che pizza vuoi ordinare?");
            Console.WriteLine("[1] Margherita\n[2] Diavola\n[3] Vegetariana");
            string sceltaPizza = Console.ReadLine();

            IPizza pizza = PizzaFactory.CreaPizza(sceltaPizza);

            if (pizza == null)
            {
                continue;
            }

            do
            {
                Console.WriteLine("Vuoi aggiungere ingredienti extra?");
                Console.WriteLine("[1] Olive\n[2] Mozzarella extra\n[3] Funghi\n[0] No");
                string sceltaIngrediente = Console.ReadLine();

                switch (sceltaIngrediente)
                {
                    case "1":
                        extra = true;
                        pizza = new ConOlive(pizza);
                        break;
                    case "2":
                        extra = true;
                        pizza = new ConMozzarellaExtra(pizza);
                        break;
                    case "3":
                        extra = true;
                        pizza = new ConFunghi(pizza);
                        break;
                    case "0":
                        extra = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida, riprova.");
                        continue;
                }
            } while (extra);

            Console.WriteLine("Come vuoi che sia preparata la tua pizza?");
            Console.WriteLine("[1] Forno elettrico\n[2] Forno a legna\n[3] Forno ventilato");
            string sceltaCottura = Console.ReadLine();

            switch (sceltaCottura)
            {
                case "1":
                    chef.ImpostaMetodoCottura(new FornoElettrico());
                    break;
                case "2":
                    chef.ImpostaMetodoCottura(new FornoLegna());
                    break;
                case "3":
                    chef.ImpostaMetodoCottura(new FornoVentilato());
                    break;
                default:
                    Console.WriteLine("Scelta non valida, riprova.");
                    continue;
            }

            ordine.Register(log);
            log.Update(pizza.Descrizione());
            ordine.Register(market);
            market.Update(promo);

            Console.WriteLine("Vuoi ordinare un'altra pizza?");
            Console.WriteLine("[1] Sì\n[0] No");
            string continua = Console.ReadLine();

            switch (continua)
            {
                case "1":
                    break;
                case "0":
                    esci = true;
                    Console.WriteLine("Arrivederci campione!");
                    break;
                default:
                    Console.WriteLine("Scelta non valida, riprova.");
                    continue;
            }
        } while (!esci);
    }
}