using System;

public class Macchina
{
    public string Motore;
    public float VelocitaMac = 0;
    public int SospensioniMax = 0, NrModifiche = 0;
}

public class Utente
{
    public string Nome;
    public int Credito;

    public Utente(string nome, int credito)
    {
        Nome = nome;
        Credito = credito;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Macchina auto = new Macchina();

        Console.WriteLine("Inserisci il tuo nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Quanti crediti hai? (Da 1 a 9)");
        int crediti = int.Parse(Console.ReadLine());
        Utente utente = new Utente(nome, crediti);

        for (int i = 0; i < utente.Credito; i++)
        {
            Console.WriteLine($"Crediti rimanenti: {utente.Credito - i}. Cosa vuoi modificare?");
            Console.WriteLine("1. Velocità +10\n2. Cambia motore\n3. Sospensioni +1");
            int scelta1 = int.Parse(Console.ReadLine());

            switch (scelta1)
            {
                case 1:
                    auto.VelocitaMac += 10;
                    auto.NrModifiche++;
                    break;
                case 2:
                    Console.WriteLine("Inserisci il nuovo motore:");
                    auto.Motore = Console.ReadLine();
                    auto.NrModifiche++;
                    break;
                case 3:
                    auto.SospensioniMax++;
                    auto.NrModifiche++;
                    break;
                default:
                    Console.WriteLine("Errore input.");
                    i--;
                    break;
            }

            if (utente.Credito - i == 1)
            {
                break;
            }

            Console.WriteLine("Vuoi continuare le modifiche o uscire ora?");
            Console.WriteLine("1. Continua\n2. Esci");
            int scelta2 = int.Parse(Console.ReadLine());
            if (scelta2 == 2)
            {
                break;
            }
        }

        Console.WriteLine("Dati automobile:");
        Console.WriteLine($"Motore: {auto.Motore}\nVelocità: {auto.VelocitaMac}\nNumero sospensioni: {auto.SospensioniMax}\nModifiche effettuate: {auto.NrModifiche}");
    }
}