using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace WpfCommunityToolkit.Infrastructure;

/// <summary>
/// Provider für den FileLogger.
/// </summary>
public class FileLoggerProvider : ILoggerProvider
{
    private readonly string _filePath;
    private readonly ConcurrentDictionary<string, FileLogger> _loggers = new ConcurrentDictionary<string, FileLogger>();

    /// <summary>
    /// FileLoggerProvider Konstruktor mit dem gg. Dateipfad.
    /// </summary>
    /// <param name="filePath">Pfad der LogDatei.</param>
    public FileLoggerProvider(string filePath)
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Erzeugt eine <see cref="ILogger"/>-Instanz mit dem gg. Kategorienamen.
    /// </summary>
    /// <param name="categoryName">Kategoriename</param>
    /// <returns>Ein <see cref="ILogger"/></returns>
    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, name => new FileLogger(_filePath));
    }

    /// <summary>
    /// Dispose-Methode für den Provider.
    /// </summary>
    /// <remarks>
    /// Löscht alle Logger des Providers
    /// </remarks>
    public void Dispose()
    {
        _loggers.Clear();
    }
}
