using System;

public class Cane // Definizione della classe cane
{
    public string nome;
    public int eta;

    // Metodo
    public void Abbaia()
    {
        Console.WriteLine($"{nome} dice: Bau!");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Creazione di un oggetto (istanza della classe Cane)
        Cane mioCane = new Cane();

        // Assegnazione dei valori alle proprietà
        mioCane.nome = "Fido";
        mioCane.eta = 3;

        // Chiamata di un metodo sull'oggetto
        mioCane.Abbaia(); // Output: Fido dice: Bau!
    }
}