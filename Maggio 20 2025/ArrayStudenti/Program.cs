using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Di quanti studenti vuoi inserire i voti?");
        int i = int.Parse(Console.ReadLine());
        int[] voti = new int[i];

        for (i = 0; i < voti.Length; i++)
        {
            Console.WriteLine($"Inserisci il voto numero {i + 1}");
            voti[i] = int.Parse(Console.ReadLine());
        }

        int votoMax = voti[0];
        int votoMin = voti[0];
        int somma = voti[0];
        
        for (i = 1; i < voti.Length; i++)
        {
            if (voti[i] > votoMax)
            {
                votoMax = voti[i];
            }

            else if (voti[i] < votoMin)
            {
                votoMin = voti[i];
            }

            somma += voti[i];
        }

        float media = (float)somma / voti.Length;

        Console.WriteLine($"Voto più alto: {votoMax}\nVoto più basso: {votoMin}\nMedia voti: {media}");
    }
}