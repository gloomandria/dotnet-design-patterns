namespace BehavioralPatterns.Observer;

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class WeatherStation : ISubject
{
    private readonly List<IObserver> _observers = new();
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
        Console.WriteLine($"Observer attached. Total: {_observers.Count}");
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine($"Observer detached. Total: {_observers.Count}");
    }

    public void Notify()
    {
        Console.WriteLine("\n=== Notifying all observers ===");
        foreach (var observer in _observers)
        {
            observer.Update(GetWeatherData());
        }
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        
        Console.WriteLine($"\nWeather Station: New measurements received");
        Notify();
    }

    private string GetWeatherData()
    {
        return $"Temperature: {_temperature}°C, Humidity: {_humidity}%, Pressure: {_pressure} hPa";
    }
}

public class PhoneDisplay : IObserver
{
    private readonly string _name;

    public PhoneDisplay(string name)
    {
        _name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"[Phone - {_name}] Weather update: {message}");
    }
}

public class DesktopDisplay : IObserver
{
    private readonly string _location;

    public DesktopDisplay(string location)
    {
        _location = location;
    }

    public void Update(string message)
    {
        Console.WriteLine($"[Desktop - {_location}] Weather update: {message}");
    }
}

public class WeatherLogger : IObserver
{
    public void Update(string message)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"[LOGGER] [{timestamp}] {message}");
    }
}
