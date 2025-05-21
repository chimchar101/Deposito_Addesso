// Classe base
public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

// Classe derivata
public class Cane : Animale
{
    // Metodo specifico della classe derivata
    public void Scodinzola()
    {
        Console.WriteLine("Il cane scodinzola.");
    }

    public virtual void FaiVerso()
    {
        Console.WriteLine("Il cane dice bau.");
    }
}

// Programma principale
public class Program
{
    public static void Main(string[] args)
    {
        Cane mioCane = new Cane(); // Creazione di un oggetto della classe derivata
        mioCane.FaiVerso(); // Metodo ereditato dalla classe base
        mioCane.Scodinzola(); // Metodo definito nella classe derivata
    }
}