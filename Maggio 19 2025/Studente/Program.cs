using System;

public class Studente
{
    public string Nome;
    public int Matricola;
    public double MediaVoti;

    public Studente(string nome, int matricola, double mediaVoti)
    {
        Nome = nome;
        Matricola = matricola;
        MediaVoti = mediaVoti;
    }

    public void Stampa()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matricola: {Matricola}");
        Console.WriteLine($"Media dei voti: {MediaVoti}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string nome;
        int i = 1, matricola;
        double mediaVoti;

        while (i <= 2)
        {
            Console.WriteLine($"Inserisci il nome dello studente {i}:");
            nome = Console.ReadLine();
            Console.WriteLine($"Inserisci la matricola dello studente {i}:");
            matricola = int.Parse(Console.ReadLine());
            Console.WriteLine($"Inserisci la media dei voti dello studente {i}:");
            mediaVoti = double.Parse(Console.ReadLine());

            if (i == 1)
            {
                Studente s1 = new Studente(nome, matricola, mediaVoti);
                s1.Stampa();
            }

            else if (i == 2)
            {
                Studente s2 = new Studente(nome, matricola, mediaVoti);
                s2.Stampa();
            }

            i++;
        }
    }
}
