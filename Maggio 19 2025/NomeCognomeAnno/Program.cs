using System;

public class Persona
{
    public string Nome;
    public string Cognome;
    public int AnnoNascita;

    public Persona(string nome, string cognome, int annoNascita)
    {
        Nome = nome;
        Cognome = cognome;
        AnnoNascita = annoNascita;
    }

    public override string ToString()
    {
        return $"{Nome} {Cognome} è nato/a nel {AnnoNascita}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string nome, cognome;
        int annoNascita, i = 1;

        while (i <= 2)
        {
            Console.WriteLine($"Inserisci il nome della persona:");
            nome = Console.ReadLine();
            Console.WriteLine($"Inserisci il cognome della persona:");
            cognome = Console.ReadLine();
            Console.WriteLine($"Inserisci l'anno di nascita della persona:");
            annoNascita = int.Parse(Console.ReadLine());

            if (i == 1)
            {
                Persona p1 = new Persona(nome, cognome, annoNascita);
                Console.WriteLine(p1);
            }

            else if (i == 2)
            {
                Persona p2 = new Persona(nome, cognome, annoNascita);
                Console.WriteLine(p2);
            }

            i++;
        }
    }
}
