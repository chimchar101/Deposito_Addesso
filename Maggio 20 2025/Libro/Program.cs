using System;

public class Libro
{
    // Variabili della classe Libro
    public string Titolo;
    public string Autore;
    public int AnnoPubblicazione;

    // Override di ToString() per stampare titolo, autore e anno di pubblicazione
    public override string ToString()
    {
        return $"\"{Titolo}\" di {Autore} ({AnnoPubblicazione})";
    }

    // Equals che considera libri uguali se hanno lo stesso titolo e autore
    public override bool Equals(object obj)
    {
        if (obj is Libro altro)
        {
            return this.Titolo == altro.Titolo && this.Autore == altro.Autore;
        }

        return false;
    }

    // HashCode coerente con Equals()
    public override int GetHashCode()
    {
        return HashCode.Combine(Titolo, Autore);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Inserimento dei due libri
        Libro l1 = new Libro { Titolo = "It", Autore = "Stephen King", AnnoPubblicazione = 1986 };
        Libro l2 = new Libro { Titolo = "It", Autore = "Stephen King", AnnoPubblicazione = 1986 };

        // Stampa per controllare se l'override di ToString() stampi il testo corretto
        Console.WriteLine(l1);
        Console.WriteLine(l2);

        // Stampa per controllare che Equals() funzioni e stampi true
        Console.WriteLine(l1.Equals(l2));

        // Stampa per controllare che GetHashCode restituisca lo stesso valore
        Console.WriteLine(l1.GetHashCode());
        Console.WriteLine(l2.GetHashCode());

        // Stampa per testare il metodo GetType() - Output: Libro
        Console.WriteLine(l1.GetType());
        Console.WriteLine(l2.GetType());

        // Stampa per testare il metodo ReferenceEquals() - Output: False
        Console.WriteLine(Object.ReferenceEquals(l1, l2));
    }
}