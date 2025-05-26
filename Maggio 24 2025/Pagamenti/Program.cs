public interface IPagamento
{
    void EseguiPagamento(decimal importo);
    void MostraMetodo();
}

public class PagamentoCarta : IPagamento
{
    public string Circuito { get; set; }

    public PagamentoCarta(string circuito)
    {
        Circuito = circuito;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro con carta del circuito {Circuito}.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Carta di credito");
        Console.WriteLine("----------------");
    }
}

public class PagamentoContanti : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro in contanti.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Contanti");
        Console.WriteLine("----------------");
    }
}

public class PagamentoPayPal : IPagamento
{
    private string _emailUtente;

    public string EmailUtente
    {
        get
        {
            return _emailUtente;
        }

        set
        {
            _emailUtente = value;
        }
    }

    public PagamentoPayPal(string _emailUtente)
    {
        EmailUtente = _emailUtente;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro tramite PayPal da: {EmailUtente}.");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: PayPal");
        Console.WriteLine("----------------");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;
        int scelta;
        List<IPagamento> pagamenti = new List<IPagamento>();

        do
        {
            Console.WriteLine("Benvenuto. Cosa vuoi fare?");
            Console.WriteLine("[1] Aggiungi pagamento con carta\n[2] Aggiungi pagamento in contanti\n[3] Aggiungi pagamento con PayPal");
            Console.WriteLine("[4] Effettua un pagamento\n[0] Esci");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    PagaCarta(pagamenti);
                    break;
                case 2:
                    PagaContanti(pagamenti);
                    break;
                case 3:
                    PagaPaypal(pagamenti);
                    break;
                case 4:
                    Pagamento(pagamenti);
                    break;
                case 0:
                    esci = true;
                    Console.WriteLine("Arrivederci campione!");
                    break;
                default:
                    Console.WriteLine("ERRORE INPUT - Ritorno al menù.");
                    break;
            }
        } while (!esci);
    }

    private static void PagaCarta(List<IPagamento> pagamenti)
    {
        Console.WriteLine("Inserisci il circuito della carta di credito:");
        string circuito = Console.ReadLine();

        PagamentoCarta carta = new PagamentoCarta(circuito);
        pagamenti.Add(carta);
        Console.WriteLine("Pagamento con carta inserito!");
    }

    private static void PagaContanti(List<IPagamento> pagamenti)
    {
        PagamentoContanti contanti = new PagamentoContanti();
        pagamenti.Add(contanti);
        Console.WriteLine("Pagamento con contanti inserito!");
    }

    private static void PagaPaypal(List<IPagamento> pagamenti)
    {
        Console.WriteLine("Inserisci l'email dell'account PayPal:");
        string email = Console.ReadLine();

        PagamentoPayPal paypal = new PagamentoPayPal(email);
        pagamenti.Add(paypal);
        Console.WriteLine("Pagamento con PayPal inserito!");
    }

    private static void Pagamento(List<IPagamento> pagamenti)
    {
        for (int i = 0; i < pagamenti.Count; i++)
        {
            Console.WriteLine($"Pagamento {i + 1}");
            pagamenti[i].MostraMetodo();
        }

        Console.WriteLine("Quale metodo vuoi usare per pagare?");
        int p = int.Parse(Console.ReadLine());

        Console.WriteLine("Quanto vuoi pagare?");
        int importo = int.Parse(Console.ReadLine());
        pagamenti[p - 1].EseguiPagamento(importo); 
    }
}