using Microsoft.Extensions.Logging;
using System.IO;

namespace WpfCommunityToolkit.Infrastructure;

/// <summary>
/// Implementierung von <see cref="ILogger"/> für einen einfachen FileLogger.
/// </summary>
public class FileLogger : ILogger
{
    private readonly string _filePath;
    private readonly object _lock = new object();

    /// <summary>
    /// Konstruktor für einen <see cref="FileLogger"/> mit dem gg. Dateipfad.
    /// </summary>
    /// <param name="filePath">Pfad der LogDatei.</param>
    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    /// <inheritdoc />
    public IDisposable BeginScope<TState>(TState state) => null!;

    /// <inheritdoc />
    public bool IsEnabled(LogLevel logLevel) => true;

    /// <inheritdoc />
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        var message = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} [{logLevel}] {formatter(state, exception)}";
        lock (_lock)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}
