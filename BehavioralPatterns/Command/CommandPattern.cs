namespace BehavioralPatterns.Command;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    private bool _isOn;

    public void TurnOn()
    {
        _isOn = true;
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        _isOn = false;
        Console.WriteLine("Light is OFF");
    }
}

public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}

public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }

    public void Undo()
    {
        _light.TurnOn();
    }
}

public class TextEditor
{
    private string _text = string.Empty;

    public void Write(string text)
    {
        _text += text;
        Console.WriteLine($"Text now: '{_text}'");
    }

    public void Erase(int length)
    {
        if (length <= _text.Length)
        {
            _text = _text[..^length];
            Console.WriteLine($"Text now: '{_text}'");
        }
    }

    public string GetText() => _text;
}

public class WriteCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;

    public WriteCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }

    public void Execute()
    {
        _editor.Write(_text);
    }

    public void Undo()
    {
        _editor.Erase(_text.Length);
    }
}

public class RemoteControl
{
    private readonly Stack<ICommand> _history = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            var command = _history.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("Nothing to undo!");
        }
    }
}
