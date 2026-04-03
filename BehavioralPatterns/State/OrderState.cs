namespace BehavioralPatterns.State;

public interface IOrderState
{
    void PayOrder(Order order);
    void ShipOrder(Order order);
    void DeliverOrder(Order order);
    void CancelOrder(Order order);
}

public class Order
{
    public string OrderId { get; }
    private IOrderState _state;

    public Order(string orderId)
    {
        OrderId = orderId;
        _state = new NewOrderState();
        Console.WriteLine($"Order {OrderId} created in NEW state");
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }

    public void Pay()
    {
        _state.PayOrder(this);
    }

    public void Ship()
    {
        _state.ShipOrder(this);
    }

    public void Deliver()
    {
        _state.DeliverOrder(this);
    }

    public void Cancel()
    {
        _state.CancelOrder(this);
    }
}

public class NewOrderState : IOrderState
{
    public void PayOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Payment processed");
        order.SetState(new PaidOrderState());
    }

    public void ShipOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Cannot ship unpaid order");
    }

    public void DeliverOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Cannot deliver unpaid order");
    }

    public void CancelOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Order cancelled");
        order.SetState(new CancelledOrderState());
    }
}

public class PaidOrderState : IOrderState
{
    public void PayOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Already paid");
    }

    public void ShipOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Order shipped");
        order.SetState(new ShippedOrderState());
    }

    public void DeliverOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Cannot deliver unshipped order");
    }

    public void CancelOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Refund processing, order cancelled");
        order.SetState(new CancelledOrderState());
    }
}

public class ShippedOrderState : IOrderState
{
    public void PayOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Already paid");
    }

    public void ShipOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Already shipped");
    }

    public void DeliverOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Order delivered successfully");
        order.SetState(new DeliveredOrderState());
    }

    public void CancelOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Cannot cancel shipped order");
    }
}

public class DeliveredOrderState : IOrderState
{
    public void PayOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Already paid and delivered");
    }

    public void ShipOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Already delivered");
    }

    public void DeliverOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Already delivered");
    }

    public void CancelOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Cannot cancel delivered order");
    }
}

public class CancelledOrderState : IOrderState
{
    public void PayOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Cannot pay cancelled order");
    }

    public void ShipOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Cannot ship cancelled order");
    }

    public void DeliverOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Cannot deliver cancelled order");
    }

    public void CancelOrder(Order order)
    {
        Console.WriteLine($"Order {order.OrderId}: Already cancelled");
    }
}
