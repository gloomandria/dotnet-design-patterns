namespace StructuralPatterns.Decorator;

public interface ICoffee
{
    string GetDescription();
    decimal GetCost();
}

public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public decimal GetCost()
    {
        return 2.00m;
    }
}

public abstract class CoffeeDecorator : ICoffee
{
    protected readonly ICoffee _coffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return _coffee.GetDescription();
    }

    public virtual decimal GetCost()
    {
        return _coffee.GetCost();
    }
}

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{_coffee.GetDescription()}, Milk";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.50m;
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{_coffee.GetDescription()}, Sugar";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.25m;
    }
}

public class WhippedCreamDecorator : CoffeeDecorator
{
    public WhippedCreamDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{_coffee.GetDescription()}, Whipped Cream";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.75m;
    }
}

public class CaramelDecorator : CoffeeDecorator
{
    public CaramelDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return $"{_coffee.GetDescription()}, Caramel";
    }

    public override decimal GetCost()
    {
        return _coffee.GetCost() + 0.60m;
    }
}
