using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WpfCommunityToolkit.Infrastructure;

namespace WpfCommunityToolkit.ExtensionMethods;

public static class FileLoggerExtensions
{
    /// <summary>
    /// Erweiterterungsmethode für den LoggingBuilder, um einen FileLogger zu erstellen.
    /// </summary>
    /// <param name="builder">Der LoggingBuilder</param>
    /// <param name="filePath">Pfad der Log-Datei</param>
    /// <returns>LoggingBuilder</returns>
    /// <remarks>Erstellt zwecks Syntaxvereinfachung.</remarks>
    public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, string filePath)
    {
        builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>(provider => new FileLoggerProvider(filePath));
        return builder;
    }
}
