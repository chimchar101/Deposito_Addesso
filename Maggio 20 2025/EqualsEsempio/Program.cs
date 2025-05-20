using System;

public class Punto
{
    public int X;
    public int Y;

    // Sovrascrive Equals per confrontare coordinate
    public override bool Equals(object obj)
    {
        if (obj is Punto altro)
        {
            return this.X == altro.X && this.Y == altro.Y;
        }

        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Punto a = new Punto { X = 1, Y = 2 };
        Punto b = new Punto { X = 1, Y = 2 };

        Console.WriteLine(a.Equals(b));
        // Output: True (oggetti diversi uguali)
    }
}