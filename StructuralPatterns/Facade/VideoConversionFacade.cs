namespace StructuralPatterns.Facade;

public class VideoFile
{
    public string Name { get; }
    public string CodecType { get; }

    public VideoFile(string name)
    {
        Name = name;
        CodecType = name.Split('.')[^1];
    }
}

public class CodecFactory
{
    public static ICodec Extract(VideoFile file)
    {
        return file.CodecType switch
        {
            "mp4" => new MPEG4CompressionCodec(),
            "ogg" => new OggCompressionCodec(),
            _ => throw new NotSupportedException($"Codec not supported: {file.CodecType}")
        };
    }
}

public interface ICodec { }

public class MPEG4CompressionCodec : ICodec
{
    public override string ToString() => "MPEG4";
}

public class OggCompressionCodec : ICodec
{
    public override string ToString() => "Ogg";
}

public class BitrateReader
{
    public static string Read(VideoFile file, ICodec codec)
    {
        Console.WriteLine($"Reading file {file.Name} with {codec}...");
        return "Buffer data";
    }

    public static string Convert(string buffer, ICodec codec)
    {
        Console.WriteLine($"Converting buffer with {codec}...");
        return "Converted buffer";
    }
}

public class AudioMixer
{
    public string Fix(string result)
    {
        Console.WriteLine("Fixing audio...");
        return "Fixed audio";
    }
}

public class VideoConversionFacade
{
    public string ConvertVideo(string fileName, string format)
    {
        Console.WriteLine("=== VideoConversionFacade: Conversion started ===");
        
        var file = new VideoFile(fileName);
        var sourceCodec = CodecFactory.Extract(file);
        
        ICodec destinationCodec = format switch
        {
            "mp4" => new MPEG4CompressionCodec(),
            "ogg" => new OggCompressionCodec(),
            _ => throw new NotSupportedException($"Format not supported: {format}")
        };

        var buffer = BitrateReader.Read(file, sourceCodec);
        var result = BitrateReader.Convert(buffer, destinationCodec);
        
        var audioMixer = new AudioMixer();
        result = audioMixer.Fix(result);

        Console.WriteLine("=== VideoConversionFacade: Conversion completed ===");
        return result;
    }
}
