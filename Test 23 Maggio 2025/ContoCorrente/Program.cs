using System;

public class ContoCorrente
{
    private decimal _saldo = 0;
    private int _numeroOperazioni = 0;

    public decimal Saldo
    {
        get
        {
            return _saldo;
        }
    }

    public int NumeroOperazioni
    {
        get
        {
            return _numeroOperazioni;
        }
    }

    public void Versa(decimal importo)
    {
        if (importo <= 0)
        {
            Console.WriteLine("Importo versamento non valido.");
        }

        else if (importo > 0)
        {
            _saldo += importo;
            _numeroOperazioni++;
        }
    }

    public void Preleva(decimal importo)
    {
        if (importo <= 0)
        {
            Console.WriteLine("Importo prelievo non valido.");
        }

        else if (importo <= Saldo)
        {
            _saldo -= importo;
            _numeroOperazioni++;
        }

        else
        {
            Console.WriteLine("Non puoi prelevare più del tuo saldo.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ContoCorrente conto = new ContoCorrente();

        conto.Versa(500);
        Console.WriteLine($"Saldo: {conto.Saldo} | Operazioni effettuate: {conto.NumeroOperazioni}");

        conto.Preleva(145);
        Console.WriteLine($"Saldo: {conto.Saldo} | Operazioni effettuate: {conto.NumeroOperazioni}");

        conto.Versa(1792);
        Console.WriteLine($"Saldo: {conto.Saldo} | Operazioni effettuate: {conto.NumeroOperazioni}");

        conto.Preleva(20000);
        Console.WriteLine($"Saldo: {conto.Saldo} | Operazioni effettuate: {conto.NumeroOperazioni}");
    }
}