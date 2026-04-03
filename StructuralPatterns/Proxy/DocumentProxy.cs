namespace StructuralPatterns.Proxy;

public interface IDocument
{
    void Display();
}

public class RealDocument : IDocument
{
    private readonly string _fileName;
    private string _content;

    public RealDocument(string fileName)
    {
        _fileName = fileName;
        LoadDocument();
    }

    private void LoadDocument()
    {
        Console.WriteLine($"Loading heavy document: {_fileName}...");
        Thread.Sleep(1000);
        _content = $"Content of {_fileName}";
        Console.WriteLine($"Document {_fileName} loaded!");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying: {_content}");
    }
}

public class DocumentProxy : IDocument
{
    private readonly string _fileName;
    private RealDocument? _realDocument;

    public DocumentProxy(string fileName)
    {
        _fileName = fileName;
    }

    public void Display()
    {
        _realDocument ??= new RealDocument(_fileName);
        _realDocument.Display();
    }
}

public interface IImageService
{
    void DisplayImage(string imageId);
}

public class RealImageService : IImageService
{
    public void DisplayImage(string imageId)
    {
        Console.WriteLine($"Fetching image {imageId} from server...");
        Thread.Sleep(500);
        Console.WriteLine($"Displaying image: {imageId}");
    }
}

public class CachedImageProxy : IImageService
{
    private readonly RealImageService _realService;
    private readonly Dictionary<string, bool> _cache;

    public CachedImageProxy()
    {
        _realService = new RealImageService();
        _cache = new Dictionary<string, bool>();
    }

    public void DisplayImage(string imageId)
    {
        if (_cache.ContainsKey(imageId))
        {
            Console.WriteLine($"[CACHE HIT] Displaying cached image: {imageId}");
        }
        else
        {
            Console.WriteLine("[CACHE MISS] Fetching from server...");
            _realService.DisplayImage(imageId);
            _cache[imageId] = true;
        }
    }
}

public class ProtectedImageProxy : IImageService
{
    private readonly RealImageService _realService;
    private readonly string _currentUser;

    public ProtectedImageProxy(string currentUser)
    {
        _realService = new RealImageService();
        _currentUser = currentUser;
    }

    public void DisplayImage(string imageId)
    {
        if (_currentUser == "admin")
        {
            _realService.DisplayImage(imageId);
        }
        else
        {
            Console.WriteLine($"[ACCESS DENIED] User '{_currentUser}' cannot view image {imageId}");
        }
    }
}
