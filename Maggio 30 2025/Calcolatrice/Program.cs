using System;

// Interfaccia per la strategia di operazione
public interface IStrategiaOperazione
{
    double Calcola(double a, double b); // Metodo per calcolare il risultato
}

// Strategia per la somma
public class SommaStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a + b;
    }
}

// Strategia per la sottrazione
public class SottrazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a - b;
    }
}

// Strategia per la moltiplicazione
public class MoltiplicazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a * b;
    }
}

// Strategia per la divisione
public class DivisioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a / b;
    }
}

// Classe Calcolatrice che usa una strategia per eseguire l'operazione
public class Calcolatrice
{
    private IStrategiaOperazione _strategia; // Strategia corrente

    // Esegue l'operazione usando la strategia impostata
    public void EseguiOperazione(double a, double b)
    {
        if (_strategia == null)
        {
            Console.WriteLine("Nessuna strategia impostata.");
            return;
        }
        double risultato = _strategia.Calcola(a, b);
        Console.WriteLine("-------------");
        Console.WriteLine($"Risultato dell'operazione: {risultato}");
        Console.WriteLine("-------------");
    }

    // Imposta la strategia da usare
    public void ImpostaStrategia(IStrategiaOperazione nuovaStrategia)
    {
        _strategia = nuovaStrategia;
    }
}

// Classe principale del programma
public class Program
{
    public static void Main(string[] args)
    {
        var calcolatrice = new Calcolatrice(); // Istanza della calcolatrice
        bool esci = false; // Flag per uscire dal ciclo

        do
        {
            Console.WriteLine("Benvenuto!");
            Console.WriteLine("Inserisci il primo numero:");
            double a = double.Parse(Console.ReadLine()); // Lettura primo numero
            Console.WriteLine("Inserisci il secondo numero:");
            double b = double.Parse(Console.ReadLine()); // Lettura secondo numero

            Console.WriteLine("Che operazione vuoi effettuare?");
            Console.WriteLine("[1] Addizione\n[2] Sottrazione\n[3] Moltiplicazione\n[4] Divisione\n[0] Esci");
            string op = Console.ReadLine(); // Lettura scelta utente

            switch (op)
            {
                case "1":
                    calcolatrice.ImpostaStrategia(new SommaStrategia()); // Imposta somma
                    calcolatrice.EseguiOperazione(a, b);
                    break;
                case "2":
                    calcolatrice.ImpostaStrategia(new SottrazioneStrategia()); // Imposta sottrazione
                    calcolatrice.EseguiOperazione(a, b);
                    break;
                case "3":
                    calcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia()); // Imposta moltiplicazione
                    calcolatrice.EseguiOperazione(a, b);
                    break;
                case "4":
                    calcolatrice.ImpostaStrategia(new DivisioneStrategia()); // Imposta divisione
                    calcolatrice.EseguiOperazione(a, b);
                    break;
                case "0":
                    esci = true; // Esce dal ciclo
                    Console.WriteLine("Arrivederci campione!");
                    break;
                default:
                    Console.WriteLine("ERRORE INPUT - Ritorno al menù."); // Input non valido
                    break;
            }
        } while (!esci); // Ripete finché l'utente non sceglie di uscire
    }
}