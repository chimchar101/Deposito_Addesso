using System;

public class ContoBancario
{
    // Campo privato (non accessibile direttamente dall'esterno)
    private double saldo;

    //Proprietà per accedere al saldo in modo controllato
    public double Saldo
    {
        get
        {
            return saldo;
        }
        set
        {
            if (value >= 0) // Solo valori validi
            {
                saldo = value;
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ContoBancario conto = new ContoBancario();

        conto.Saldo = 1000.50; // Imposta saldo tramite la proprietà
        Console.WriteLine(conto.Saldo); // Leggi il saldo tramite la proprietà

        conto.Saldo = -500; // Non modifica il saldo perché negativo
        Console.WriteLine(conto.Saldo); // Rimane 1000.50
    }
}