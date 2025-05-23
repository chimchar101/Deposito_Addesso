using System;

public class Veicolo
{
    public string Marca, Modello;
    public int AnnoImmatricolazione;

    public virtual string StampaInfo()
    {
        return $"Marca: {Marca} | Modello: {Modello} | Anno di immatricolazione: {AnnoImmatricolazione}";
    }
}

public class AutoAziendale : Veicolo
{
    public string Targa;
    public bool UsoPrivato;

    public AutoAziendale(string marca, string modello, int annoImmatricolazione, string targa, bool usoPrivato)
    {
        Marca = marca;
        Modello = modello;
        AnnoImmatricolazione = annoImmatricolazione;
        Targa = targa;
        UsoPrivato = usoPrivato;
    }

    public override string StampaInfo()
    {
        return $"Automobile con targa: {Targa} | Marca: {Marca} | Modello: {Modello} | Anno di immatricolazione: {AnnoImmatricolazione} | Per uso privato? {UsoPrivato}";
    }
}

public class FurgoneAziendale : Veicolo
{
    public int CapacitaCarico;

    public FurgoneAziendale(string marca, string modello, int annoImmatricolazione, int capacitaCarico)
    {
        Marca = marca;
        Modello = modello;
        AnnoImmatricolazione = annoImmatricolazione;
        CapacitaCarico = capacitaCarico;
    }

    public override string StampaInfo()
    {
        return $"Furgone con capacità di carico: {CapacitaCarico} | Marca: {Marca} | Modello: {Modello} | Anno di immatricolazione: {AnnoImmatricolazione}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>();
        AutoAziendale auto1 = new AutoAziendale("Toyota", "Yaris", 2022, "4ut0S1m0", false);
        veicoli.Add(auto1);
        FurgoneAziendale furgone1 = new FurgoneAziendale("Camion", "Epico", 2024, 1415);
        veicoli.Add(furgone1);
        AutoAziendale auto2 = new AutoAziendale("Fiat", "Panda", 2019, "4ut0C4rl0", true);
        veicoli.Add(auto2);
        FurgoneAziendale furgone2 = new FurgoneAziendale("Furgone", "Fantastico", 2015, 1950);
        veicoli.Add(furgone2);

        foreach (Veicolo veicolo in veicoli)
        {
            Console.WriteLine(veicolo.StampaInfo());
        }
    }
}