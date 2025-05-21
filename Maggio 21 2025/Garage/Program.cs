using System;

public class Veicolo // Clase base/padre per Auto e Moto
{
    public string Marca, Modello;
    public virtual string StampaInfo()
    {
        return $"Marca: {Marca} || Modello: {Modello}";
    }
}

public class Auto : Veicolo // Classe derivata/figlio Auto, derivante da Veicolo
{
    public int NumeroPorte;

    public Auto(string marca, string modello, int numeroPorte) // Costruttore Auto (necessario per permettere l'input dell'utente)
    {
        Marca = marca;
        Modello = modello;
        NumeroPorte = numeroPorte;
    }

    public override string StampaInfo() // Override del metodo StampaInfo di Veicolo per Auto, stampa in aggiunta il numero di porte
    {
        return $"AUTO - Marca auto: {Marca} || Modello: {Modello} || Numero di porte: {NumeroPorte}";
    }
}

public class Moto : Veicolo // Classe derivata/figlio Moto, derivante da Veicolo
{
    public string TipoManubrio;

    public Moto(string marca, string modello, string tipoManubrio) // Costruttore Moto (necessario per permettere l'input dell'utente)
    {
        Marca = marca;
        Modello = modello;
        TipoManubrio = tipoManubrio;
    }

    public override string StampaInfo() // Override del metodo StampaInfo di Veicolo per Moto, stampa in aggiunta il tipo di manubrio
    {
        return $"MOTO - Marca: {Marca} || Modello: {Modello} || Tipo di manubrio: {TipoManubrio}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> garage = new List<Veicolo>(); // Creazione lista garage di tipo Veicolo
        int scelta;
        bool esci = false;

        do
        {
            Console.WriteLine("Benvenuto nel garage. Cosa vuoi fare?");
            Console.WriteLine("1. Inserire un'auto\n2. Inserisci una moto\n3. Visualizza i veicoli nel garage\n4. Esci dal programma");
            scelta = int.Parse(Console.ReadLine()); // Prende in input la scelta dell'utente per lo switch
            switch (scelta)
            {
                case 1: // Inserimento Auto
                    try
                    {
                        Console.WriteLine("Inserisci la marca:");
                        string marcaA = Console.ReadLine();
                        Console.WriteLine("Inserisci il modello:");
                        string modelloA = Console.ReadLine();
                        Console.WriteLine("Inserisci il numero di porte:");
                        int porte = int.Parse(Console.ReadLine());

                        // Creazione di un oggetto auto di tipo Auto e inserimento in lista garage
                        Auto auto = new Auto(marcaA, modelloA, porte);
                        garage.Add(auto);

                        Console.WriteLine("Auto inserita nel garage.");
                        break;
                    }

                    catch // Dopo
                    {
                        Console.WriteLine("ERRORE INPUT - Torno al menù.");
                        break;
                    }
                case 2: // Inserimento Moto
                    Console.WriteLine("Inserisci la marca:");
                    string marcaM = Console.ReadLine();
                    Console.WriteLine("Inserisci il modello:");
                    string modelloM = Console.ReadLine();
                    Console.WriteLine("Inserisci il tipo di manubrio:");
                    string manubrio = Console.ReadLine();

                    // Creazione di un oggetto moto di tipo Moto e inserimento in lista garage
                    Moto moto = new Moto(marcaM, modelloM, manubrio);
                    garage.Add(moto);

                    Console.WriteLine("Moto inserita nel garage.");
                    break;
                case 3: // Stampa la lista di tutti i veicoli nel garage
                    Console.WriteLine("Lista dei veicoli inseriti fino ad ora:");
                    foreach (Veicolo v in garage)
                    {
                        Console.WriteLine(v.StampaInfo());
                    }
                    break;
                case 4: // Uscita dal programma
                    Console.WriteLine("Arrivederci!");
                    esci = true; // Cambia esci in true per finire il ciclo una volta finito
                    break;
            }
        } while (!esci);
    }
}