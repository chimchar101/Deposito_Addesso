using System;

public class Persona
{
    public string Nome;
    public int Eta;

    // Costruttore con parametri
    public Persona(string nome, int Eta)
    {
        Nome = nome;
        Eta = eta;
    }

    public void Presentati()
    {
        Console.WriteLine($"Ciao, sono {Nome} e ho {Eta} anni.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Creazione dell'oggetto con costruttore
        Persona p = new Persona("Simone", 22);

        // Chiamata al metodo dell'oggetto
        p.Presentati(); // Output: Ciao, sono Simone e ho 22 anni.
    }
}
