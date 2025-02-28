using ChinookDal.Model;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using WpfCommunityToolkit.ViewModels;

namespace WpfCommunityToolkit.Views;

/// <summary>
/// Interaction logic for AddEditArtistWindow.xaml
/// </summary>
public partial class AddEditArtistWindow : Window
{
    private readonly IMessenger messenger;

    public AddEditArtistWindow(Artist artist, IMessenger messenger)
    {
        InitializeComponent();

        this.messenger = messenger;
        AddEditArtistWindowViewModel viewModel = new AddEditArtistWindowViewModel(artist, messenger);

        // ViewModel aus dem DI-Container 
        //AddEditArtistWindowViewModel viewModel = (AddEditArtistWindowViewModel)App
        //                                                            .Current
        //                                                            .Services
        //                                                            .GetService(typeof(AddEditArtistWindowViewModel));

        viewModel.CloseAction = () =>
        {
            this.DialogResult = true;
            this.Close();
        };
        viewModel.Artist = artist;

        this.DataContext = viewModel;
    }
}
