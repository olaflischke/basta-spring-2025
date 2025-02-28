using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfCommunityToolkit.Infrastructure;
using WpfCommunityToolkit.Views;

namespace WpfCommunityToolkit;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private Bootstrapper bootstrapper = null!;

    // Syntaxerleichterung für den Zugriff auf die App-Instanz
    public new static App Current => (App)Application.Current;

    // DI-Container
    public IServiceProvider Services { get => bootstrapper.Services; }

    // Start-Logik der Anwendung
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Bootstrapper für die Dependency-Injection
        bootstrapper = new Bootstrapper();
        bootstrapper.Run();

        // Messages registrieren
        WeakReferenceMessenger.Default.Register<ShowArtistEditDialogMessage>(this,
            (recipient, message) =>
            {
                // Dialog anzeigen
                AddEditArtistWindow addEditArtistWindow = new AddEditArtistWindow(message.Artist, bootstrapper.Services.GetRequiredService<IMessenger>());
                addEditArtistWindow.ShowDialog();
            });
    }
}
