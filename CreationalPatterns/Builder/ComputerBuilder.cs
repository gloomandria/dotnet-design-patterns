namespace CreationalPatterns.Builder;

public class Computer
{
    public string CPU { get; set; } = string.Empty;
    public string RAM { get; set; } = string.Empty;
    public string Storage { get; set; } = string.Empty;
    public string GPU { get; set; } = string.Empty;
    public bool HasWiFi { get; set; }
    public bool HasBluetooth { get; set; }

    public void DisplaySpecs()
    {
        Console.WriteLine("=== Computer Specifications ===");
        Console.WriteLine($"CPU: {CPU}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"Storage: {Storage}");
        Console.WriteLine($"GPU: {GPU}");
        Console.WriteLine($"WiFi: {(HasWiFi ? "Yes" : "No")}");
        Console.WriteLine($"Bluetooth: {(HasBluetooth ? "Yes" : "No")}");
    }
}

public interface IComputerBuilder
{
    IComputerBuilder SetCPU(string cpu);
    IComputerBuilder SetRAM(string ram);
    IComputerBuilder SetStorage(string storage);
    IComputerBuilder SetGPU(string gpu);
    IComputerBuilder AddWiFi();
    IComputerBuilder AddBluetooth();
    Computer Build();
}

public class ComputerBuilder : IComputerBuilder
{
    private readonly Computer _computer = new();

    public IComputerBuilder SetCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this;
    }

    public IComputerBuilder SetRAM(string ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public IComputerBuilder SetStorage(string storage)
    {
        _computer.Storage = storage;
        return this;
    }

    public IComputerBuilder SetGPU(string gpu)
    {
        _computer.GPU = gpu;
        return this;
    }

    public IComputerBuilder AddWiFi()
    {
        _computer.HasWiFi = true;
        return this;
    }

    public IComputerBuilder AddBluetooth()
    {
        _computer.HasBluetooth = true;
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}

public class GamingComputerBuilder : IComputerBuilder
{
    private readonly Computer _computer = new();

    public GamingComputerBuilder()
    {
        SetCPU("Intel i9-13900K");
        SetRAM("32GB DDR5");
        SetGPU("NVIDIA RTX 4090");
        AddWiFi();
        AddBluetooth();
    }

    public IComputerBuilder SetCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this;
    }

    public IComputerBuilder SetRAM(string ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public IComputerBuilder SetStorage(string storage)
    {
        _computer.Storage = storage;
        return this;
    }

    public IComputerBuilder SetGPU(string gpu)
    {
        _computer.GPU = gpu;
        return this;
    }

    public IComputerBuilder AddWiFi()
    {
        _computer.HasWiFi = true;
        return this;
    }

    public IComputerBuilder AddBluetooth()
    {
        _computer.HasBluetooth = true;
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}
