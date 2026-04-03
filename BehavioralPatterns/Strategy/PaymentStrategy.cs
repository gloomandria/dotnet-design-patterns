namespace BehavioralPatterns.Strategy;

public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    private readonly string _cardNumber;
    private readonly string _cvv;

    public CreditCardPayment(string cardNumber, string cvv)
    {
        _cardNumber = cardNumber;
        _cvv = cvv;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount:C} with Credit Card ending in {_cardNumber[^4..]}");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    private readonly string _email;

    public PayPalPayment(string email)
    {
        _email = email;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount:C} with PayPal account {_email}");
    }
}

public class CryptocurrencyPayment : IPaymentStrategy
{
    private readonly string _walletAddress;
    private readonly string _cryptoType;

    public CryptocurrencyPayment(string walletAddress, string cryptoType)
    {
        _walletAddress = walletAddress;
        _cryptoType = cryptoType;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount:C} with {_cryptoType} to wallet {_walletAddress[..10]}...");
    }
}

public class ShoppingCart
{
    private readonly List<string> _items = new();
    private IPaymentStrategy? _paymentStrategy;

    public void AddItem(string item)
    {
        _items.Add(item);
        Console.WriteLine($"Added '{item}' to cart");
    }

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
    }

    public void Checkout(decimal total)
    {
        if (_paymentStrategy == null)
        {
            Console.WriteLine("Please select a payment method!");
            return;
        }

        Console.WriteLine($"\n=== Checkout ({_items.Count} items) ===");
        _paymentStrategy.Pay(total);
        Console.WriteLine("Payment successful!\n");
    }
}
