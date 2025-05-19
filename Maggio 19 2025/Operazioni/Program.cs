using System;

class Program
{
    static void Main(string[] args)
    {
        int result = 0;

        Console.WriteLine("Inserisci il primo numero intero:");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il secondo numero intero:");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Che operazione vuoi effettuare? (A)ddizione, (M)oltiplicazione, (D)ivisione");
        string op = Console.ReadLine();

        switch (op)
        {
            case "A":
                result = Somma(n1, n2);
                break;
            case "M":
                result = Moltiplica(n1, n2);
                break;
            case "D":
                result = Dividi(n1, n2);
                break;
            default:
                Console.WriteLine("Input non corretto.");
                break;
        }

        StampaRisultato(op, result);
    }

    public static int Somma(int a, int b)
    {
        return a + b;
    }

    public static int Moltiplica(int a, int b)
    {
        return a * b;
    }

    public static int Dividi(int a, int b)
    {
        int risultato = 0;

        try
        {
            risultato = a / b;
        }

        catch (DivideByZeroException)
        {
            Console.WriteLine("Impossibile dividere per 0.");
        }

        return risultato;
    }

    public static void StampaRisultato(string operazione, int risultato)
    {
        switch (operazione)
        {
            case "A":
                Console.WriteLine($"Il risultato dell'addizione è {risultato}");
                break;
            case "M":
                Console.WriteLine($"Il risultato della moltiplicazione è {risultato}");
                break;
            case "D":
                Console.WriteLine($"Il risultato della divisione è {risultato}");
                break;
        }
    }
}