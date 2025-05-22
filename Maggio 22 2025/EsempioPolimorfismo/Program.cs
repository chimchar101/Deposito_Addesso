using System;

// Classe base con metodo virtuale
public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

// Classe derivata con override del metodo
public class Cane : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il cane abbaia.");
    }
}

public class Gatto : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il gatto miagola.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Lista di animali
        List<Animale> animali = new List<Animale>();
        animali.Add(new Cane());
        animali.Add(new Gatto());

        // Polimorfismo in azione: ogni oggetto chiama la sua versione di FaiVerso()
        foreach (Animale a in animali)
        {
            a.FaiVerso(); // Comportamento specifico di Cane o Gatto
        }
    }
}