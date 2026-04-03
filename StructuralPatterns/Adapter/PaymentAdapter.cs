namespace StructuralPatterns.Adapter;

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount, string currency);
}

public class StripePaymentService
{
    public void MakePayment(double amountInCents, string currencyCode)
    {
        Console.WriteLine($"Stripe: Processing {amountInCents / 100} {currencyCode}");
    }
}

public class PayPalPaymentService
{
    public void SendPayment(string amount, string currency)
    {
        Console.WriteLine($"PayPal: Sending {amount} {currency}");
    }
}

public class StripeAdapter : IPaymentProcessor
{
    private readonly StripePaymentService _stripeService;

    public StripeAdapter(StripePaymentService stripeService)
    {
        _stripeService = stripeService;
    }

    public void ProcessPayment(decimal amount, string currency)
    {
        double amountInCents = (double)(amount * 100);
        _stripeService.MakePayment(amountInCents, currency);
    }
}

public class PayPalAdapter : IPaymentProcessor
{
    private readonly PayPalPaymentService _payPalService;

    public PayPalAdapter(PayPalPaymentService payPalService)
    {
        _payPalService = payPalService;
    }

    public void ProcessPayment(decimal amount, string currency)
    {
        _payPalService.SendPayment(amount.ToString("F2"), currency);
    }
}
