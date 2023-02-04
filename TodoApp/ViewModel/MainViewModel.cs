using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace TodoApp.ViewModel;

public partial class MainViewModel:ObservableObject
{
    private IConnectivity _connectivity;
    public MainViewModel(IConnectivity connectivity)
    {
        _connectivity = connectivity;
    }
    [ObservableProperty]
    private ObservableCollection<String> items = new();
    
    [ObservableProperty]
    private string text;

    [RelayCommand]
    async Task Add()
    {
        if(string.IsNullOrWhiteSpace(Text))
            return;

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh oh!", "No internet", "Ok");
            return;
        }
        
        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?text={s}");
    }
}