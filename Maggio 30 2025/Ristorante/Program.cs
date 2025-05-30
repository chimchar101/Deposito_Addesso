using System;

public interface IPiatto
{
    string Descrizione();
}

public class Pizza : IPiatto
{
    public string Descrizione()
    {
        return "Pizza";
    }
}

public class Hamburger : IPiatto
{
    public string Descrizione()
    {
        return "Hamburger";
    }
}

public class Insalata : IPiatto
{
    public string Descrizione()
    {
        return "Insalata";
    }
}

public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto _piattoBase;

    public IngredienteExtra(IPiatto piattoBase)
    {
        _piattoBase = piattoBase;
    }

    public abstract string Descrizione();
}

public class ConFormaggio : IngredienteExtra
{
    public ConFormaggio(IPiatto piattoBase) : base(piattoBase) { }

    public override string Descrizione()
    {
        return $"{_piattoBase.Descrizione()} + formaggio";
    }
}

public class ConBacon : IngredienteExtra
{
    public ConBacon(IPiatto piattoBase) : base(piattoBase) { }

    public override string Descrizione()
    {
        return $"{_piattoBase.Descrizione()} + bacon";
    }
}

public class ConSalsa : IngredienteExtra
{
    public ConSalsa(IPiatto piattoBase) : base(piattoBase) { }

    public override string Descrizione()
    {
        return $"{_piattoBase.Descrizione()} + salsa";
    }
}

public static class PiattoFactory
{
    public static IPiatto Crea(string piatto)
    {
        switch (piatto)
        {
            case "1":
                return new Pizza();
            case "2":
                return new Hamburger();
            case "3":
                return new Insalata();
            default:
                Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                return null;
        }
    }
}

public interface IPreparazioneStrategia
{
    string Prepara(string descrizione);
}

public class Fritto : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione}, fritto";
    }
}

public class AlForno : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione}, al forno";
    }
}

public class AllaGriglia : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione}, alla griglia";
    }
}

public class Chef
{
    private IPreparazioneStrategia _preparazioneStrategia;

    public void ImpostaStrategia(IPreparazioneStrategia strategia)
    {
        _preparazioneStrategia = strategia;
    }

    public string PreparaPiatto(IPiatto piatto)
    {
        if (_preparazioneStrategia == null)
        {
            return "Nessuna strategia impostata.";
        }
        return _preparazioneStrategia.Prepara(piatto.Descrizione());
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var chef = new Chef();
        bool esci = false;
        bool extra = true;

        do
        {
            Console.WriteLine("Benvenuto al ristorante! Che piatto vuoi ordinare?");
            Console.WriteLine("[1] Pizza\n[2] Hamburger\n[3] Insalata");
            string sceltaPiatto = Console.ReadLine();

            IPiatto piatto = PiattoFactory.Crea(sceltaPiatto);

            if (piatto == null)
            {
                continue;
            }

            do
            {
                Console.WriteLine("Vuoi aggiungere ingredienti extra?");
                Console.WriteLine("[1] Formaggio\n[2] Bacon\n[3] Salsa\n[0] No");
                string sceltaIngrediente = Console.ReadLine();

                switch (sceltaIngrediente)
                {
                    case "1":
                        extra = true;
                        piatto = new ConFormaggio(piatto);
                        break;
                    case "2":
                        extra = true;
                        piatto = new ConBacon(piatto);
                        break;
                    case "3":
                        extra = true;
                        piatto = new ConSalsa(piatto);
                        break;
                    case "0":
                        extra = false;
                        break;
                    default:
                        Console.WriteLine("ERRORE INPUT - Ritorno alla selezione.");
                        continue;
                }
            } while (extra);

            Console.WriteLine("Come vuoi che sia preparato il tuo piatto?");
            Console.WriteLine("[1] Fritto\n[2] Al forno\n[3] Alla griglia");
            string sceltaPreparazione = Console.ReadLine();

            switch (sceltaPreparazione)
            {
                case "1":
                    chef.ImpostaStrategia(new Fritto());
                    break;
                case "2":
                    chef.ImpostaStrategia(new AlForno());
                    break;
                case "3":
                    chef.ImpostaStrategia(new AllaGriglia());
                    break;
                default:
                    Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                    continue;
            }

            Console.WriteLine($"Preparazione completa: {chef.PreparaPiatto(piatto)}");
            Console.WriteLine("Vuoi ordinare un altro piatto?");
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
                    Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                    break;
            }
        } while (!esci);
    }
}