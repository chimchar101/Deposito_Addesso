using System;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> spesa = new List<string>();
        Console.WriteLine("Quanti elementi vuoi inserire nella lista della spesa?");
        int elementi = int.Parse(Console.ReadLine());

        for (int i = 0; i < elementi; i++)
        {
            Console.WriteLine($"Inserisci l'elemento numero {i + 1}");
            spesa.Add(Console.ReadLine());
        }

        foreach (string s in spesa)
        {
            Console.WriteLine($"{s}");
        }
    }
}