using System;

public class Utente
{
    public string Nickname;
    public int Eta;
    public string Password;

    public Utente(string nickname, int eta, string password)
    {
        Nickname = nickname;
        Eta = eta;
        Password = password;
    }

    public override bool Equals(object obj)
    {
        if (obj is Utente altro)
        {
            return this.Nickname == altro.Nickname && this.Password == altro.Password;
        }

        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Utente newUtente = new Utente("", 0, "");
        bool esci = false, login = false;
        int scelta;

        do
        {
            Console.WriteLine("Benvenuto nella calcolatrice. Cosa vuoi fare?");
            Console.WriteLine("1. Registrati\n2. Login\n3. Esci");
            scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    newUtente = Registrazione();
                    break;
                case 2:
                    login = Login(newUtente.Nickname, newUtente.Password);
                    if (login)
                    {
                        Console.WriteLine($"Benvenuto, {newUtente.Nickname}!");
                        Calcolatrice(newUtente, out login);
                    }
                    break;
                case 3:
                    esci = true;
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("Input non valido.");
                    break;
            }
        } while (!esci);
    }

    private static Utente Registrazione()
    {
        string nickname, password;
        int eta;

        try
        {
            Console.WriteLine("Inserisci il tuo nickname:");
            nickname = Console.ReadLine();
            Console.WriteLine("Inserisci la tua eta:");
            eta = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la tua password:");
            password = Console.ReadLine();

            Utente newUtente = new Utente(nickname, eta, password);
            return newUtente;
        }

        catch
        {
            Console.WriteLine("C'è stato un errore. Ritorno al menù.");
            return null;
        }

    }

    private static bool Login(string nickname, string password)
    {
        Utente newUtente = new Utente(nickname, 0, password);
        try
        {
            Console.WriteLine("Inserisci il nickname:");
            string nick = Console.ReadLine();
            Console.WriteLine("Inserisci la tua password:");
            string pass = Console.ReadLine();
            Utente loginUtente = new Utente(nick, 0, pass);

            if (loginUtente.Equals(newUtente))
            {
                return true;
            }

            else
            {
                Console.WriteLine($"Nickname o password errati.");
                return false;
            }
        }

        catch
        {
            Console.WriteLine("C'è stato un errore. Ritorno al menù.");
            return false;
        }
    }

    private static void Calcolatrice(Utente newUtente, out bool login)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Inserisci il primo numero:");
            int n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il secondo numero:");
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Che operazione vuoi effettuare?");
            Console.WriteLine("1. Addizione\n2. Moltiplicazione\n3. Divisione");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.WriteLine($"{newUtente.Nickname}, la somma di {n1} e {n2} è {n1 + n2}");
                    break;
                case 2:
                    Console.WriteLine($"{newUtente.Nickname}, la somma di {n1} e {n2} è {n1 * n2}");
                    break;
                case 3:
                    Console.WriteLine($"{newUtente.Nickname}, la somma di {n1} e {n2} è {(float)(n1 / n2)}");
                    break;
            }
        }

        login = false;
        Console.WriteLine("Hai effettuato 3 operazioni, procedo con il logout.");
    }
}