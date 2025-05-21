using System;

public class Film
{
    public string Titolo, Regista, Genere;
    public int Anno;

    public Film(string titolo, string regista, string genere, int anno)
    {
        Titolo = titolo;
        Regista = regista;
        Genere = genere;
        Anno = anno;
    }
    public override string ToString()
    {
        return $"{Titolo} ({Anno}) || Regista: {Regista} || Genere: {Genere}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Film> videoteca = new List<Film>();
        int scelta;
        bool esci = false;

        do
        {
            Console.WriteLine("Benvenuto! Cosa vuoi fare?");
            Console.WriteLine("1. Inserire un film\n2. Leggere lista film\n3. Cerca film per genere\n4. Uscire dal programma");
            scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci titolo film:");
                    string titolo = Console.ReadLine();
                    Console.WriteLine("Inserisci regista film:");
                    string regista = Console.ReadLine();
                    Console.WriteLine("Inserisci genere film:");
                    string genere = Console.ReadLine();
                    Console.WriteLine("Inserisci anno film:");
                    int anno = int.Parse(Console.ReadLine());

                    Film newFilm = new Film(titolo, regista, genere, anno);
                    videoteca.Add(newFilm);
                    break;
                case 2:
                    Console.WriteLine("Lista dei film inseriti fino ad ora:");
                    foreach (Film film in videoteca)
                    {
                        Console.WriteLine(film);
                    }
                    break;
                case 3:
                    Console.WriteLine("Che genere di film vuoi cercare?");
                    string gen = Console.ReadLine();
                    foreach (Film film in videoteca)
                    {
                        if (film.Genere.ToLower() == gen.ToLower())
                        {
                            Console.WriteLine(film);
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Arrivederci!");
                    esci = true;
                    break;
                default:
                    Console.WriteLine("ERRORE: Input errato. Torno al menù.");
                    break;
            }
        } while (!esci);
    }
}