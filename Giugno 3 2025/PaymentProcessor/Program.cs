public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}

public class PayPalGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Elaborazione del pagamento di {amount} euro attraverso PayPal.");
    }
}

public class StripeGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Elaborazione del pagamento di {amount} euro attraverso Stripe.");
    }
}

public class PaymentProcessor
{
    private readonly IPaymentGateway _paymentGateway;

    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public void Process(decimal amount)
    {
        _paymentGateway.ProcessPayment(amount);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        decimal amount;
        Console.WriteLine("Scegli il metodo di pagamento.");
        Console.WriteLine("[1] PayPal\n[2] Stripe");
        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                IPaymentGateway paypal = new PayPalGateway();
                PaymentProcessor paypalProcessor = new PaymentProcessor(paypal);
                Console.WriteLine("Inserisci l'importo da pagare:");
                amount = decimal.Parse(Console.ReadLine());
                paypalProcessor.Process(amount);
                break;
            case "2":
                IPaymentGateway stripe = new StripeGateway();
                PaymentProcessor stripeProcessor = new PaymentProcessor(stripe);
                Console.WriteLine("Inserisci l'importo da pagare:");
                amount = decimal.Parse(Console.ReadLine());
                stripeProcessor.Process(amount);
                break;
            default:
                Console.WriteLine("Metodo di pagamento non valido.");
                break;
        }
    }
}